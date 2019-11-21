//using DemoMenuItem.Views;
using DemoMenuItem.Views;
using IESCRM_Mobiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IESCRM_Mobiles.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWorkNotes : ContentPage
    {
        public static string JobOrderNumber = string.Empty;
        public AddWorkNotes()
        {
            InitializeComponent();
        }
        public AddWorkNotes(string workordervalue, bool isload = false)
        {
            InitializeComponent();
            JobOrderNumber = workordervalue;
            isload = false;
            txtenternote1.Focus();
        }
        private void Btnbacknotes_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new WorkorderInformation(JobOrderNumber, false);
        }
        private void Btnnotecancel_Clicked(object sender, EventArgs e)
        {
            txtenternote1.Text = string.Empty;
        }
        private void Btnsaveadmin_Clicked(object sender, EventArgs e)
        {
            //string adminnotes_txt;
            try
            {
                //adminnotes_txt = txtenternote1.Text;

                if (txtenternote1.Text == string.Empty)
                {
                    DisplayAlert("Error", "Please Insert Notes", "Ok");
                    txtenternote1.Focus();
                    return;
                }
                else
                {
                    InsertAdminnotes(JobOrderNumber, txtenternote1.Text, App.Current.Properties["username"].ToString());
                    DisplayAlert("Alert", "Successfull Save Note", "Ok");
                    txtenternote1.Text = "";
                    txtenternote1.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async void InsertAdminnotes(string WOrkOrderNumber, string AdminNotes, string AdminNotesById)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WOrkOrderNumber",WOrkOrderNumber),
                    new KeyValuePair<string,string>("AdminNotes",AdminNotes),
                    new KeyValuePair<string,string>("AdminNotesById",AdminNotesById),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/InsertWorkorderadminNotes?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var adminnotedata = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
                throw ex;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            txtenternote1.Focus();
        }
    }
}