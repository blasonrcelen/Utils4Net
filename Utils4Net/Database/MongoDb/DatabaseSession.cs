using MongoDB.Driver;

namespace Utils4Net.Database.MongoDB
{
    public class DatabaseSession : IDisposable
    {
        public readonly IClientSessionHandle Session;
        public readonly bool CanDispose;

        public DatabaseSession(DatabaseSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            CanDispose = false;
            Session = session.Session;
        }

        public DatabaseSession(IClientSessionHandle? session = null)
        {
            CanDispose = session == null;
            Session = session ?? DatabaseManager.GetNewSession().Result;
        }

        /*
         * Transactions
         */
        public bool StartTransaction()
        {
            if (DatabaseManager.UseTransactions() && !Session.IsInTransaction)
            {
                Session.StartTransaction();
                return true;
            }
            return false;
        }

        public async Task Commit(bool commit)
        {
            if (Session.IsInTransaction && commit)
            {
                await Session.CommitTransactionAsync();
            }
        }

        public async Task Rollback(bool rollback)
        {
            if (Session.IsInTransaction && rollback)
            {
                await Session.AbortTransactionAsync();
            }
        }

        /*
         * Dispose
         */
        public void Dispose()
        {
            if (CanDispose)
            {
                ForceDispose();
                GC.SuppressFinalize(this);
            }
        }

        public void ForceDispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
        }
    }
}
