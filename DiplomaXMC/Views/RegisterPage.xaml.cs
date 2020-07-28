using DiplomaXMC.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomaXMC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        ObservableCollection<XMCPosition> _positions;
        
        public ObservableCollection<XMCPosition> Positions
        {
            get
            {
                return _positions;
            }
            set
            {
                _positions = value;
                OnPropertyChanged();
            }
        }
        public RegisterPage()
        {
            InitializeComponent();
        }


        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (string .IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtUsername.Text)
                || string.IsNullOrEmpty(ddProfession.SelectedItem.ToString()) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirm.Text))
            {
                await DisplayAlert("Kujdes", "Te gjitha fushat e mesiperme jane te detyureshme, plotesojini dhe provoni perseri!", "OK");
            }
            else
            {
                XMCUsers myUser = new XMCUsers();
                myUser.Full_Name = txtName.Text;
                myUser.Email = txtEmail.Text;
                myUser.Username = txtUsername.Text;
                myUser.Description = txtDescription.Text;
                myUser.Password = txtPassword.Text;
                myUser.PozicionId = ddProfession.SelectedIndex + 1;
                using (var client = new HttpClient())
                {
                    var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Users/PostNewUser";
                    string jsonUser = JsonConvert.SerializeObject(myUser);
                    var data = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, data);
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        await DisplayAlert("Sukses", "Perdoruesi u regjistrua me sukses!", "Ok");
                    }
                    string result = response.Content.ReadAsStringAsync().Result;
                    Application.Current.MainPage = new LoginPage();
                }
                


            }
        }

        private async void GetPositions()
        {
            using (var client = new HttpClient())
            {
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Pozicion/GetAllPositions";
                var result = await client.GetStringAsync(uri);
                var ResultList = JsonConvert.DeserializeObject<List<XMCPosition>>(result);
                Positions =new ObservableCollection<XMCPosition>(ResultList);
                List<string> names = new List<string>();
                foreach(var p in Positions)
                {
                    names.Add(p.Name);
                }
                ddProfession.ItemsSource = names;
            }
        }

        protected override void OnAppearing()
        {
            GetPositions();
        }



    }
}