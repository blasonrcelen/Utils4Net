using MongoDB.Driver;

namespace Utils4Net.Database.MongoDB
{
    public static class DatabaseManager
    {
        private static DatabaseParameters? _parameters;
        private static MongoClient? _client;
        private static IMongoDatabase? _database;

        /*
         * Initialize
         */
        public static void Initialize(DatabaseParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            _parameters = parameters;
            _client = _parameters.GetClientConnection();
            _database = _client.GetDatabase(_parameters.Database);
        }

        /*
         * Gets
         */
        public static DatabaseParameters GetParameters()
        {
            return _parameters ?? throw new InvalidOperationException("database is not initialized");
        }

        public static MongoClient GetClient()
        {
            return _client ?? throw new InvalidOperationException("database is not initialized");
        }

        public static IMongoDatabase GetDatabase()
        {
            return _database ?? throw new InvalidOperationException("database is not initialized");
        }

        public static async Task<IClientSessionHandle> GetNewSession()
        {
            return await GetClient().StartSessionAsync();
        }

        public static bool UseTransactions()
        {
            return GetParameters().UseTransactions;
        }
    }
}
