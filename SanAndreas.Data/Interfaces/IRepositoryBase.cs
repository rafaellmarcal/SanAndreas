namespace SanAndreas.Data.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity instance);

        void Atualizar(TEntity instance);
    }
}
