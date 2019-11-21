using DemoMenuItem.Models;
using IESCRM_Mobiles;
using IESCRM_Mobiles.Models;
using IESCRM_Mobiles.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoMenuItem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerInformation : ContentPage
    {
      public static  string customerid = string.Empty;
        public CustomerInformation()
        {
            InitializeComponent();
            CheckPermission();

        }
        public CustomerInformation(string customervalue)
        {
            InitializeComponent();
            CheckPermission();
            btnNotesc.Clicked += BtnNotesc_Clicked;
            btnNotesc.Source = "addnewnotes2";          
            btndetail.Source = "r.png";         
            btngenral.Source = "d.png";           
            btnnotes.Source = "r.png";           
            btnshiping.Source = "r.png";            
            btncontact.Source = "r.png";           
            btnjobs.Source = "r.png";           
            btnpay.Source = "r.png";
            customerid = customervalue;
            Getdatagenral(customerid);
            
        } 
        public CustomerInformation(string customervalue, bool isload = false)
        {
            InitializeComponent();
            CheckPermission();
            btnNotesc.Clicked += BtnNotesc_Clicked;
            btnNotesc.Source = "addnewnotes2";       
            customerid = customervalue;
            isload = false;
            Notesshideshow();
            Getdatagenral(customerid);
            
        }    
        

        public void CheckPermission()
        {
            string rolename = Application.Current.Properties["RoleName"].ToString();
            if (rolename == "Administrator" || rolename == "Sales Rep")
            {
                btnNotesc.IsVisible = true;
            }            
        }
        void Ontappedpayemtninfo(object sender, EventArgs e)
        {
            Paymentshideshow();
        }
        public void Paymentshideshow()
        {
            tabpymentinfo.IsVisible = true;
            btnpay.Source = "r.png";
            tabjobs.IsVisible = false;
            btnjobs.Source = "r.png";
            tabcontect.IsVisible = false;
            btncontact.Source = "r.png";
            tabshiping.IsVisible = false;
            btnshiping.Source = "r.png";
            tabnotes.IsVisible = false;
            btnnotes.Source = "r.png";
            tabdetails.IsVisible = false;
            btndetail.Source = "r.png";
            tabgenral.IsVisible = false;
            btngenral.Source = "r.png";
            Getdatapaymentingo(customerid);
        }
        void OnTappedjobs(object sender, EventArgs e)
        {
            Jobshideshow();
        }
        public void Jobshideshow()
        {
            tabjobs.IsVisible = true;
            btnjobs.Source = "d.png";
            tabcontect.IsVisible = false;
            btncontact.Source = "r.png";
            tabshiping.IsVisible = false;
            btnshiping.Source = "r.png";
            tabnotes.IsVisible = false;
            btnnotes.Source = "r.png";
            tabdetails.IsVisible = false;
            btndetail.Source = "r.png";
            tabgenral.IsVisible = false;
            btngenral.Source = "r.png";
            tabpymentinfo.IsVisible = false;
            btnpay.Source = "r.png";
            Getdatajobs(customerid);
        }
    
        void OnTappeddetails(object sender, EventArgs e)
        {           
            Detailshideshow();
        }
        public void Detailshideshow()
        {
            tabdetails.IsVisible = true;
            btndetail.Source = "d.png";
            tabgenral.IsVisible = false;
            btngenral.Source = "r.png";
            tabnotes.IsVisible = false;
            btnnotes.Source = "r.png";
            tabjobs.IsVisible = false;
            btnjobs.Source = "r.png";
            tabcontect.IsVisible = false;
            btncontact.Source = "r.png";
            tabshiping.IsVisible = false;
            btnshiping.Source = "r.png";
            Getdatadetails(customerid);
        }
        void OnTappedgen(object sender, EventArgs e)
        {
            Genralshideshow();
        }

        public void Genralshideshow()
        {
            tabgenral.IsVisible = true;
            btngenral.Source = "d.png";
            tabdetails.IsVisible = false;
            btndetail.Source = "r.png";
            tabnotes.IsVisible = false;
            btnnotes.Source = "r.png";
            tabjobs.IsVisible = false;
            btnjobs.Source = "r.png";
            tabcontect.IsVisible = false;
            btncontact.Source = "r.png";
            tabshiping.IsVisible = false;
            btnshiping.Source = "r.png";
            tabpymentinfo.IsVisible = false;
            btnpay.Source = "r.png";
            Getdatagenral(customerid);
        }
        void OnTappeddnot(object sender, EventArgs e)
        {
            Notesshideshow();
        }
        public void Notesshideshow()
        {
            tabnotes.IsVisible = true;
            btnnotes.Source = "d.png";
            tabdetails.IsVisible = false;
            btndetail.Source = "r.png";
            tabgenral.IsVisible = false;
            btngenral.Source = "r.png";
            tabjobs.IsVisible = false;
            btnjobs.Source = "r.png";
            tabcontect.IsVisible = false;
            btncontact.Source = "r.png";
            tabshiping.IsVisible = false;
            btnshiping.Source = "r.png";
            tabpymentinfo.IsVisible = false;
            btnpay.Source = "r.png";
            Getdatanotes(customerid);
        }
        void OnTappeddShi(object sender, EventArgs e)
        {
            Shipshideshow();
        }
        public void Shipshideshow()
        {
            tabshiping.IsVisible = true;
            btnshiping.Source = "d.png";
            tabnotes.IsVisible = false;
            btnnotes.Source = "r.png";
            tabdetails.IsVisible = false;
            btndetail.Source = "r.png";
            tabgenral.IsVisible = false;
            btngenral.Source = "r.png";
            tabjobs.IsVisible = false;
            btnjobs.Source = "r.png";
            tabcontect.IsVisible = false;
            btncontact.Source = "r.png";
            tabpymentinfo.IsVisible = false;
            btnpay.Source = "r.png";
            Getdatashiping(customerid);
        }
        void OnTappedcontect(object sender, EventArgs e)
        {
            Cotehideshow();
        }
        public void Cotehideshow()
        {
            tabcontect.IsVisible = true;
            btncontact.Source = "d.png";
            tabshiping.IsVisible = false;
            btnshiping.Source = "r.png";
            tabnotes.IsVisible = false;
            btnnotes.Source = "r.png";
            tabdetails.IsVisible = false;
            btndetail.Source = "r.png";
            tabgenral.IsVisible = false;
            btngenral.Source = "r.png";
            tabjobs.IsVisible = false;
            btnjobs.Source = "r.png";
            tabpymentinfo.IsVisible = false;
            btnpay.Source = "r.png";
            Getdatacontect(customerid);
        }
        public void Alltabhideshow()
        {
            tabcontect.IsVisible = false;
            btncontact.Source = "r.png";
            tabshiping.IsVisible = false;
            btnshiping.Source = "r.png";
            tabnotes.IsVisible = false;
            btnnotes.Source = "r.png";
            tabdetails.IsVisible = false;
            btndetail.Source = "r.png";
            tabgenral.IsVisible = false;
            btngenral.Source = "r.png";
            tabjobs.IsVisible = false;
            btnjobs.Source = "r.png";
            tabpymentinfo.IsVisible = false;
            btnpay.Source = "r.png";
        }
        protected async void Getdatagenral(string customerid)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",customerid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetCustomersGenralDetails?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<getcustomerdetails> customerdetailslist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getcustomerdetails>>(userinfodata.ToString());
                if (customerdetailslist.Count > 0)
                { 
                    txtcustname.Text = Convert.ToString(customerdetailslist[0].CustomerName);
                    txtaddress.Text = Convert.ToString(customerdetailslist[0].Address_1);
                    txtemail.Text = Convert.ToString(customerdetailslist[0].Email);
                    txtphonegen.Text = Convert.ToString(customerdetailslist[0].Phone_1);
                    txtwebsitegen.Text = Convert.ToString(customerdetailslist[0].website);
                    txtfax.Text = Convert.ToString(customerdetailslist[0].Fax);
                    txtcountry.Text = Convert.ToString(customerdetailslist[0].CountryName);
                    txtprovince.Text = Convert.ToString(customerdetailslist[0].ProvinceName);
                    txtzipcode.Text = Convert.ToString(customerdetailslist[0].PostalCode);
                    txtcity.Text = Convert.ToString(customerdetailslist[0].City);
                    bool ischeck = Convert.ToBoolean(customerdetailslist[0].IsActive);
                    if (ischeck == true)
                    {
                        chkgenischeck.IsChecked = true;
                    }
                    else
                    {
                        chkgenischeck.IsChecked = false;
                    }
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
                this.IsBusy = false;
            }
        }
        protected async void Getdatadetails(string customerid)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",customerid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetCustomersDetailsTab?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<getcustdetailstab> customerdetailslist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getcustdetailstab>>(userinfodata.ToString());
                if (customerdetailslist.Count > 0)
                {
                    salester.Text = Convert.ToString(customerdetailslist[0].SalesTerritory);
                    Salesrep1.Text = Convert.ToString(customerdetailslist[0].SalesRep);
                    ytdsale.Text = Convert.ToString(customerdetailslist[0].YTDSales);
                    adjustcomm.Text = Convert.ToString(customerdetailslist[0].AdjustedComission);
                    gstnum.Text = Convert.ToString(customerdetailslist[0].gstnumber);
                    hstnum.Text = Convert.ToString(customerdetailslist[0].hstnumber);
                    paymentteam.Text = Convert.ToString(customerdetailslist[0].PaymentTerm);
                    currency1.Text = Convert.ToString(customerdetailslist[0].Currency);
                    custtype.Text = Convert.ToString(customerdetailslist[0].CustomerType);
                    txtnote1.Text = Convert.ToString(customerdetailslist[0].Notes);                   
                }
                this.IsBusy = false;
            }
            catch (Exception )
            {
                this.IsBusy = false;
            }
        }
        protected async void Getdatacontect(string customerid)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",customerid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetCustomerContact?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<getcontectdetails> contectdetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getcontectdetails>>(userinfodata.ToString());
                if (contectdetails.Count > 0)
                {
                    txtcontactname.Text = Convert.ToString(contectdetails[0].ContactName);
                    txtphone.Text = Convert.ToString(contectdetails[0].PhoneNumber);
                    txtemailcont.Text = Convert.ToString(contectdetails[0].ContactEmail);
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
                this.IsBusy = false;
            }
        }
        protected async void Getdatajobs(string customerid)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",customerid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetCustomerJobs?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();

                List<getjobsdetails> jobsdetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getjobsdetails>>(userinfodata.ToString());
                if (jobsdetails.Count > 0)
                {
                    jobsview.ItemsSource = jobsdetails;
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
                this.IsBusy = false;
            }
        }
        protected async void Getdatanotes(string customerid)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",customerid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetCustomernotes?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();

                List<getnotesdetails> notestdetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getnotesdetails>>(userinfodata.ToString());
                if (notestdetails.Count > 0)
                {
                  
                    notesview.ItemsSource = notestdetails;
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
                this.IsBusy = false;
            }
        }
        protected async void Getdatashiping(string customerid)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",customerid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetCustomerShippingAddress?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<getshipingaddetails> shipingdetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getshipingaddetails>>(userinfodata.ToString());
                if (shipingdetails.Count > 0)
                {
                    txtcotectship.Text = Convert.ToString(shipingdetails[0].ContactName);
                    txtemailship.Text = Convert.ToString(shipingdetails[0].Email);
                    txtcityshiping.Text = Convert.ToString(shipingdetails[0].City);
                    txtaddressship.Text = Convert.ToString(shipingdetails[0].Address_Line_1);

                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
               
                this.IsBusy = false;
            }
        }

        protected async void Getdatapaymentingo(string customerid)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("CustomerId",customerid),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetCustomerPayment?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<getdetailsofpaymentinfo> customerpaymementinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getdetailsofpaymentinfo>>(userinfodata.ToString());
                if (customerpaymementinfo.Count > 0)
                {
                    namecard.Text = Convert.ToString(customerpaymementinfo[0].NameOnCard);
                    cardtype.Text = Convert.ToString(customerpaymementinfo[0].CreditCard);
                    expdate.Text = Convert.ToString(customerpaymementinfo[0].ExpiryDate);
                    bool ischeck = Convert.ToBoolean(customerpaymementinfo[0].IsActive);
                    if (ischeck == true)
                    {
                        Txtstatus.IsVisible = true;
                        Txtstatus.IsChecked = true;
                    }
                    else
                    {
                        Txtstatus.IsVisible = false;
                        Txtstatus.IsChecked = false;
                    }
                }
                else
                {
                    Txtstatus.IsVisible = false;
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
                Txtstatus.IsVisible = false;
                this.IsBusy = false;
            }
        }
        private void Btnbackbutton_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new CustInfo();
        }
        private void BtnNotesc_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AddNotes(customerid, "");
        }

    }
}