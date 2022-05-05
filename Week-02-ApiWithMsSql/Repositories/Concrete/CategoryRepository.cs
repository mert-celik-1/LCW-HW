using ApiWithMsSql.DbOperations;
using ApiWithMsSql.Entities;
using ApiWithMsSql.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ApiWithMsSql.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext
        {
            get { return _context as AppDbContext; }
        }

    }
}
