using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App17
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LblWelcome.FontFamily = Device.OnPlatform(
                "Lily of the Valley_Personal_Use",
                "LilyoftheValley.ttf#Lily of the Valley_Personal_Use",
                "Assets/Fonts/LilyoftheValley.ttf#Lily of the Valley_Personal_Use"
            );
        }
    }
}
