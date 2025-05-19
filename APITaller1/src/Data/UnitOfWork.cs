using APITaller1.src.Data;
using APITaller1.src.Interfaces;
using APITaller1.src.Repositories;

namespace APITaller1.src.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Users = new UserRepository(_context);

        }

        public IProductRepository Products { get; }
        public IUserRepository Users { get; }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}