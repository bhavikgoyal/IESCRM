using DemoMenuItem.Views;
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
    public partial class AddNotes : ContentPage
    {
        public static string  customerid  = string.Empty;
        public static  string jobid = string.Empty;
        public AddNotes()
        {
            InitializeComponent();
        }
        public AddNotes(string customervalue ,string jobnotes)
        {
            InitializeComponent();
            customerid = customervalue;
            jobid = jobnotes;
        }
        private void Btnbacknotes1_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new CustomerInformation(customerid ,false);
        }
        private void Btncleartext_Clicked(object sender, EventArgs e)
        {
            txtenternote.Text = string.Empty;
        }
        private void Txtenternote_Focused(object sender, FocusEventArgs e)
        {
            txtenternote.Focus();
        }
        private void Btnsavenote_Clicked(object sender, EventArgs e)
        {
            //string notes_txt;
            try
            {
                if(txtenternote.Text == string.Empty)
                {
                    DisplayAlert("Error", "Please Insert Notes", "Ok");
                    txtenternote.Text = "";
                    txtenternote.Focus();
                    return;
                }
                else
                {
                    Insertnotes(customerid, txtenternote.Text, App.Current.Properties["username"].ToString());
                    DisplayAlert("Alert", "Successfull Save Note", "Ok");
                    txtenternote.Text = "";
                    txtenternote.Focus();
                }                                                             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected async void Insertnotes(string CustomerId, string Notes, string NotesEnteredByUserId)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",CustomerId),
                    new KeyValuePair<string,string>("Notes",Notes),
                    new KeyValuePair<string,string>("NotesEnteredByUserId",NotesEnteredByUserId),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/InsertCustomerNotes?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var notesdata = await response.Content.ReadAsStringAsync();
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
            txtenternote.Focus();
        }

        private void btnnotecancel_Clicked(object sender, EventArgs e)
        {

        }
    }
}