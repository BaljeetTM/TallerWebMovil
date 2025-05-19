using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace APITaller1.src.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile file);
    }
}