using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace App12.Modelo
{
    public class Pessoa
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo Nome é obrigatório!")]
        [StringLength(60, MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = "MSG_E01", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        [EmailAddress(ErrorMessageResourceName = "MSG_E02", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "MSG_E01", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        [CPF(ErrorMessageResourceName = "MSG_E02", ErrorMessageResourceType = typeof(Lang.Mensagem))]
        public string CPF { get; set; }
    }
}
