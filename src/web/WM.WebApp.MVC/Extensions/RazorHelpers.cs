using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Razor;

namespace WM.WebApp.MVC.Extensions
{
    public static class RazorHelpers
    {
   

        public static string FormatoMoeda(this RazorPage page, string valor)
        {
            return FormatoMoeda(decimal.Parse(valor));
        }

        private static string FormatoMoeda(decimal valor)
        {
            return string.Format(Thread.CurrentThread.CurrentCulture, "{0:C}", valor);
        }

    
    }
}