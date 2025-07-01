using eCommerceProject.Models;

namespace eCommerceProject.Services
{
    public class ImageService
    {

        private string _imageFolderPath;

        public ImageService() {
            _imageFolderPath= Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images");
        }

        public string UploadImage(IFormFile image) { 
            var fileName=Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(_imageFolderPath, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                image.CopyTo(stream);
            }

            return filePath;
        }
        public bool Delete(string fileName)
        {
            var filePath = Path.Combine(_imageFolderPath, fileName);
            if (File.Exists(filePath)) {
                System.IO.File.Delete(filePath);
                return true;
            }   
            return false;
        }
    }
}
