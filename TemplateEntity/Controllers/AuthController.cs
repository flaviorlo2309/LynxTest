using Abp.Domain.Repositories;
using Domain;
using Domain.Dto;
using Domain.Entity;
using Infraestructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TemplateEntity.Controllers.Base;

namespace FutebolAPI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        IConfiguration configuration;
        private IUsuarioRepository _usuario { get; set; }
        public AuthController(IConfiguration configuration, IUsuarioRepository usuario)
        {
            this.configuration = configuration;
            _usuario = usuario;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 200)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 204)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 400)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 401)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 403)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 404)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 429)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 500)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 503)]
        [ProducesResponseType(typeof(BaseResponse<UsuarioEntity>), 504)]
        public async Task<IActionResult> Auth([FromBody] UsuarioFilter usuario)
        {
            IActionResult response = Unauthorized();
            if(_usuario != null)
            {
                var result = await _usuario.ValidaUser(usuario.Nome,usuario.Psw);

                if (result == true)
                {
                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:key"].ToString()) ;
                    var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature
                        );

                    var subject = new ClaimsIdentity(new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, usuario.Nome),
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Nome),
                    });

                    var expires = DateTime.UtcNow.AddMinutes(15);

                    var tokenDescriptor= new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }
            return response;
        }
    }
}
