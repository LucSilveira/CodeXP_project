using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Upload.Repositorio
{
    public class UploadRepositorio
    {

        public string Upload (IFormFile arquivo, string img) {

            var pathToSave = Path.Combine (Directory.GetCurrentDirectory (), img);

            if (arquivo.Length > 0) {
                var fileName = ContentDispositionHeaderValue.Parse (arquivo.ContentDisposition).FileName.Trim ('"');
                var fullPath = Path.Combine (pathToSave, fileName);

                using (var stream = new FileStream (fullPath, FileMode.Create)) {
                    arquivo.CopyTo (stream);
                }                    

                return fullPath;
            } else {
                return null;
            }
        }           
        
    }
}