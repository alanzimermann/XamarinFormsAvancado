using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App11.Traducao;

namespace App11
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Lang.AppLang.Culture = DependencyService.Get<ILocale>().GetCurrentCultureInfo();
            LblMsg.Text = Lang.AppLang.MSG_01;
        }
    }
}
