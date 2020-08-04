using DiplomaXMC.Model;
using DiplomaXMCWS.ViewModel;
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
    public partial class AddTaskPage : ContentPage
    {
        public AddTaskPage()
        {
            InitializeComponent();
            BindingContext = this;
        }


        public ObservableCollection<XMCUsers> Users { get; set; }
        public ObservableCollection<Pune> Pune { get; set; }
        public ObservableCollection<Projekt> Projekt { get; set; }
        public ObservableCollection<Tipologjia> Tipologjia { get; set; }


        private async Task<ObservableCollection<XMCUsers>> GetUsers()
        {
            using (var client = new HttpClient())
            {
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Users/GetAllUsers";
                var result = await client.GetStringAsync(uri);
                var ResultList = JsonConvert.DeserializeObject<List<XMCUsers>>(result);
                Users = new ObservableCollection<XMCUsers>(ResultList);
                return Users;
            }

        }

        private async Task<ObservableCollection<Pune>> GetPune()
        {
            using (var client = new HttpClient())
            {
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Pune/GetPune";
                var result = await client.GetStringAsync(uri);
                var ResultList = JsonConvert.DeserializeObject<List<Pune>>(result);
                Pune = new ObservableCollection<Pune>(ResultList);
                return Pune;
            }

        }

        private async Task<ObservableCollection<Tipologjia>> GetTipologjia()
        {
            using (var client = new HttpClient())
            {
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Tipologjia/GetTypology";
                var result = await client.GetStringAsync(uri);
                var ResultList = JsonConvert.DeserializeObject<List<Tipologjia>>(result);
                Tipologjia = new ObservableCollection<Tipologjia>(ResultList);
                return Tipologjia;
            }
        }

        private async Task<ObservableCollection<Projekt>> GetProject()
        {
            using (var client = new HttpClient())
            {
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Projekt/GetProjekt";
                var result = await client.GetStringAsync(uri);
                var ResultList = JsonConvert.DeserializeObject<List<Projekt>>(result);
                Projekt = new ObservableCollection<Projekt>(ResultList);
                return Projekt;
            }
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtDesc.Text))
            {
                await DisplayAlert("Kujdes", "Plotesoni fushat e detyrueshme", "OK");
            }
            else
            {
                XMCTasks myTask = new XMCTasks();
                myTask.Task_Name = txtName.Text;
                myTask.Task_Description = txtDesc.Text;
                var selectedUser= (XMCUsers)ddUser.SelectedItem;
                myTask.Creator_Id = long.Parse(Application.Current.Properties["userId"].ToString());
                myTask.Referencer_Id = selectedUser.Id;
                var selectedPune = (Pune)ddPune.SelectedItem;
                myTask.XMCPune_Id = selectedPune.XMCPune_Id;
                var selectedProject = (Projekt)ddProjekt.SelectedItem;
                myTask.XMCProjekt_Id = selectedProject.XMCProjekt_Id;
                var selectedTipologjia = (Tipologjia)ddTipologjia.SelectedItem;
                myTask.XMCTipologjia_Id = selectedTipologjia.XMCTipologjia_Id;
                using (var client = new HttpClient())
                {
                    var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Tasks/PostNewTask/";
                    string jsonTask = JsonConvert.SerializeObject(myTask);
                    var data = new StringContent(jsonTask, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(uri, data);
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        await DisplayAlert("Sukses", "Tasku u delegua me sukses", "OK");
                    }
                }
            }

        }

        protected override async void OnAppearing()
        {
            ddUser.ItemsSource = await GetUsers();
            ddPune.ItemsSource = await GetPune();
            ddProjekt.ItemsSource = await GetProject();
            ddTipologjia.ItemsSource = await GetTipologjia();
            BindingContext = this;
            base.OnAppearing();
        }
    }
}