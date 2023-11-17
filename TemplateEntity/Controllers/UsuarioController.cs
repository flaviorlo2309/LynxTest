using Domain;
using Domain.Dto;
using Domain.Entity;
using Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemplateEntity.Controllers.Base;

namespace Laudo_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        IConfiguration _configuration;
        private IUsuarioRepository _usuario { get; set; }
        private ILogger<UsuarioEntity> Logger { get; }
        public UsuarioController(IConfiguration configuration,IUsuarioRepository usuario, ILogger<UsuarioEntity> logger)
        {
            _usuario = usuario;
            _configuration = configuration;
            Logger = logger;
        }

        [HttpPost("GetUsuarioByLogin")]
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
        public async Task<bool> GetValidUser([FromBody] UsuarioFilter dados)
        {
            Logger.LogInformation($"Validando usupario");
            var result = await _usuario.ValidaUser(dados.Nome,dados.Psw);
            return result;
        }
    }
}
