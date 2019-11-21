
using DemoMenuItem.Views;
using IESCRM_Mobiles;
using IESCRM_Mobiles.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoMenuItem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        string password = "";
        public login()
        {
            InitializeComponent();
            btnlogin.Clicked += Btnlogin_Clicked1;
        }
        private void Btnlogin_Clicked1(object sender, EventArgs e)
        {
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //    DisplayAlert("Alert", "No Internet connection. Make sure that Wifi or mobile data is turned on, then try again", "OK");
            //}
            //else
            //{
                if (txtemail.Text != null && txtpass.Text != null)
                {
                    password = Encrypt(txtpass.Text);
                    Logindatafunction(txtemail.Text, password);
                }

                else
                {
                    DisplayAlert("Error", "Enter Email Or Password!", "Ok");
                    txtemail.Text = "";
                    txtpass.Text = "";
                    txtemail.Focus();
                }
           // }

        }
        public async void Logindatafunction(string username, string password)
        {
            try
            {
                string rolename = string.Empty;
                var formcontent = new FormUrlEncodedContent(new[]
               {
                 new KeyValuePair<string,string>("LoginId",username),
                 new KeyValuePair<string,string>("password",password)
                 });
                var client = new HttpClient();
                string url = GlobalAPIMaintain.CRMHttpsUrl + "/Api/GetUsers?";
                var result = await client.PostAsync(url, formcontent);
                var json = await result.Content.ReadAsStringAsync();
                List<Getlogin> logindetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Getlogin>>(json.ToString());
                if (json.Contains("User Not Found"))
                {
                    await DisplayAlert("Error", "You not authorized to login.", "Ok");
                    return;
                }
                else
                {
                    App.Current.Properties["RoleName"] = Convert.ToString(logindetails[0].RoleName); ;
                    App.Current.Properties["username"] = username;
                    App.Current.Properties["password"] = password;
                    await App.Current.SavePropertiesAsync();
                    App.Current.MainPage = new dashboard();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
                txtemail.Text = "";
                txtpass.Text = "";
                txtemail.Focus();
                return;
            }
        }
        private const string initVector = "tu89geji340t89u2";
        private const int keysize = 256;
        public static string Encrypt(string plainText)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes("FK-v7@qz>X`tw?S98kq", null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        //public static string Decrypt(string cipherText)
        //{
        //    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        //    byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        //    PasswordDeriveBytes password = new PasswordDeriveBytes("FK-v7@qz>X`tw?S98kq", null);
        //    byte[] keyBytes = password.GetBytes(keysize / 8);
        //    RijndaelManaged symmetricKey = new RijndaelManaged();
        //    symmetricKey.Mode = CipherMode.CBC;
        //    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        //    MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        //    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        //    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        //    memoryStream.Close();
        //    cryptoStream.Close();
        //    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        //}
    }

}
