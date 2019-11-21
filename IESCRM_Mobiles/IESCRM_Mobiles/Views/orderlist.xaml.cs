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
    public partial class orderlist : ContentPage
    {
        List<Workorderlist> Items;
        //private HttpClient _client = new HttpClient();
        public orderlist()
        {
            Items = new List<Workorderlist>();
            InitializeComponent();
            OnGetworkorderList();
            searchingname.Clicked += Searchingname_Clicked;
        }
        private  void Searchingname_Clicked(object sender, EventArgs e)
        {
            searc.IsVisible = true;
            statgeninf.IsVisible = false;
            searcb.Focus();
        }
        private void Backinsea_Clicked(object sender, EventArgs e)
        {
            searc.IsVisible = false;
            statgeninf.IsVisible = true;
            OnGetworkorderList();
        }
        protected async void OnGetworkorderList()
        {
            try
            {
                this.IsBusy = true;
                var userid = Convert.ToString(Application.Current.Properties);
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>(),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/Getworkorderlist";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<Workorderlist> surveyList1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Workorderlist>>(userinfodata.ToString());
                if (surveyList1.Count >= 0)
                {
                    WorkOrderList.ItemsSource = surveyList1;
                    Items = surveyList1;
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
        private void Bckworkbtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new dashboard();
        }

        private async void Bckworkbtn_Clicked1(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                var id = btn.ClassId;
                App.Current.MainPage = new WorkorderInformation(id);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Information", ex.Message, "OK");
            }
        }
        private void Searcust_Focused(object sender, FocusEventArgs e)
        {
            searcb.Focus();
        }
        private void Searchc(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                WorkOrderList.ItemsSource = Items;
            }
            else
            {
                WorkOrderList.ItemsSource = Items.Where(x => x.JobOrderNumber.StartsWith(e.NewTextValue));
            }
        }
    }
    }
