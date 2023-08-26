using System;
using System.IO;
using System.Net.Http.Headers;
using API_TechCycle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TechCycle.Controllers
{
    public class UploadController : ControllerBase
    {
        [HttpPost]
        [DisableRequestSizeLimit]
        public string Upload(IFormFile arquivo, string nomePasta)
        {
            try
            {
                var pastaParaSalvar = Path.Combine(Directory.GetCurrentDirectory(), nomePasta);

                if(arquivo.Length > 0)
                {
                    var nomeArquivo = ContentDispositionHeaderValue.Parse(arquivo.ContentDisposition).FileName.Trim('"');
                    var caminhPasta = Path.Combine(pastaParaSalvar, nomeArquivo);
                    var salvarPasta = Path.Combine(nomePasta, nomeArquivo);

                    using(var stream = new FileStream(caminhPasta, FileMode.Create))
                    {
                        arquivo.CopyTo(stream);
                    }

                    return nomeArquivo;
                }
                else
                {
                    return "";
                }
            }
            catch(Exception)
            {
                throw;
            }


            // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);

            // if(file.Length > 0)
            // {
            //     var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //     var fullPath = Path.Combine(pathToSave, fileName);


            //     using(var stream = new FileStream(fullPath, FileMode.Create))
            //     {
            //         file.CopyTo(stream);
            //     }

            //     return fileName;
            // }
            // else
            // {
            //     return "";
            // }
        }
    }
}