using System.Threading.Tasks;

using APITaller1.src.Interfaces;

namespace APITaller1.src.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IProductRepository Products { get; }
        Task<int> CompleteAsync();
    }
}