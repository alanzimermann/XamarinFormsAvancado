using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using App16.Models;

namespace App16.Database
{
    public class ProfissionalDB
    {
        public static List<Profissional> GetListProf()
        {
            return new List<Profissional>(Realm.GetInstance().All<Profissional>());
        }
    }
}
