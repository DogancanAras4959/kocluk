using kocluk.DOMAIN;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.ImageData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;

namespace kocluk.SERVICES.Services
{
    public class ImageService : IImageService
    {
        private const int ThumbnailWdith = 300;
        private const int FullScreenWidth = 1000;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly koclukdb _data;

        public ImageService(koclukdb data, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _data = data;
        }

        public Task<List<string>> GetAllImages() => _data.imagefile.Select(i => i.Folder + "/thumbnail_" + i.Id + ".jpg").ToListAsync();

        public Task<byte[]?> GetFullScreen(string id) => _data.imagedatas.Where(x => x.Id.ToString() == id).Select(x => x.FullscreenContent).FirstOrDefaultAsync();

        public Task<byte[]?> GetThumbnail(string id) => _data.imagedatas.Where(x => x.Id.ToString() == id).Select(x => x.ThumbnailContent).FirstOrDefaultAsync();

        public async Task Process(IEnumerable<ImageInputModel> images)
        {
            var totalImages = await _data.imagefile.CountAsync();

            var task = images.Select(image => Task.Run(async () =>
            {
                try
                {
                    using var imageResult = await Image.LoadAsync(image.Content);

                    var id = Guid.NewGuid();
                    var path = $"/images/{totalImages % 1000}/";
                    var name = $"{id}.jpg";

                    var storage = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{path}".Replace("/", "\\"));

                    if (!Directory.Exists(storage))
                    {
                        Directory.CreateDirectory(storage);
                    }

                    await SaveImage(imageResult, $"original_{name}", storage, imageResult.Width);
                    await SaveImage(imageResult, $"fullscreen_{name}", storage, FullScreenWidth);
                    await SaveImage(imageResult, $"thumbnail_{name}", storage, ThumbnailWdith);

                    var data = _serviceScopeFactory
                    .CreateScope()
                    .ServiceProvider
                    .GetRequiredService<koclukdb>();

                    data.imagefile.Add(new ImageFile
                    {
                        Id = id,
                        Folder = path
                    });

                    await data.SaveChangesAsync();
                }
                catch
                {

                }
            })).ToList();

            await Task.WhenAll(task);
        }
        public async Task<string> ProcessFile(ImageInputModel images)
        {
            var totalImages = await _data.imagefile.CountAsync();

            try
            {
                using var imageResult = await Image.LoadAsync(images.Content);

                var id = Guid.NewGuid();
                var path = $"/images/{totalImages % 1000}/";
                var name = $"{id}.jpg";

                var storage = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{path}".Replace("/", "\\"));

                if (!Directory.Exists(storage))
                {
                    Directory.CreateDirectory(storage);
                }

                await SaveImage(imageResult, $"original_{name}", storage, imageResult.Width);
                await SaveImage(imageResult, $"fullscreen_{name}", storage, FullScreenWidth);
                await SaveImage(imageResult, $"thumbnail_{name}", storage, ThumbnailWdith);

                var data = _serviceScopeFactory
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<koclukdb>();

                data.imagefile.Add(new ImageFile
                {
                    Id = id,
                    Folder = path
                });

                await data.SaveChangesAsync();

                return path + $"thumbnail_{name}";
            }
            catch (Exception)
            {
                return "";
            }
        }
     
        private async Task SaveImage(Image image, string name, string path, int resizeWidth)
        {
            var width = image.Width;
            var height = image.Height;

            if (width > resizeWidth)
            {
                height = (int)((double)resizeWidth / width * height);
                width = resizeWidth;
            }

            image.Mutate(i => i.Resize(new Size(width, height)));
            image.Metadata.ExifProfile = null;

            await image.SaveAsJpegAsync($"{path}/{name}", new JpegEncoder
            {
                Quality = 75,
            });

        }

    }
}
