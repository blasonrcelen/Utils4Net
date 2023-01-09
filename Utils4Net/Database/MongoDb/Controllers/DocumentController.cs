using MongoDB.Driver;
using System.Diagnostics;

namespace Utils4Net.Database.MongoDB.Controllers
{
    public class DocumentController<T, K> : DatabaseSession
    {
        public readonly IMongoCollection<T> Collection;

        public DocumentController(string collection, IClientSessionHandle? session = null) : base(session)
        {
            if (string.IsNullOrWhiteSpace(collection))
            {
                throw new ArgumentException(nameof(collection) + " is not defined");
            }
            Collection = DatabaseManager.GetDatabase().GetCollection<T>(collection);
        }

        public DocumentController(string collection, DatabaseSession session) : base(session)
        {
            if (string.IsNullOrWhiteSpace(collection))
            {
                throw new ArgumentException(nameof(collection) + " is not defined");
            }
            Collection = DatabaseManager.GetDatabase().GetCollection<T>(collection);
        }

        public DocumentController(IMongoCollection<T> collection, IClientSessionHandle? session = null) : base(session)
        {
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        public DocumentController(IMongoCollection<T> collection, DatabaseSession session) : base(session)
        {
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }

        /*
         * Insert
         */
        public virtual async Task Insert(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            bool commit = StartTransaction();
            try
            {
                await Collection.InsertOneAsync(Session, model);
                await Commit(commit);
            }
            catch
            {
                try
                {
                    await Rollback(commit);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                throw;
            }
        }

        /*
         * Update
         */
        public virtual async Task<long> Update(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            if (update == null)
            {
                throw new ArgumentNullException(nameof(update));
            }

            bool commit = StartTransaction();
            try
            {
                long updated = (await Collection.UpdateManyAsync(Session, filter, update)).ModifiedCount;
                await Commit(commit);
                return updated;
            }
            catch
            {
                try
                {
                    await Rollback(commit);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                throw;
            }
        }

        public virtual async Task<long> Update(string filterField, object? filterValue, UpdateDefinition<T> update)
        {
            if (string.IsNullOrWhiteSpace(filterField))
            {
                throw new ArgumentException("is not defined", nameof(filterField));
            }
            return await Update(Builders<T>.Filter.Eq(filterField, filterValue), update);
        }

        public virtual async Task<bool> Update(K _id, UpdateDefinition<T> update)
        {
            if (_id == null)
            {
                throw new ArgumentNullException(nameof(_id));
            }
            return await Update("_id", _id, update) > 0;
        }

        /*
         * Delete
         */
        public virtual async Task<long> Delete(FilterDefinition<T> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            bool commit = StartTransaction();
            try
            {
                long deleted = (await Collection.DeleteManyAsync(Session, filter)).DeletedCount;
                await Commit(commit);
                return deleted;
            }
            catch
            {
                try
                {
                    await Rollback(commit);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                throw;
            }
        }

        public virtual async Task<long> Delete(string filterField, object? filterValue)
        {
            if (string.IsNullOrWhiteSpace(filterField))
            {
                throw new ArgumentException("is not defined", nameof(filterField));
            }
            return await Delete(Builders<T>.Filter.Eq(filterField, filterValue));
        }

        public virtual async Task<bool> Delete(K _id)
        {
            if (_id == null)
            {
                throw new ArgumentNullException(nameof(_id));
            }
            return await Delete("_id", _id) > 0;
        }

        /*
         * Find
         */
        public virtual async Task<T> FindOne(FilterDefinition<T>? filter = null, ProjectionDefinition<T>? projection = null)
        {
            filter ??= Builders<T>.Filter.Empty;
            IFindFluent<T, T> findFluent = Collection.Find(Session, filter);

            if (projection != null)
            {
                findFluent = findFluent.Project<T>(projection);
            }

            return await findFluent.FirstOrDefaultAsync();
        }

        public virtual async Task<T> FindOne(string filterField, object? filterValue, ProjectionDefinition<T>? projection = null)
        {
            if (string.IsNullOrWhiteSpace(filterField))
            {
                throw new ArgumentException("is not defined", nameof(filterField));
            }
            return await FindOne(Builders<T>.Filter.Eq(filterField, filterValue), projection);
        }

        public virtual async Task<T> FindOne(K _id, ProjectionDefinition<T>? projection = null)
        {
            if (_id == null)
            {
                throw new ArgumentNullException(nameof(_id));
            }
            return await FindOne("_id", _id, projection);
        }

        public virtual async Task<List<T>> FindMany(FilterDefinition<T>? filter = null, ProjectionDefinition<T>? projection = null, SortDefinition<T>? sort = null, int limit = 0, int skip = 0)
        {
            filter ??= Builders<T>.Filter.Empty;
            IFindFluent<T, T> findFluent = Collection.Find(Session, filter);

            if (projection != null)
            {
                findFluent = findFluent.Project<T>(projection);
            }

            if (sort != null)
            {
                findFluent = findFluent.Sort(sort);
            }

            if (skip > 0)
            {
                findFluent = findFluent.Skip(skip);
            }

            if (limit > 0)
            {
                findFluent = findFluent.Limit(limit);
            }

            return await findFluent.ToListAsync();
        }

        public virtual async Task<List<T>> FindMany(string filterField, object? filterValue, ProjectionDefinition<T>? projection = null, SortDefinition<T>? sort = null, int limit = 0, int skip = 0)
        {
            if (string.IsNullOrWhiteSpace(filterField))
            {
                throw new ArgumentException("is not defined", nameof(filterField));
            }
            return await FindMany(Builders<T>.Filter.Eq(filterField, filterValue), projection, sort, limit, skip);
        }

        /*
         * Cursor
         */
        public virtual async Task<IAsyncCursor<T>> Cursor(FilterDefinition<T>? filter = null, ProjectionDefinition<T>? projection = null, SortDefinition<T>? sort = null, int limit = 0, int skip = 0, CancellationToken cancellationToken = default)
        {
            filter ??= Builders<T>.Filter.Empty;
            IFindFluent<T, T> findFluent = Collection.Find(Session, filter);

            if (projection != null)
            {
                findFluent = findFluent.Project<T>(projection);
            }

            if (sort != null)
            {
                findFluent = findFluent.Sort(sort);
            }

            if (skip > 0)
            {
                findFluent = findFluent.Skip(skip);
            }

            if (limit > 0)
            {
                findFluent = findFluent.Limit(limit);
            }

            return await findFluent.ToCursorAsync(cancellationToken);
        }

        /*
         * Count
         */
        public virtual async Task<long> Count(FilterDefinition<T>? filter = null)
        {
            filter ??= Builders<T>.Filter.Empty;
            return await Collection.CountDocumentsAsync(Session, filter);
        }

        public virtual async Task<long> Count(string filterField, object? filterValue)
        {
            if (string.IsNullOrWhiteSpace(filterField))
            {
                throw new ArgumentException("is not defined", nameof(filterField));
            }
            return await Count(Builders<T>.Filter.Eq(filterField, filterValue));
        }

        /*
         * Exists
         */
        public virtual async Task<bool> Exists(FilterDefinition<T>? filter = null)
        {
            return await Count(filter) > 0;
        }

        public virtual async Task<bool> Exists(string filterField, object? filterValue)
        {
            if (string.IsNullOrWhiteSpace(filterField))
            {
                throw new ArgumentException("is not defined", nameof(filterField));
            }
            return await Exists(Builders<T>.Filter.Eq(filterField, filterValue));
        }

        public virtual async Task<bool> Exists(K _id)
        {
            if (_id == null)
            {
                throw new ArgumentNullException(nameof(_id));
            }
            return await Exists("_id", _id);
        }
    }
}
