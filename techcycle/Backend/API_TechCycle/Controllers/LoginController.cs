using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API_TechCycle.Models;
using API_TechCycle.Repositorio;
using API_TechCycle.Utils;
using API_TechCycle.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TechCycle_Back.ViewModels;

namespace API_TechCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        // Chamamos nosso contexto do banco
        TECHCYCLEContext context = new TECHCYCLEContext();
        UsuarioRepositorio repositorio = new UsuarioRepositorio();

        // Definimos uma variável para percorrer nossos métodos com as configurações obtidas no appsettings.json
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Tem a função de fazer um login de um usúario no sistema pela a autentição JWT definindo o nível do acessob.
        /// </summary>
        /// <param name="login">Passa o nome do usúario é a senha.</param>
        /// <returns>Retorna o usúario logado no sistema.</returns>

        // [EnableCors]
        [AllowAnonymous]
        [HttpPost]
        public  IActionResult Login(LoginUsuarioViewModel login)
        {
            IActionResult response = Unauthorized();
            
            var usuario =  autenticarUsuario(login);
            if(usuario != null)
            {
                if(usuario.StatusAprovacao == "Aprovado"){
                var tokenString = gerarJsonWebToken(usuario);
                response = Ok( new { token = tokenString});
                }
            }
            return response;
        }

        private Usuario autenticarUsuario(LoginUsuarioViewModel login)
        {
            var hashSenha = new HashSenha(SHA256.Create());
            var senhaHasheada = hashSenha.HasheandoSenha(login.Senha);

            var usuario = context.Usuario
                .FirstOrDefault(us => (us.LoginUsuario == login.LoginUsuario && us.Senha == senhaHasheada)
                || (us.Email == login.Email && us.Senha == senhaHasheada));

            return usuario;
        }

        private string gerarJsonWebToken(Usuario infoUsuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.NameId, infoUsuario.NomeCompleto),
                new Claim(JwtRegisteredClaimNames.Email, infoUsuario.Email),
                new Claim(ClaimTypes.Role, infoUsuario.TipoDeUsuario),
                new Claim("Role", infoUsuario.TipoDeUsuario),
                new Claim("IdUsuario", infoUsuario.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}