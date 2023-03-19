using Les_Birds.Models;

namespace Les_Birds.Services
{
    public class ImageService
    {
        private readonly PathServicecs pathServicecs;
        public ImageService(PathServicecs pathServicecs) { 
        this.pathServicecs = pathServicecs;
        }

        public async Task<Image> UploadAsync(Image image)
        {
            var uploadsPath = pathServicecs.GetUploadsPath();

            var imageFile = image.File;
            var imageFileName = GetRandomFileName(imageFile.FileName);
            var imageUploadPath = Path.Combine(uploadsPath, imageFileName);
            
            using (var fs = new FileStream(imageUploadPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fs);
            }

            image.Name = imageFile.FileName;
            image.Path = pathServicecs.GetUploadsPath(imageFileName, withWebRootPath: false);
            return image;
        }

        private string GetRandomFileName(string filename)
        {
            return Guid.NewGuid() + Path.GetExtension(filename);
        }
    }
}
