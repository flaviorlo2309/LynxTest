using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class LivroDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public string Isbn { get; set; }
    }

    public class LivroFilter
    {
        public long Id { get; set;}
       // public string Isbn { get; set; }
    }
}
