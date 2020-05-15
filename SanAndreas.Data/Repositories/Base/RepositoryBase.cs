using SanAndreas.Data.Interfaces;

namespace SanAndreas.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public void Adicionar(TEntity instance)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar(TEntity instance)
        {
            throw new System.NotImplementedException();
        }
    }
}
