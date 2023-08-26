using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Upload.Controllers
{
    public class UploadController : ControllerBase
    {

        public string Upload(IFormFile arquivo, string img){

            var pastaSalvar = Path.Combine (Directory.GetCurrentDirectory (), img);

            if (arquivo.Length > 0) {
                    var fileName = ContentDispositionHeaderValue.Parse (arquivo.ContentDisposition).FileName.Trim ('"');
                    var fullPath = Path.Combine (pastaSalvar, fileName);

                    using (var stream = new FileStream (fullPath, FileMode.Create)) {
                        arquivo.CopyTo (stream);
                    }

                    return fileName;
                } else {
                    return "";
                }
        }
        
    }
}