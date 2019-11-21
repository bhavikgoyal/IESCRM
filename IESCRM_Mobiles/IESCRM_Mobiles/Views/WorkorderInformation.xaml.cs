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
    public partial class WorkorderInformation : ContentPage
    {
        public static string JobOrderNumber = string.Empty;
        
        public WorkorderInformation(string workordervalue)
        {
            InitializeComponent();
            btnNotesclick.Clicked += BtnNotesclick_Clicked;
            btnNotesclick.Source = "addnewnotes2";            
            btnwork.Source = "d.png";            
            commissiond.Source = "r.png";           
            btpricing.Source = "r.png";            
            btjobnot.Source = "r.png";            
            btadminnot.Source = "r.png";            
            bttechni.Source = "r.png";            
            btshipw.Source = "r.png";            
            //btdocu.Source = "r.png";
            JobOrderNumber = workordervalue;
            GetWorkdatagenral(JobOrderNumber);
        } 
        public WorkorderInformation(string workordervalue,bool isload = false)
        {
            InitializeComponent();
            btnNotesclick.Clicked += BtnNotesclick_Clicked;
            btnNotesclick.Source = "addnewnotes2";
            AdminNoteshideshow();
            JobOrderNumber = workordervalue;
            isload = false;
            GetworkdateAdminnotes(JobOrderNumber);
        }

        private void BtnNotesclick_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new AddWorkNotes(JobOrderNumber,false);
        }

        public void Wrkorderhideshow()
        {
            tabworkordergenral.IsVisible = true;
            btnwork.Source = "d.png";
            tabcommissiondeatils.IsVisible = false;
            commissiond.Source = "r.png";
            tabshippingadress.IsVisible = false;
            btshipw.Source = "r.png";
            tabtechnicians.IsVisible = false;
            bttechni.Source = "r.png";
            tabadminnotes.IsVisible = false;
            btadminnot.Source = "r.png";
            tabjobnotes.IsVisible = false;
            btjobnot.Source = "r.png";
            tabpricing.IsVisible = false;
            btpricing.Source = "r.png";
            //tabadocuments.IsVisible = false;
            //btdocu.Source = "r.png";
            GetWorkdatagenral(JobOrderNumber);
        }

        public void Commissiondeatilhideshow()
        {
            tabcommissiondeatils.IsVisible = true;
            commissiond.Source = "d.png";
            tabworkordergenral.IsVisible = false;
            btnwork.Source = "r.png";
            tabshippingadress.IsVisible = false;
            btshipw.Source = "r.png";
            tabtechnicians.IsVisible = false;
            bttechni.Source = "r.png";
            tabadminnotes.IsVisible = false;
            btadminnot.Source = "r.png";
            tabjobnotes.IsVisible = false;
            btjobnot.Source = "r.png";
            tabpricing.IsVisible = false;
            btpricing.Source = "r.png";
            //tabadocuments.IsVisible = false;
            //btdocu.Source = "r.png";
            Getworkdatacommission(JobOrderNumber);

        }
        
        protected async void Getworkdatacommission(string JobOrderNumber)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WOrkOrderNumber",JobOrderNumber),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetWorkOrderCommission?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();

                List<getWorkorderCommissiondeatil> commdeatil = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkorderCommissiondeatil>>(userinfodata.ToString());
                if (commdeatil.Count > 0)
                {
                    majorreq.Text = Convert.ToString(commdeatil[0].MajorRequired);
                    payrec.Text = Convert.ToString(commdeatil[0].PaymentReceived);
                    if (payrec.Text == "0")
                    {
                        payrec.Text = "NO";
                    }
                    else
                    {
                        payrec.Text = "YES";
                    }
                    paydate.Text = Convert.ToString(commdeatil[0].PaymentDate);

                    
                    string CommBaseValue = Convert.ToString(commdeatil[0].CommBaseValue);
                    decimal CommBaseValues = 0;
                    if (CommBaseValue != "")
                    {
                        CommBaseValues = Math.Round(Convert.ToDecimal(CommBaseValue), 2);
                        commvalue.Text = "$" + CommBaseValues;
                    }
                    else
                    {
                        commvalue.Text = "$0.00";
                    }
                    string CommPercentage = Convert.ToString(commdeatil[0].CommPercentage);
                    if (CommPercentage != "")
                    {
                        commissionper.Text = CommPercentage + "%";
                    }
                    else
                    {
                        commissionper.Text = "%0.00";
                    }
                    string CommissionAmount = Convert.ToString(commdeatil[0].CommissionAmount);
                    decimal CommissionAmounts = 0;
                    if (CommissionAmount != "")
                    {
                        CommissionAmounts = Math.Round(Convert.ToDecimal(CommissionAmount), 2);
                        commamount.Text = "$" + CommissionAmounts;
                    }
                    else
                    {
                        commamount.Text = "$0.00";
                    }
                    commpaid.Text = Convert.ToString(commdeatil[0].CommPaid);
                    if (commpaid.Text == "0")
                    {
                        commpaid.Text = "NO";
                    }
                    else
                    {
                        commpaid.Text = "YES";
                    }
                    commpaiddate.Text = Convert.ToString(commdeatil[0].CommPaidDate);
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
              this.IsBusy = false;
            }
        }
        private void Tabcomminsiondetail1(object sender, EventArgs e)
        {
            Commissiondeatilhideshow();
        }


        public void Pricingdeatilhideshow()
        {
            tabpricing.IsVisible = true;
            btpricing.Source = "d.png";
            tabworkordergenral.IsVisible = false;
            btnwork.Source = "r.png";
            tabshippingadress.IsVisible = false;
            btshipw.Source = "r.png";
            tabtechnicians.IsVisible = false;
            bttechni.Source = "r.png";
            tabadminnotes.IsVisible = false;
            btadminnot.Source = "r.png";
            tabjobnotes.IsVisible = false;
            btjobnot.Source = "r.png";
            tabcommissiondeatils.IsVisible = false;
            commissiond.Source = "r.png";
            //tabadocuments.IsVisible = false;
            //btdocu.Source = "r.png";
            GetworkdatePricing(JobOrderNumber);

        }
        protected async void GetworkdatePricing(string JobOrderNumber)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WOrkOrderNumber",JobOrderNumber),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetWorkOrderPricing?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<getWorkorderPricinginfo> pricingdeatil = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkorderPricinginfo>>(userinfodata.ToString());
                if (pricingdeatil.Count > 0)
                {
                    string CostOfNew = Convert.ToString(pricingdeatil[0].CostOfNew);
                    decimal CostOfNewc = 0;
                    //string CostOfNew = Convert.ToString(pricingdeatil[0].CostOfNew);
                    if (CostOfNew != "")
                    {
                         CostOfNewc = Math.Round(Convert.ToDecimal(CostOfNew), 2);
                        cost.Text = "$" + CostOfNewc;
                    }
                    else
                    {
                        cost.Text = "$0.00";
                    }
                    string Repairsalecharg = Convert.ToString(pricingdeatil[0].Repairsalecharg);
                    decimal Repairsalechargd = 0;
                    //string Repairsalecharg = Convert.ToString(pricingdeatil[0].Repairsalecharg);
                    if (Repairsalecharg != "")
                    {
                         Repairsalechargd = Math.Round(Convert.ToDecimal(Repairsalecharg), 2);
                        repaircharge.Text = "$" + Repairsalechargd;
                    }
                    else
                    {
                        repaircharge.Text ="$0.00";
                    }
                    string DistributorDiscAmt = Convert.ToString(pricingdeatil[0].DistributorDiscAmt);
                    decimal discamount = 0;
                    if (DistributorDiscAmt != "")
                    {
                         discamount = Math.Round(Convert.ToDecimal(DistributorDiscAmt), 2);
                        disdiscount.Text = "$" + discamount;
                    }
                    else
                    {
                        disdiscount.Text = "$0.00";
                    }
                    string DistributorDiscRate = Convert.ToString(pricingdeatil[0].DistributorDiscRate);
                    if (DistributorDiscRate != "")
                    {
                        disrate.Text =  DistributorDiscRate + "%";
                    }
                    else
                    {
                        disrate.Text = DistributorDiscRate;
                    }
                    string RushFee = Convert.ToString(pricingdeatil[0].RushFee);
                    decimal RushFees = 0;
                    //string RushFee = Convert.ToString(pricingdeatil[0].RushFee);
                    if (RushFee != "")
                    {
                         RushFees = Math.Round(Convert.ToDecimal(RushFee), 2);
                        rushfee.Text = "$" + RushFees;
                    }
                    else
                    {
                        rushfee.Text = "$0.00";
                    }
                    string additionalcharge = Convert.ToString(pricingdeatil[0].additionalcharge);
                    if (additionalcharge != "")
                    {
                        addcharge.Text =  additionalcharge + "%";
                    }
                    else
                    {
                        addcharge.Text ="0.00%";
                    }
                    string AdditionalDiscAmount = Convert.ToString(pricingdeatil[0].AdditionalDiscAmount);
                    decimal AdditionalDiscAmountd = 0;
                    //string AdditionalDiscAmount = Convert.ToString(pricingdeatil[0].AdditionalDiscAmount);
                    if (AdditionalDiscAmount != "")
                    {
                        AdditionalDiscAmountd = Math.Round(Convert.ToDecimal(AdditionalDiscAmount), 2);
                        adddiscamount.Text = "$" + AdditionalDiscAmountd;
                       
                    }
                    else
                    {
                         
                        adddiscamount.Text = "$0.00";
                    }
                    string OutSourceRate = Convert.ToString(pricingdeatil[0].OutSourceRate);
                    decimal OutSourceRates = 0;
                    //string OutSourceRate = Convert.ToString(pricingdeatil[0].OutSourceRate);
                    if (OutSourceRate != "")
                    {
                         OutSourceRates = Math.Round(Convert.ToDecimal(OutSourceRate), 2);
                        outsourceprice.Text = "$" + OutSourceRates;
                    }
                    else
                    {
                        outsourceprice.Text = "$0.00";
                    }
                    string QuotePrice = Convert.ToString(pricingdeatil[0].QuotePrice);
                    decimal QuotePriced = 0;
                    //string QuotePrice = Convert.ToString(pricingdeatil[0].QuotePrice);
                    if (QuotePrice != "")
                    {
                         QuotePriced = Math.Round(Convert.ToDecimal(QuotePrice), 2);
                        qouteprice.Text = "$" + QuotePriced;
                    }
                    else
                    {
                        qouteprice.Text = "$0.00";

                    }
                    string discountpr = Convert.ToString(pricingdeatil[0].AdditionalDisc);
                    decimal discountprd = 0;
                    //string discountpr = Convert.ToString(pricingdeatil[0].AdditionalDisc);
                    if (discountpr != "")
                    {
                         discountprd = Math.Round(Convert.ToDecimal(discountpr), 2);
                        discount.Text = "$" + discountprd;
                    }
                    else
                    {
                        discount.Text = "$0.00";

                    }
                    
                    //expences.Text = Convert.ToString(pricingdeatil[0].TotalExpenses);
                    //profitloss.Text = Convert.ToString(pricingdeatil[0].ProfitLossAmount);
                }
                this.IsBusy = false;
                // }

            }
            catch (Exception)
            {
                this.IsBusy = false;
            }
        }
        private void Tabpricing1(object sender, EventArgs e)
        {
            Pricingdeatilhideshow();
        }

        public void Jobnotesdeatilhideshow()
        {
            tabjobnotes.IsVisible = true;
            btjobnot.Source = "d.png";
            tabworkordergenral.IsVisible = false;
            btnwork.Source = "r.png";
            tabshippingadress.IsVisible = false;
            btshipw.Source = "r.png";
            tabtechnicians.IsVisible = false;
            bttechni.Source = "r.png";
            tabadminnotes.IsVisible = false;
            btadminnot.Source = "r.png";
            tabcommissiondeatils.IsVisible = false;
            commissiond.Source = "r.png";
            //tabadocuments.IsVisible = false;
            //btdocu.Source = "r.png";
            tabpricing.IsVisible = false;
            btpricing.Source = "r.png";
            Getworkorderjobnotes(JobOrderNumber);
        }
        
        protected async void Getworkorderjobnotes(string JobOrderNumber)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WOrkOrderNumber",JobOrderNumber),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/Getworkorderjobnotes?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();
                List<getWorkorderPricinginfo> workjobdetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkorderPricinginfo>>(userinfodata.ToString());
                if (workjobdetails.Count > 0)
                {
                    jobsnote.ItemsSource = workjobdetails;
                }
                this.IsBusy = false;
                // }

            }
            catch (Exception)
            {
                this.IsBusy = false;
            }
        }
        private void Tabjobnots1(object sender, EventArgs e)
        {
            Jobnotesdeatilhideshow();
        }
        public void AdminNoteshideshow()
        {
            tabadminnotes.IsVisible = true;
            btadminnot.Source = "d.png";
            tabworkordergenral.IsVisible = false;
            btnwork.Source = "r.png";
            tabshippingadress.IsVisible = false;
            btshipw.Source = "r.png";
            tabtechnicians.IsVisible = false;
            bttechni.Source = "r.png";
            tabjobnotes.IsVisible = false;
            btjobnot.Source = "r.png";
            tabcommissiondeatils.IsVisible = false;
            commissiond.Source = "r.png";
            //tabadocuments.IsVisible = false;
            //btdocu.Source = "r.png";
            tabpricing.IsVisible = false;
            btpricing.Source = "r.png";
            GetworkdateAdminnotes(JobOrderNumber);
        }
        
        protected async void GetworkdateAdminnotes(string JobOrderNumber)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WOrkOrderNumber",JobOrderNumber),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetWorkOrderAdminNotes?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();

                List<getWorkorderAdminNotes> admindetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkorderAdminNotes>>(userinfodata.ToString());
                if (admindetails.Count > 0)
                {
                    adminnotes.ItemsSource = admindetails;
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
             
                this.IsBusy = false;
            }
        }
        private void Tabadminnotes1(object sender, EventArgs e)
        {
            AdminNoteshideshow();
        }

        public void Techniciansdetailshideshow()
        {
            tabtechnicians.IsVisible = true;
            bttechni.Source = "d.png"; 
            tabworkordergenral.IsVisible = false;
            btnwork.Source = "r.png";
            tabshippingadress.IsVisible = false;
            btshipw.Source = "r.png";
            tabadminnotes.IsVisible = false;
            btadminnot.Source = "r.png";
            tabjobnotes.IsVisible = false;
            btjobnot.Source = "r.png";
            tabcommissiondeatils.IsVisible = false;
            commissiond.Source = "r.png";
            //tabadocuments.IsVisible = false;
            //btdocu.Source = "r.png";
            tabpricing.IsVisible = false;
            btpricing.Source = "r.png";
            GetworkdateTechnician(JobOrderNumber);
        }        
        protected async void GetworkdateTechnician(string JobOrderNumber)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WOrkOrderNumber",JobOrderNumber),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetWorkOrderTechnician?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();

                List<getWorkOrderTechnician> atechniciandetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkOrderTechnician>>(userinfodata.ToString());
                if (atechniciandetails.Count > 0)
                {
                    technicians.ItemsSource = atechniciandetails;
                }
                this.IsBusy = false;


            }
            catch (Exception ex) 
            {
                //await DisplayAlert("Error", ex.Message, "ok");
                //Alltabhideshow();
                this.IsBusy = false;
            }
        }
        private void Tabtecnicians1(object sender, EventArgs e)
        {
            Techniciansdetailshideshow();
        }

        public void ShippingAdressdetailshideshow()
        {
            tabshippingadress.IsVisible = true;
            btshipw.Source = "d.png";
            tabworkordergenral.IsVisible = false;
            btnwork.Source = "r.png";
            tabtechnicians.IsVisible = false;
            bttechni.Source = "r.png";
            tabadminnotes.IsVisible = false;
            btadminnot.Source = "r.png";
            tabjobnotes.IsVisible = false;
            btjobnot.Source = "r.png";
            tabcommissiondeatils.IsVisible = false;
            commissiond.Source = "r.png";
            //tabadocuments.IsVisible = false;
            //btdocu.Source = "r.png";
            tabpricing.IsVisible = false;
            btpricing.Source = "r.png";
            GetworkdataShippingadd(JobOrderNumber);


        }
        protected async void GetworkdataShippingadd(string WorkOrderNumber)
        {
            try
            {
                this.IsBusy = true;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WorkOrderNumber",WorkOrderNumber),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetWorkOrderShippingAddress?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();

                List<getWorkOderShippingadd> shippingadddetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkOderShippingadd>>(userinfodata.ToString());
                if (shippingadddetails.Count > 0) 
                {
                    tabshippingadds.ItemsSource = shippingadddetails;
                }
                this.IsBusy = false;
            }
            catch (Exception ex)
            {
                this.IsBusy = false;
            }
        }
        private void Tabshippingadress1(object sender, EventArgs e)
        {
            ShippingAdressdetailshideshow();
        }
        //public void Documentsdetailshideshow()
        //{
        //    tabadocuments.IsVisible = true;
        //    btdocu.Source = "d.png";
        //    tabworkordergenral.IsVisible = false;
        //    btnwork.Source = "r.png";
        //    tabtechnicians.IsVisible = false;
        //    bttechni.Source = "r.png";
        //    tabadminnotes.IsVisible = false;
        //    btadminnot.Source = "r.png";
        //    tabjobnotes.IsVisible = false;
        //    btjobnot.Source = "r.png";
        //    tabcommissiondeatils.IsVisible = false;
        //    commissiond.Source = "r.png";
        //    tabpricing.IsVisible = false;
        //    btpricing.Source = "r.png";
        //    tabshippingadress.IsVisible = false;
        //    btshipw.Source = "r.png";
        //    Getworkdocuments(JobOrderNumber);

        //}
        //private void Tabdocuments1(object sender, EventArgs e)
        //{
        //    Documentsdetailshideshow();
        //}
        //protected async void Getworkdocuments(string JobOrderNumber)
        //{
        //    try
        //    {
        //        this.IsBusy = true;
        //        var formcontent = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string,string>("WOrkOrderNumber",JobOrderNumber),
        //        });
        //        var myHttpClinet = new HttpClient();
        //        string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetWorkOrderDocument?";
        //        var response = await myHttpClinet.PostAsync(url, formcontent);
        //        var userinfodata = await response.Content.ReadAsStringAsync();

        //        List<getWorkOrderDocument> Documentdetail = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkOrderDocument>>(userinfodata.ToString());
        //        if (Documentdetail.Count > 0)
        //        {
        //            tabdoc.ItemsSource = Documentdetail;
        //        }
        //        this.IsBusy = false;
        //    }
        //    catch (Exception)
        //    {
               
        //        this.IsBusy = false;
        //    }
        //}
        private void Btnwork_Clicked(object sender, EventArgs e)
        {

            Wrkorderhideshow();

        }
       
        protected async void GetWorkdatagenral(string WOrkOrderNumber)
        {
            try
            {
                this.IsBusy = true;
                string textunitname = string.Empty;
                var formcontent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string,string>("WOrkOrderNumber",WOrkOrderNumber),
                });
                var myHttpClinet = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetWorkOrderDetails?";
                var response = await myHttpClinet.PostAsync(url, formcontent);
                var userinfodata = await response.Content.ReadAsStringAsync();

                List<getWorkorderDetails> workorderdetailslist = Newtonsoft.Json.JsonConvert.DeserializeObject<List<getWorkorderDetails>>(userinfodata.ToString());
                if (workorderdetailslist.Count > 0)
                {
                    txtcusto.Text = Convert.ToString(workorderdetailslist[0].CustomerName);
                    txtadd.Text = Convert.ToString(workorderdetailslist[0].ProductName);
                    txtmanu.Text = Convert.ToString(workorderdetailslist[0].Manufacturer);
                    txtmo.Text = Convert.ToString(workorderdetailslist[0].ModelNumber);
                    txtserial.Text = Convert.ToString(workorderdetailslist[0].SerialNumber);

                    textunitname = Convert.ToString(workorderdetailslist[0].IsTestUnit);
                    if (textunitname == "false")
                    {
                        txtunitattach.Text = "YES";

                    }
                    else
                    {
                        txtunitattach.Text = "NO";
                    }                    
                    txtcu.Text = Convert.ToString(workorderdetailslist[0].CustomerPO);
                    txtcustref.Text = Convert.ToString(workorderdetailslist[0].CustomerReference);
                    //maxijobno.Text = Convert.ToString(workorderdetailslist[0].MexicoJobNumber);
                    //txtprovi.Text = Convert.ToString(workorderdetailslist[0].SyncToMexico);
                    salerepname.Text = Convert.ToString(workorderdetailslist[0].SalesRepName);
                    txtrepcode.Text = Convert.ToString(workorderdetailslist[0].REPCODE);
                    txtjobtype.Text = Convert.ToString(workorderdetailslist[0].JobType);
                    txtjobstatus.Text = Convert.ToString(workorderdetailslist[0].JobStatus);
                    txtdaterecive.Text = Convert.ToString(workorderdetailslist[0].JobOrderDate);
                    txtdatequote.Text = Convert.ToString(workorderdetailslist[0].QouteDate);
                    txtconsignment.Text = Convert.ToString(workorderdetailslist[0].ConsignmentInvoice);
                    txtdateapproved.Text = Convert.ToString(workorderdetailslist[0].ApprovedDate);
                    txtdateConsignment.Text = Convert.ToString(workorderdetailslist[0].ConsignmentDate);
                    txtdateinvoice.Text = Convert.ToString(workorderdetailslist[0].InvoiceDate);
                    txtInvoice.Text = Convert.ToString(workorderdetailslist[0].InvoiceNumber);
                    txtshipped.Text = Convert.ToString(workorderdetailslist[0].DateShipped);
                    txtInstruction.Text = Convert.ToString(workorderdetailslist[0].CustomerInstructions);
                    txtviewnotes.Text = Convert.ToString(workorderdetailslist[0].View90DayNotes);
                }
                this.IsBusy = false;
            }
            catch (Exception)
            {
                this.IsBusy = false;
            }
        }
        private void Butbackbutton_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new orderlist();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Wrkorderhideshow();
        }
    }
}


