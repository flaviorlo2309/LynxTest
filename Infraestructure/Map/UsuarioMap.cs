using Dapper.FluentMap.Dommel.Mapping;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Map
{
    public class UsuarioMap : DommelEntityMap<UsuarioEntity>
    {
        public UsuarioMap()
        {
            ToTable("tb_usuario", "DbFutebol");
            //Map(p => p.Iduser).ToColumn("Iduser").IsKey();
            //Map(p => p.Usuario).ToColumn("Usuario");
            //Map(p => p.Password).ToColumn("Password");
            //Map(p => p.Aleatorio).ToColumn("Aleatorio");
            //Map(p => p.Statususer).ToColumn("Statususer");
            //Map(p => p.Idperfil).ToColumn("Idperfil");

        }
    }
}
