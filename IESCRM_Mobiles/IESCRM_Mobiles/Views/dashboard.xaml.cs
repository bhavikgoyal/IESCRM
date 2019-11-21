using IESCRM_Mobiles;
using IESCRM_Mobiles.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoMenuItem.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class dashboard : ContentPage
	{
		public dashboard ()
		{
			InitializeComponent ();
            btnlogout.Clicked += Btnlogout_Clicked;
            Circleinfo.Clicked += Circleinfo_Clicked;
            CircleWork.Clicked += CircleWork_Clicked;
            user.Text = "Welcome: " + Convert.ToString(Application.Current.Properties["username"]);
        }

        private void CircleWork_Clicked(object sender, EventArgs e)
        {
 
                
          
                App.Current.MainPage = new orderlist();
            
        }

        private void Circleinfo_Clicked(object sender, EventArgs e)
        {
     
         
         
             App.Current.MainPage = new CustInfo();
           
        }

        private void Btnlogout_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.MainPage = new login();
        }
    }
}