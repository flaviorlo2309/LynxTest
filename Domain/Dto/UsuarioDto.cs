using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Psw { get; set; }
        public int Aleatorio { get; set; }
        public int Idperfil { get; set; }
        public int StaUser { get; set; }
        public int IdCliente { get; set; }
        public bool NewUser { get; set; }
    }

    public class UsuarioFilter
    {
        public string Nome { get; set;}
        public string Psw { get; set; }

    }
}
