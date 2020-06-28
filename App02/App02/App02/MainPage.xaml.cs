using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App02
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ListaFuncionarios.ItemsSource = GetFuncionarios();
        }

        private List<Grupo> GetFuncionarios()
        {
            return new List<Grupo>
            {
                new Grupo("Presidente", "CEO", "Presidente da empresa")
                {
                    new Pessoa { Nome = "José", IsObrigatorio = true, RankEficiencia = 8 }
                },
                new Grupo("Diretores", "Dir.", "Diretor da empresa")
                {
                    new Pessoa { Nome = "João", IsObrigatorio = false },
                    new Pessoa { Nome = "Maria", IsObrigatorio = true, RankEficiencia = 8 }
                },
                new Grupo("Gerentes", "Ger.", "Gerente da empresa")
                {
                    new Pessoa { Nome = "Felipe", IsObrigatorio = true, RankEficiencia = 7 },
                    new Pessoa { Nome = "Judas", IsObrigatorio = false }
                },
                new Grupo("Funcionários", "Func.", "Funcionários da empresa")
                {
                    new Pessoa { Nome = "Felipe", IsObrigatorio = false },
                    new Pessoa { Nome = "Judas", IsObrigatorio = false },
                    new Pessoa { Nome = "José", IsObrigatorio = false },
                    new Pessoa { Nome = "João", IsObrigatorio = true, RankEficiencia = 6 },
                    new Pessoa { Nome = "Maria", IsObrigatorio = false },
                    new Pessoa { Nome = "Danilo", IsObrigatorio = false },
                    new Pessoa { Nome = "Jéssica", IsObrigatorio = false },
                    new Pessoa { Nome = "Hellen", IsObrigatorio = false },
                    new Pessoa { Nome = "Débora", IsObrigatorio = false },
                }
            };
        }

        public class Grupo : List<Pessoa>
        {
            public string Titulo { get; set; }
            public string TituloCurto { get; set; }
            public string Descricao { get; set; }

            public Grupo(string titulo, string tituloCurto, string descricao)
            {
                this.Titulo = titulo;
                this.TituloCurto = tituloCurto;
                this.Descricao = descricao;
            }
        }

        public class Pessoa
        {
            public string Nome { get; set; }
            public int RankEficiencia { get; set; }
            public bool IsObrigatorio { get; set; }
        }
    }
}
