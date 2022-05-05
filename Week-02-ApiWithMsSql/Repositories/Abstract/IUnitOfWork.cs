using System.Threading.Tasks;

namespace ApiWithMsSql.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }


        Task CommitAsync();

        void Commit();
    }
}
