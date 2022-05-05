using ApiWithMsSql.DbOperations;
using ApiWithMsSql.Repositories.Abstract;
using System.Threading.Tasks;

namespace ApiWithMsSql.Repositories.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
   
        private  CategoryRepository _categoryRepository;
        private  ProductRepository _productRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }



        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);
        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);



        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
