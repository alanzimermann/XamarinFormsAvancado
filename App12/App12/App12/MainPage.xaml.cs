using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App12.Modelo;
using System.ComponentModel.DataAnnotations;

namespace App12
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnSalvar.Clicked += delegate
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = TxtNome.Text;
                pessoa.Email = TxtEmail.Text;
                pessoa.CPF = TxtCPF.Text;

                var ListaRes = new List<ValidationResult>();
                var Contexto = new ValidationContext(pessoa);
                Validator.TryValidateObject(pessoa, Contexto, ListaRes, true);

                if (ListaRes.Count > 0)
                {
                    LblMsg.Text = string.Empty;
                    LblMsg.TextColor = Color.Red;

                    foreach (var x in ListaRes)
                    {
                        LblMsg.Text += string.Format(x.ErrorMessage, x.MemberNames) + "\n";
                    }
                }
                else
                {
                    LblMsg.Text = "OK";
                    LblMsg.TextColor = Color.Green;
                }
            };
        }
    }
}
