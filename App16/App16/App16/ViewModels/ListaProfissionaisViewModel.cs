using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using App16.Models;
using App16.Database;

namespace App16.ViewModels
{
    public class ListaProfissionaisViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private List<Profissional> _listProf;
        public List<Profissional> ListaProf
        {
            get { return _listProf; }
            set { SetProperty(ref _listProf, value); }
        }
        
        public DelegateCommand<Profissional> ItemProfissionalTappedCommand { get; set; }

        public ListaProfissionaisViewModel(INavigationService navigationService)
        {
            ListaProf = ProfissionalDB.GetListProf();
            ItemProfissionalTappedCommand = new DelegateCommand<Profissional>(ItemProfissional);
            _navigationService = navigationService;
        }

        private void ItemProfissional(Profissional prof)
        {
            NavigationParameters param = new NavigationParameters();
            param.Add("profissional", prof);
            _navigationService.NavigateAsync("DetalheProfissional", param);
        }
    }
}
