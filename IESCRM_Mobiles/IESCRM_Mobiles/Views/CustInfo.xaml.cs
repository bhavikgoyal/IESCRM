using DemoMenuItem.Models;
using IESCRM_Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoMenuItem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustInfo : ContentPage
    {
        List<customerlist> Items;
        //private HttpClient _client = new HttpClient();
        public CustInfo()
        {
            Items = new List<customerlist>();
            InitializeComponent();
            OnGetList();
            searchingdata.Clicked += Searchingdata_ClickedAsync;
        }
        private  void Searchingdata_ClickedAsync(object sender, EventArgs e)
        {
            searchstack.IsVisible = true;
            statgen.IsVisible = false;
            searcust.Focus();
        }
        private void Btnbackbutton_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new dashboard();
        }
        private void backinsearch_Clicked(object sender, EventArgs e)
        {
            searchstack.IsVisible = false;
            statgen.IsVisible = true;
            OnGetList();
        }
        protected async void OnGetList()
        {
            try
            {
                this.IsBusy = true;
                var userid = Convert.ToString(Application.Current.Properties["username"]);
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("LoginId",userid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/Getcustomerslist?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<customerlist> surveyList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<customerlist>>(userinfodata.ToString());
                if (surveyList.Count >= 0)
                {
                    lstCustomerInfo.ItemsSource = surveyList;
                    Items = surveyList;
                    activity.IsEnabled = false;
                    activity.IsVisible = false;
                }
                else
                {
                    App.Current.MainPage = new dashboard();
                    this.IsBusy = false;
                    activity.IsEnabled = false;
                    activity.IsVisible = false;
                    return;
                }
            }
            catch (Exception)
            {
                this.IsBusy = false;
                activity.IsEnabled = false;
                activity.IsVisible = false;
                return;
            }
        }
        private async void btnviewclicl(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                var id = btn.ClassId;
                App.Current.MainPage = new CustomerInformation(id);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Information", ex.Message, "OK");
            }
        }
        private void Searchcust(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                lstCustomerInfo.ItemsSource = Items;
            }
            else
            {
                lstCustomerInfo.ItemsSource = Items.Where(x => x.CustomerName.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }
        private void searchingdata_Clicked(object sender, EventArgs e)
        {

        }
        private void searcust_Focused(object sender, FocusEventArgs e)
        {
            searcust.Focus();
        }
    }
}
