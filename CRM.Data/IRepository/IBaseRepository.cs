
namespace CRM.Data.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        Task<List<TEntity>> ObterTodosAsync(CancellationToken cancellationToken);
        Task AdicionaAsync(TEntity entity, CancellationToken cancellation);
        Task AtualizarAsync(TEntity entity, CancellationToken cancellation);
        Task DeletarAsync(TEntity entity, CancellationToken cancellation);
    }
}
