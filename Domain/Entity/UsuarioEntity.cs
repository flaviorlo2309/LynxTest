using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("tb_usuario")]
    public class UsuarioEntity
    {
        [Key]
        public int IdUser { get; set; }
        public string Nome { get; set; }
        public string Psw { get; set; }
        public int Aleatorio { get; set; }
        public int Idperfil { get; set; }
        public int StaUser { get; set; }
        public int IdCliente { get; set; }
        public bool NewUser { get; set; }

    }
}
