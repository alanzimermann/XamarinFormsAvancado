using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using App16.Models;

namespace App16.Database
{
    public class ComentarioDB
    {
        public static List<Comentario> GetListComent(Profissional prof)
        {
            return new List<Comentario>(Realm.GetInstance().All<Comentario>().Where(a=>a.profissional == prof));
        }
    }
}
