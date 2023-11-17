using Domain.Dto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface ILivroRepository : IBaseRepository<LivroEntity>
    {
        Task<IEnumerable<LivroEntity>> GetAllLivros();
        Task<LivroEntity> GetLivroById(long id);
        Task<bool> UpDateLivro(LivroEntity dados);
        Task<bool> AddDadosLivro(LivroDto dados);
        Task<bool> DeleteLivroId(long id);
    }
}
