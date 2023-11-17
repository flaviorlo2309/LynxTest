using Domain.Dto;
using Domain.Entity;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Response
{
    public class LivroRepository : BaseRepository<LivroEntity>, ILivroRepository
    {
        public LivroRepository(ILoggerFactory logger, App_Context dbcontext) : base(logger, dbcontext)
        {
        }

        public async Task<bool> AddDadosLivro(LivroDto dados)
        {
            var livro = new LivroEntity
            {
                Descricao = dados.Descricao,
                Autor=dados.Autor,
                Isbn=dados.Isbn,
                Titulo=dados.Titulo,
            };

            var result = await InsertAsync(livro);
            return result;
        }

        public async Task<bool> DeleteLivroId(long id)
        {
            var result = await DeleteAsync(id);
            return result;
        }

        public async Task<IEnumerable<LivroEntity>> GetAllLivros()
        {
            var result = await GetAllAsync();
            return result;
        }

        public async Task<LivroEntity> GetLivroById(long id)
        {
            var result = await GetByIdAsync(id);
            return result;
        }

        public async Task<bool> UpDateLivro(LivroEntity dados)
        {
            var result = await UpdateAsync(dados);
            return result;
        }
    }
}
