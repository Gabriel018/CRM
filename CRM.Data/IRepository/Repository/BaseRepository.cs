using MongoDB.Driver;

namespace CRM.Data.IRepository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        public BaseRepository(IMongoDatabase mongoDB, string collectionNanme)
        {
            _collection = mongoDB.GetCollection<TEntity>(collectionNanme);
        }

        public async Task<List<TEntity>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            var result = await _collection.Find(FilterDefinition<TEntity>.Empty).ToListAsync(cancellationToken);

            return result;
        }

        public async Task AdicionaAsync(TEntity entity, CancellationToken cancellation)
        {
            await _collection.InsertOneAsync(entity, options: null, CancellationToken.None);
        }

        public async Task AtualizarAsync(TEntity entity, CancellationToken cancellation)
        {
            await _collection.ReplaceOneAsync(
                filter: Builders<TEntity>.Filter.Eq("_id", entity.GetType().GetProperty("Id")!.GetValue(entity)),
                replacement: entity,
                cancellationToken: cancellation);
        }

        public async Task DeletarAsync(TEntity entity, CancellationToken cancellation)
        {
            await _collection.DeleteOneAsync(filter: Builders<TEntity>.Filter.Eq("_id", entity.GetType().GetProperty("Id")!.GetValue(entity)), cancellationToken: cancellation);
        }
    }
}

