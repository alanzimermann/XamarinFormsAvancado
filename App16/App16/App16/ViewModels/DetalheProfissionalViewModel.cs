using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using App16.Models;

namespace App16.ViewModels
{
    public class DetalheProfissionalViewModel : BindableBase, INavigatingAware
    {
        private Profissional _profissional;
        public Profissional Profissional
        {
            get { return _profissional; }
            set { SetProperty(ref _profissional, value); }
        }


        private List<Comentario> _comentarios;
        public List<Comentario> Comentarios
        {
            get { return _comentarios; }
            set { SetProperty(ref _comentarios, value); }
        }
        

        public DetalheProfissionalViewModel()
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("profissional"))
            {
                Profissional = parameters.GetValue<Profissional>("profissional");

                Comentarios = App16.Database.ComentarioDB.GetListComent(Profissional);
            }
        }
    }
}
