using System;
using System.Globalization;
using Xamarin.Forms;
using App11.UWP.Traducao;
using App11.Traducao;

[assembly: Dependency(typeof(Locale_UWP))]
namespace App11.UWP.Traducao
{
    public class Locale_UWP : ILocale
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return new System.Globalization.CultureInfo(
                Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString());
        }

        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            // Do nothing
        }
    }
}