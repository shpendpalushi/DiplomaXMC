using DiplomaXMC.Model;
using DiplomaXMC.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.XPath;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomaXMC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {

        //public List<MinifiedTask> _taskSource;

        public TaskPage()
        {
            InitializeComponent();
            //Task.Run(async () => await GetTaskDetails());

            BindingContext = this;
            //GetTasks();
            
        }

        ObservableCollection<XMCTasks> _userTasks;

        private async void GetTasks()
        {
            
            using (var client = new HttpClient())
            {
                string userId = "";
                if(Application.Current.Properties["userId"] != null)
                {
                    userId = Application.Current.Properties["userId"].ToString();
                }
                var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Tasks/GetUserTasks?userId=" + userId;
                var result = await client.GetStringAsync(uri);
                var TaskList = JsonConvert.DeserializeObject<List<XMCTasks>>(result);
                UserTasks = new ObservableCollection<XMCTasks>(TaskList);
                lvTasks.ItemsSource = UserTasks;
            }
        }

        public ObservableCollection<XMCTasks> UserTasks
        {
            get
            {
                return _userTasks;
            }
            set
            {
                _userTasks = value;
                OnPropertyChanged();
            }
        }

        //private async Task GetTaskDetails()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        string userId = "";
        //        if (Application.Current.Properties["userId"] != null)
        //            userId = Application.Current.Properties["userId"].ToString();
        //        var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Tasks/GetUserTasks?userId=" + userId;
        //        var result = await client.GetStringAsync(uri);
        //        var tasksList = JsonConvert.DeserializeObject<List<XMCTasks>>(result);

        //        foreach(var t in tasksList)
        //        {
        //            _taskSource.Add(new MinifiedTask() {Id=  t.XMCTask_Id, Name = t.Task_Name });
        //        }
        //        //lvTasks.ItemsSource = ts;
        //    }
        //}
        //public ICommand ItemClickCommand
        //{
        //    get
        //    {
        //        return new Command((item) =>
        //        {
        //            Application.Current.Properties["TaskId"] = "1";
        //            MasterDetailPage taskPage = new MasterDetailPage();
        //            taskPage.Master = new MainPage();
        //            taskPage.Detail = new NavigationPage(new TaskPage());
        //            Application.Current.MainPage = taskPage;
        //        });
        //    }
        //}

        protected override void OnAppearing()
        {
            
            GetTasks();
            
        }

        private void lvTasks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            if(e.Item != null)
            {
                var page = new SpecificTask();
                var myTask = e.Item as XMCTasks;
                page.BindingContext = myTask;
                MainPage fpm = new MainPage();
                fpm.Detail = new NavigationPage(page);
                Application.Current.MainPage = fpm;
                
            }
        }
    }
}