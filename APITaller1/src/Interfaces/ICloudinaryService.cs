using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace APITaller1.src.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile file);
    }
}
