using StackExchange.Redis;

namespace Utils4Net.Database.Redis
{
    public static class DatabaseManager
    {
        private static ConfigurationOptions? _configuration;
        private static ConnectionMultiplexer? _connection;
        private static IDatabase? _database;

        /*
         * Initialize
         */
        public static async Task Initialize(string configuration)
        {
            await Initialize(ConfigurationOptions.Parse(configuration));
        }

        public static async Task Initialize(ConfigurationOptions configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _configuration = configuration;
            _connection = await ConnectionMultiplexer.ConnectAsync(_configuration);
            _database = _connection.GetDatabase();
        }

        /*
         * Gets
         */
        public static ConfigurationOptions GetConfiguration()
        {
            return _configuration ?? throw new InvalidOperationException("database is not initialized");
        }

        public static ConnectionMultiplexer GetConnection()
        {
            return _connection ?? throw new InvalidOperationException("database is not initialized");
        }

        public static IDatabase GetDatabase()
        {
            return _database ?? throw new InvalidOperationException("database is not initialized");
        }
    }
}
