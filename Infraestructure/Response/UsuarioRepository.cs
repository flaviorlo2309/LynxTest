using Domain.Entity;
using Infraestructure.Context;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace Infraestructure.Response
{
    public class UsuarioRepository :BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        
       
        public UsuarioRepository(ILoggerFactory logger, App_Context _Context) : base(logger,_Context)
        {
          
        }

        public async Task<UsuarioEntity> GetIdUsuario(int id)
        {
            var result = await GetByIdAsync(id);
            return result;
        }

        public async Task<bool> DeleteUserId(int id)
        {
            var result = await DeleteAsync(id);
            return result;
        }

        //
        public async Task<IEnumerable<UsuarioEntity>> GetAllUsuario()
        {
            var result = await GetAllAsync();
            return result;
        }

        public async Task<bool> UpDateUsuario(UsuarioEntity dados)
        {
            var result= await  UpdateAsync(dados);
            return result;
        }

        public async Task<bool> AddDadosuser(UsuarioEntity dados)
        {
            var result = await InsertAsync(dados);
            return result;
        }


        public async Task<bool> ValidaUser(string usuario, string senha)
        {
            var dados= await GetUsuarioByLoginPsw(usuario);
            var pswcripto = CalcularHash(senha + dados.Aleatorio); 
            if ( dados.Psw == pswcripto)
            {
                //var token=
                return true;
            }
            else
            {
                return false;
            }
               
        }


        private string CalcularHash(string input)
        {
            // Primeiro passo, calcular o MD5 hash a partir da string
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Segundo passo, converter o array de bytes em uma string haxadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
