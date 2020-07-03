using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PCLStorage;
namespace App14
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BtnEscrever.Clicked += async(sender, args) =>
            {
                Util.StorageManager.SalvarArquivo("file.txt", Conteudo.Text);
            };

            BtnLerArquivo.Clicked += async (sender, args) =>
            {
                string conteudo = await Util.StorageManager.LerArquivo("file.txt");
                LblConteudoArquivo.Text = conteudo;
            };
        }
    }
}
