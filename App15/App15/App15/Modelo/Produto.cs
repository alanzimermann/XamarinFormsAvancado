using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Realms;


namespace App15.Modelo
{
    public class Produto : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Item { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Range(1, 999)]
        public int? Quantidade { get; set; }
    }
}
