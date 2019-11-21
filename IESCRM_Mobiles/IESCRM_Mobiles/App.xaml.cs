using DemoMenuItem;
using DemoMenuItem.Views;
using IESCRM_Mobiles.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace IESCRM_Mobiles
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (App.Current.Properties.ContainsKey("username") && App.Current.Properties.ContainsKey("password"))
            {
                MainPage = new dashboard();  //dashboard
            }
            else
            {
                MainPage = new login();  //login
            }


        }
        protected override void OnStart()
        {

        }
        protected override void OnSleep()
        {

        }
        protected override void OnResume()
        {

        }
    }
}
