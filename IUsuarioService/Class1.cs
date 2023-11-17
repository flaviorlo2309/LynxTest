using Domain.Models;

namespace IUsuarioService
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<UsuarioModel>> GetUsuario();
    }
}