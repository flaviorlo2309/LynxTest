using Domain.Entity;
using Dommel;
using Infraestructure.Interfaces;
using Microsoft.Extensions.Logging;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private ILogger<UsuarioEntity> Logger { get; }
        private IUsuarioRepository _usuarioRepository { get; }
        public UsuarioService(ILoggerFactory logger, IUsuarioRepository userRepository)
        {

            _usuarioRepository = userRepository;
            Logger = logger.CreateLogger<UsuarioEntity>();
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAllUsuario()
        {
            var result = await _usuarioRepository.GetAllUsuario();
            return result;
        }

        public async Task<UsuarioEntity> GetUsuarioId(int id)
        {
            var result = await _usuarioRepository.GetIdUsuario(id);
            return result;
        }

        public async Task<bool> UpdateUser(UsuarioEntity dados)
        {
            var result = await _usuarioRepository.UpDateUsuario(dados);
            return result;
        }

        public async Task<bool> AddDadosUserAsync(UsuarioEntity dados)
        {
            var result = await _usuarioRepository.AddDadosuser(dados);
            return result;
        }

        public async Task<bool> DeleteUsuarioId(int id)
        {
            var result = await _usuarioRepository.DeleteUserId(id);
            return result;
        }
       
    }
}
