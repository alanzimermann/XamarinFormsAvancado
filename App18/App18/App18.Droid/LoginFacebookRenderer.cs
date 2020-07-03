using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Newtonsoft.Json;
using Xamarin.Auth;

using App18.Droid;
using App18.Views;

[assembly:ExportRenderer(typeof(LoginFacebook), typeof(LoginFacebookRenderer))]
namespace App18.Droid
{
    public class LoginFacebookRenderer : PageRenderer
    {
        public LoginFacebookRenderer()
        {
            //Usando o OAuth(Xamarin.Auth)
            var oauth = new OAuth2Authenticator(
                clientId: "1278399355605621",
                scope: "email",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
            );

            oauth.Completed += async (sender, args) => {
                if( args.IsAuthenticated)
                {
                    //Acesso aos dados - Token de Acesso
                    var token = args.Account.Properties["access_token"].ToString();

                    var requisicao = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=name,email"), null, args.Account);
                    var resposta = await requisicao.GetResponseAsync();

                    dynamic obj = JsonConvert.DeserializeObject( resposta.GetResponseText() );

                    var Nome = obj.name.ToString();

                    var Email = obj.email.ToString();

                    App.NavegarParaInicial(Nome, Email);

                }
                else
                {
                    App.NavegarParaInicial("Login rejeitado");
                }
            };




            //API do Android - Xamarin.Android;
            var activity = this.Context as Activity;

            activity.StartActivity(oauth.GetUI(activity));
        }
    }
}