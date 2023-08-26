using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Upload.Models;
using Upload.Repositorio;

namespace Upload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        UsuarioRepositorio repositorio = new UsuarioRepositorio();
        // UploadRepositorio _respt = new UploadRepositorio();
        UploadController _respt = new UploadController();
        EmailController _email = new EmailController();

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Usuario>> Post([FromForm] Usuario usuario){

            try{  
                var arquivo = Request.Form.Files[0];

                usuario.Foto = _respt.Upload(arquivo, "Resources");
                usuario.Nome = Request.Form["Nome"];



                string tituloEmail = "Testando o cadastro dessa desgraca";
                string corpoEmail = System.IO.File.ReadAllText(path: @"Email.html");    
                _email.Email(usuario.Nome.ToString(), corpoEmail,tituloEmail);                

                await repositorio.Post(usuario);
            }catch(Exception){
                throw;
            }
            return usuario;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get(){

            try{
                return await repositorio.Get();
            }catch(Exception){
                throw;
            }
        }
        
    }
}