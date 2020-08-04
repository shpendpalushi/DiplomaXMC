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
    public partial class ProjectsPage : ContentPage
    {
        public ProjectsPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        ObservableCollection<Projekt> _project;

        private async void GetTasks()
        {

            using (var client = new HttpClient())
            {
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Projekt/GetProjekt";
                var result = await client.GetStringAsync(uri);
                var TaskList = JsonConvert.DeserializeObject<List<Projekt>>(result);
                Project = new ObservableCollection<Projekt>(TaskList);
                lvTasks.ItemsSource = Project;
            }
        }

        public ObservableCollection<Projekt> Project
        {
            get
            {
                return _project;
            }
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }


        protected override void OnAppearing()
        {

            GetTasks();

        }

        private void lvTasks_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            //if (e.Item != null)
            //{
            //    var page = new SpecificTask();
            //    var myTask = e.Item as XMCTasks;
            //    page.BindingContext = myTask;
            //    MainPage fpm = new MainPage();
            //    fpm.Detail = new NavigationPage(page);
            //    Application.Current.MainPage = fpm;

            //}
        }

        private void btnTask_Clicked(object sender, EventArgs e)
        {
            var page = new AddTaskPage();
            MainPage fpm = new MainPage();
            fpm.Detail = new NavigationPage(page);
            Application.Current.MainPage = fpm;
        }
    }
}