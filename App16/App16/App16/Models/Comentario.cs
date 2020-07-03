using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace App16.Models
{
    public class Comentario : RealmObject
    {
        public Profissional profissional { get; set; }
        public string Autor { get; set; }
        public DateTimeOffset Data { get; set; }
        public string Descricao { get; set; }
    }
}
