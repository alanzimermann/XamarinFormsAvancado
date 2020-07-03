﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace App16.Models
{
    public class Profissional : RealmObject
    {
        [PrimaryKey]
        public string Nome { get; set; }
        public string Img { get; set; }
        public string Descricao { get; set; }
        public string Especialidade { get; set; }

        public IList<Comentario> Comentarios { get; }

    }
}
