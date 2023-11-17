using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioEntity>
    {
         Task<IEnumerable<UsuarioEntity>> GetAllUsuario();
         Task<UsuarioEntity> GetIdUsuario(int id);
         Task<bool> UpDateUsuario(UsuarioEntity dados);
        Task<bool> AddDadosuser(UsuarioEntity dados);
        Task<bool> DeleteUserId(int id);
        Task<bool> ValidaUser(string usuario, string senha);
    }
}
