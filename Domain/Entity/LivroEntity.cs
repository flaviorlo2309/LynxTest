﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Livros")]
    public class LivroEntity
    {
        [Key]
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public string Isbn { get; set; }
    }
}
