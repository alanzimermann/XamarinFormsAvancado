using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Mapas01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-15.8260571, -48.060058), Distance.FromKilometers(1)));
            mapa.MapType = MapType.Street;
            mapa.IsShowingUser = true;

            var cartorio = new Pin() {
                Position = new Position(-15.825906, - 48.0570538),
                Label = "Cartório do 5º Ofício de Registro Civil, Títulos e Documentos e Pessoas Jurídicas do DF",
                Address = "CNA 03, Lote 02, Praça do DI, Taguatinga Norte CNA 3 - Taguatinga, Brasília - DF, 72110-035"
            };

            var pracaDI = new Pin()
            {
                Position = new Position(-15.8265988, - 48.0581059),
                Label = "Praça do DI",
                Address = "St. A Norte QNA CNA - Taguatinga, Brasília - DF, 72110-015"
            };

            GPS gps = new GPS();
            if (gps.IsLocationAvailable())
            {
                Plugin.Geolocator.Abstractions.Position pos = gps.GetCurrentLocation().GetAwaiter().GetResult();

                if(pos != null) {
                    var MyPos = new Pin() {
                        Position = new Position(pos.Latitude, pos.Longitude),
                        Label = "Minha Posição"
                    };

                    mapa.Pins.Add(MyPos);
                }
            }

            mapa.Pins.Add(cartorio);
            mapa.Pins.Add(pracaDI);

            MapContainer.Children.Add(mapa);
        }
    }
}
