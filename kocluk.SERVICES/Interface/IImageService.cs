using kocluk.SERVICES.Dtos.ImageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IImageService
    {
        Task Process(IEnumerable<ImageInputModel> images);
        Task<string> ProcessFile(ImageInputModel images);

        Task<byte[]> GetThumbnail(string id);
        Task<byte[]> GetFullScreen(string id);

        Task<List<string>> GetAllImages();

    }
}
