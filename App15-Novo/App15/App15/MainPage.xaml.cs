using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App15.Modelo;
using System.ComponentModel.DataAnnotations;
using Realms;

namespace App15
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnAdicionar.Clicked += delegate {
                //Validar e Salvar

                Produto produto = new Produto();
                produto.Item = Item.Text;
                produto.Quantidade = int.Parse(Quantidade.Text);

                //Validação
                List<ValidationResult> listRes = new List<ValidationResult>();
                var contexto = new ValidationContext(produto);
                bool valido = Validator.TryValidateObject(produto, contexto, listRes, true);

                if(valido == false)
                {
                    string mensagem = string.Empty;

                    foreach(var res in listRes) {
                        mensagem += res.ErrorMessage + "\n";
                    }
                    DisplayAlert("Erros", mensagem, "OK");
                }
                else
                {
                    //Salva
                    var realm = Realm.GetInstance();

                    if(Id.Text == string.Empty) {
                        #region Produto - Adicionar
                    var produtoFinal = realm.All<Produto>().OrderByDescending(a => a.Id).First();
                    int newId = 1;

                    if (produtoFinal != null)
                    {
                        newId = produtoFinal.Id + 1;
                    }
                    produto.Id = newId;

                    realm.Write(() => {
                        realm.Add(produto);
                    });
                        #endregion
                    }
                    else
                    {
                        #region Produto - Atualizar
                        produto.Id = int.Parse(Id.Text);

                        realm.Write(() =>
                        {
                            realm.Add(produto, true);
                        });
                        #endregion
                    }

                    Id.Text = "";
                    Item.Text = "";
                    Quantidade.Text = "";

                    Lista.ItemsSource = realm.All<Produto>();
                    DisplayAlert("Salvo com sucesso", "Itens no banco de dados:" + realm.All<Produto>().Count(), "OK");
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var realm = Realm.GetInstance();
            Lista.ItemsSource = realm.All<Produto>();
        }

        private void MenuItemExcluir_Clicked(object sender, EventArgs e)
        {
            Produto produto = ((Produto)((MenuItem)sender).CommandParameter);

            var realm = Realm.GetInstance();

            realm.Write(() => { 
                realm.Remove(produto);
            });

            Lista.ItemsSource = realm.All<Produto>();
        }

        private void MenuItemEditar_Clicked(object sender, EventArgs e)
        {
            Produto produto = ((Produto)((MenuItem)sender).CommandParameter);
            
            Id.Text = produto.Id.ToString();
            Item.Text = produto.Item;
            Quantidade.Text = produto.Quantidade.ToString();
        }
    }
}
