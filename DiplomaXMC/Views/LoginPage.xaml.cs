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
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace DiplomaXMC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            //MasterDetailPage fpm = new MainPage();
            //Application.Current.MainPage = fpm;

            using (var client = new HttpClient())
            {
                bool exists = false;
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Users/GetAllUsers";
                var result = await client.GetStringAsync(uri);
                var UsersList = JsonConvert.DeserializeObject<List<XMCUsers>>(result);
                Users = new ObservableCollection<XMCUsers>(UsersList);
                if ((txtEmail.Text != null && txtPassword.Text != null))
                {
                    foreach(var u in Users)
                    {
                        if(txtEmail.Text.Equals(u.Username) && txtPassword.Text.Equals(u.Password))
                        {
                            Application.Current.Properties["userId"] = u.Id;
                            Application.Current.Properties["userDescription"] = u.Description;
                            Application.Current.Properties["userEmail"] = u.Email;
                            Application.Current.Properties["userName"] = u.Full_Name;
                            Application.Current.Properties["userPassword"] = u.Password;
                            Application.Current.Properties["userUsername"] = u.Username;
                            exists = true;
                            break;
                        }
                    }
                    if(!exists)
                    {
                        await DisplayAlert("Gabim", "Kredencialet e vendosura nuk jane ne rregull. Ju lutem provoni perseri!", "Ok");
                        return;
                    }
                    else
                    {
                        try
                        {
                            Application.Current.MainPage = new MainPage();
                        }
                        catch(Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex);
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Gabim", "Ju lutemi plotesoni fushat e email dhe password!", "Ok");
                    return;
                }

            }
        }

        private  async void btnRegister_Clicked(object sender, EventArgs e)
        {
            var registerPage = new RegisterPage();//this could be content page
            var rootPage = new NavigationPage(registerPage);

            Application.Current.MainPage = rootPage;
        }

        ObservableCollection<XMCUsers> _users;
        public ObservableCollection<XMCUsers> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
            }
        }

    }


}
