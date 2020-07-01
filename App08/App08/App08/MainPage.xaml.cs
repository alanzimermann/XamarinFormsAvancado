using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App08
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            // Gesture
            //Tap - Toque/Click
            //Pinch - Pinça - Galeria de Imagens
            //Pan - Arrastar/Desenhar

            PanGestureRecognizer pan = new PanGestureRecognizer();
            pan.PanUpdated += PanGestureRecognizer_Pan;
            MyLabel.GestureRecognizers.Add(pan);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            count++;
            //DisplayAlert("Tapped", "Label tocada/clicada: " + count, "OK");

            //MyBox.TranslateTo(200, 350, 1000, Easing.BounceOut);
            //MyBox.ScaleTo(2, 1000);
            //MyBox.FadeTo(0.5, 1000);
            //MyBox.RotateTo(45, 1000, Easing.SpringOut);

            Animation anim = new Animation(v => MyBox.WidthRequest = v, 50, 100);
            anim.Commit(this, "animação", 16, 1000);
        }

        private void PanGestureRecognizer_Pan(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Running)
            {
                Rectangle rect = new Rectangle(e.TotalX, e.TotalY, 200, 25);

                AbsoluteLayout.SetLayoutBounds(MyLabel, rect);
                AbsoluteLayout.SetLayoutFlags(MyLabel, AbsoluteLayoutFlags.None);
            }
        }
    }
}
