using Prism.Unity;
using App18.Views;
using Xamarin.Forms;
using System;

namespace App18
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        
        protected override void OnInitialized()
        {
            InitializeComponent();
            
            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }
        
        public static void NavegarParaInicial(params string[] paramentros)
        {
            App.Current.MainPage = new Inicial(paramentros);
        }
        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Inicial>();
        }
    }
}
