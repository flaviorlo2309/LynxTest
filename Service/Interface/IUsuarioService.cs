using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioEntity>> GetAllUsuario();
        Task<UsuarioEntity> GetUsuarioId(int id);
        Task<bool> UpdateUser(UsuarioEntity dados);
        Task<bool> AddDadosUserAsync(UsuarioEntity dados);
        Task<bool> DeleteUsuarioId(int id);
    }
}
