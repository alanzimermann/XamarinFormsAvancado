using Prism.Unity;
using App16.Views;
using Xamarin.Forms;

namespace App16
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            App16.Database.Massa.CriarMassaDados();
            
            NavigationService.NavigateAsync("NavigationPage/ListaProfissionais");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<ListaProfissionais>();
            Container.RegisterTypeForNavigation<DetalheProfissional>();
        }
    }
}
