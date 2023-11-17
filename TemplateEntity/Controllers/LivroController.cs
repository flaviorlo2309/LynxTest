using Domain.Dto;
using Domain;
using Domain.Entity;
using Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TemplateEntity.Controllers.Base;

namespace Template_API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LivroController : BaseController
    {
        private readonly ILivroRepository _livro;
        private ILogger<LivroEntity> Logger { get; }
        public LivroController(ILivroRepository livro, ILogger<LivroEntity> logger)
        {
            _livro= livro;
            Logger = logger;
        }
        [HttpPost("AddLivros")]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroDto>), 504)]
        public async Task<bool> AddLivros([FromBody] LivroDto dados)
        {
            var result = await _livro.AddDadosLivro(dados);
            return result;
        }



        [HttpGet("GetLivros")]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 504)]
        public async Task<IEnumerable<LivroEntity>> GetAllLivros()
        {            
            var result = await _livro.GetAllLivros();
            return result;
        }

        [HttpGet("GetLivroById")]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 504)]
        public async Task<LivroEntity> GetLivroById(long Id)
        {            
            var result = await _livro.GetLivroById(Id);
            return result;
        }

        [HttpPut("UPdateLivro")]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 504)]
        public async Task<bool> GetUPdateLivro([FromBody] LivroEntity dados)
        {
            var result = await _livro.UpDateLivro(dados);
            return result;
        }

        [HttpDelete("DeleteLivro")]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 200)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 204)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 400)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 401)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 403)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 404)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 429)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 500)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 503)]
        [ProducesResponseType(typeof(BaseResponse<LivroEntity>), 504)]
        public async Task<bool> DeleteLivro(long Id)
        {
            var result = await _livro.DeleteLivroId(Id);
            return result;
        }
    }
}
