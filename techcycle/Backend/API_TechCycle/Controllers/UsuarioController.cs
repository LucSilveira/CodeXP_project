using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.Repositorio;
using API_TechCycle.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCycle_Back.ViewModels;

namespace API_TechCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();
        UploadController _uploadController = new UploadController();
        EmailController _emailController = new EmailController();

        /// <summary>
        /// Tem a função de trazer uma lista de usuário.
        /// </summary>
        /// <returns>Retorna uma lista de usuário</returns>

        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                return await repositorio.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar um usuário na lista.
        /// </summary>
        /// <param name="id">Passa um id de um usuário</param>
        /// <returns>Retorna um usuário</returns>

        // [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            try
            {
                Usuario usuario = await repositorio.Get(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("aprovacao/{status}")]
        public async Task<ActionResult<List<Usuario>>> GetPorStatus(string status)
        {
            try
            {
                var listaDeUsuario = await repositorio.GetPorStatus(status);
                if(listaDeUsuario == null)
                {
                    return BadRequest();
                }
                return listaDeUsuario;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de cadastrar um novo usuário na lista.
        /// </summary>
        /// <param name="usuario">Passa um usuário.</param>
        /// <returns>Retorna um usuário.</returns>

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromForm]CadUsuarioViewModel usuario)
        {
            Usuario usosExistente = await repositorio.verificacaoDeUso(usuario.email, usuario.loginUsuario);
            if(usosExistente != null)
            {
                return BadRequest("Desculpe, mas parece que este email ou o userName já está em uso");
            }
            try
            {
                Usuario newUsuario = new Usuario();

                var hashSenha = new HashSenha(SHA256.Create());

                if(Request.Form.Files.Count > 0)
                {
                    var arquivo = Request.Form.Files[0];
                    var caminhoPasta = @"Resources\Usuario\";

                    newUsuario.LoginUsuario = usuario.loginUsuario;
                    newUsuario.Senha = hashSenha.HasheandoSenha(usuario.senha);
                    newUsuario.NomeCompleto = usuario.nomeCompleto;

                    string tituloEmail = "Aguardando aprovação!";
                    string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                    _emailController.Email(usuario.email, corpoEmail, tituloEmail);
                    newUsuario.Email = usuario.email;

                    newUsuario.FotoUsuario =  _uploadController.Upload(arquivo, caminhoPasta);
                    newUsuario.Departamento = usuario.departamento;
                    newUsuario.TipoDeUsuario = "Funcionario";
                    newUsuario.StatusAprovacao = "Aguardo";
                }
                else
                {
                    var arquivo = string.Empty;

                    if(Request.Form.Files.Count == 0)
                    {
                        arquivo = "semfoto.jpg";
                    }

                    newUsuario.LoginUsuario = usuario.loginUsuario;
                    newUsuario.Senha = hashSenha.HasheandoSenha(usuario.senha);
                    newUsuario.NomeCompleto = usuario.nomeCompleto;
                    
                    string tituloEmail = "Aguardando aprovação!";
                    string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                    _emailController.Email(usuario.email, corpoEmail, tituloEmail);
                    newUsuario.Email = usuario.email;

                    newUsuario.FotoUsuario =  arquivo;
                    newUsuario.Departamento = usuario.departamento;
                    newUsuario.TipoDeUsuario = "Funcionario";
                    newUsuario.StatusAprovacao = "Aguardo";
                }
                await repositorio.Post(newUsuario);

                return newUsuario;
            }catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função de buscar na lista um usuário.
        /// </summary>
        /// <param name="usuario">Passa um usuário para identificação.</param>
        /// <returns>Retorna um usuário.</returns>

        // [Authorize] /*Porque o proprio usuario pode atualizar seu perfil */
        [HttpPut("{id}")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Usuario>> Put(int id, [FromForm]AltUsuarioViewModel usuario)
        {
            try
            {
                var usuarioExistente = await repositorio.Get(id);
                if(usuarioExistente == null)
                {
                    return NotFound("O usuário informado não exite!");
                }

                var usuarioAlterado = verificacaoAlteracao(usuarioExistente, usuario);
                var usuarioComAlteracao = await repositorio.Put(usuarioAlterado);

                return usuarioComAlteracao;
            }
            catch(DbUpdateConcurrencyException)
            {
                var usuarioValidacao = await repositorio.Get(id);

                if(usuarioValidacao == null)
                {
                    return NotFound("Usuario não encontrado");
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<Usuario>> GetPorEmail(string email)
        {
            try
            {
                var validarUsuarioComEmail = await repositorio.GetEmailUsuario(email);
                if(validarUsuarioComEmail == null)
                {
                    return NotFound("Email não encontrado!");
                }

                string caracteres = "techcycle123456789";
                string senhaGerada = "";
                Random misturarCaracteres = new Random();
                for(var senha = 0; senha < 5; senha++)
                {
                    senhaGerada += caracteres.Substring(misturarCaracteres.Next(0, caracteres.Length - 1), 1);
                }

                string tituloEmail = ($"Sua nova senha solicitada: {senhaGerada}");
                string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                _emailController.Email(validarUsuarioComEmail.Email, corpoEmail, tituloEmail);


                var hashSenha = new HashSenha(SHA256.Create());
                validarUsuarioComEmail.Senha = hashSenha.HasheandoSenha(senhaGerada);
                await repositorio.Put(validarUsuarioComEmail);
                return validarUsuarioComEmail;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tem a função excluír um usuário da lista.
        /// </summary>
        /// <param name="id">Passa um id do usuário.</param>
        /// <returns>Retorna um usuário</returns>

        /*O proprio usuario poderia excluir sua conta */
        // [Authorize] 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            try
            {
                Usuario usuario = await repositorio.Get(id);
                if(usuario == null)
                {
                    return NotFound("Usúario não encontrado!");
                }
                await repositorio.Delete(usuario);
                return usuario;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private Usuario verificacaoAlteracao(Usuario usuario, AltUsuarioViewModel alteracao)
        {
            if(alteracao.nomeCompleto == null && alteracao == null)
            {
                usuario.NomeCompleto = usuario.NomeCompleto;
            }
            else if(alteracao.nomeCompleto != null && usuario.NomeCompleto != alteracao.nomeCompleto){
                usuario.NomeCompleto = alteracao.nomeCompleto;
            }

            
            if(alteracao.loginUsuario == null && alteracao == null)
            {
                usuario.LoginUsuario = usuario.LoginUsuario;
            }
            else if(alteracao.loginUsuario != null && usuario.LoginUsuario != alteracao.loginUsuario)
            {
                usuario.LoginUsuario = alteracao.loginUsuario;
            }


            if(alteracao.email == null && alteracao == null)
            {
                usuario.Email = usuario.Email;
            }
            else if(alteracao.email != null && usuario.Email != alteracao.email)
            {
                string tituloEmail = "Aguardando aprovação!";
                string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                _emailController.Email(alteracao.email, corpoEmail, tituloEmail);
                usuario.Email = alteracao.email;
            }

            var hashSenha = new HashSenha(SHA256.Create());
            if(alteracao.senha == null && alteracao == null)
            {
                usuario.Senha = usuario.Senha;
            }
            else if(alteracao.senha != null && usuario.Senha != alteracao.senha)
            {
                usuario.Senha = hashSenha.HasheandoSenha(alteracao.senha);

                string tituloEmail = ($"Sua senha foi alterada para {alteracao.senha}!");
                string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                _emailController.Email(usuario.Email, corpoEmail, tituloEmail);
            }

            if(alteracao.departamento == null && alteracao == null)
            {
                usuario.Departamento = usuario.Departamento;
            }
            else if(alteracao.departamento != null && usuario.Departamento != alteracao.departamento)
            {
                usuario.Departamento = alteracao.departamento;
            }


            if(alteracao.tipoDeUsuario == null && alteracao == null)
            {
                usuario.TipoDeUsuario = usuario.TipoDeUsuario;
            }
            else if(alteracao.tipoDeUsuario != null && usuario.TipoDeUsuario != alteracao.tipoDeUsuario)
            {
                usuario.TipoDeUsuario = alteracao.tipoDeUsuario;
            }


            if(alteracao.statusAprovacao == null && alteracao == null)
            {
                usuario.StatusAprovacao = usuario.StatusAprovacao;
            }
            else if(alteracao.statusAprovacao != null && usuario.StatusAprovacao != alteracao.statusAprovacao)
            {
                usuario.StatusAprovacao = alteracao.statusAprovacao;

                if(usuario.StatusAprovacao == "Aprovado")
                {
                    string tituloEmail = "Você foi aprovado!";
                    string corpoEmail = System.IO.File.ReadAllText(path : @"emails\parabens.html");
                    _emailController.Email(usuario.Email, corpoEmail, tituloEmail);
                }
            }

            if(Request.Form.Files.Count > 0)
            {
                var arquivo = Request.Form.Files[0];
                var caminhoPasta = @"Resources\Usuario\";
                usuario.FotoUsuario = _uploadController.Upload(arquivo, caminhoPasta);
            }

            return usuario;
        }
    }
}
 