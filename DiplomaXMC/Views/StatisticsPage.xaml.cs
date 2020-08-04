using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomaXMC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }

        public string NumUsers { get; set; }
        public async void GetUserStat()
        {
            using (var client = new HttpClient())
            {
                string uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/General/GetStatisticsUsers";
                var result = await client.GetStringAsync(uri);
                var Num = JsonConvert.DeserializeObject<string>(result);
                NumUsers = Num;
                txtUsers.Text = "Numri i perdoruesve te sistemit eshte: " + NumUsers;
                
            }

        }

        public async void GetTaskStat()
        {
            using (var client = new HttpClient())
            {
                string uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/General/GetStatisticsTasks";
                var result = await client.GetStringAsync(uri);
                var Num = JsonConvert.DeserializeObject<string>(result);
                txtTasks.Text = "Numri i taskeve te regjistruar ne sistem eshte: " + Num;

            }

        }

        public async void GetProjectStats()
        {
            using (var client = new HttpClient())
            {
                string uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/General/GetStatisticsProjects";
                var result = await client.GetStringAsync(uri);
                var Num = JsonConvert.DeserializeObject<string>(result);
                txtProjects.Text = "Numri i projekteve te regjistruar ne sistem eshte: " + Num;

            }
        }

        public async void GetJobStats()
        {
            using (var client = new HttpClient())
            {
                string uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/General/GetStatisticsJobs";
                var result = await client.GetStringAsync(uri);
                var Num = JsonConvert.DeserializeObject<string>(result);
                txtPositions.Text = "Numri i llojeve te punonjesve te kompanise eshte: " + Num;

            }
        }

        protected override void OnAppearing()
        {
            GetUserStat();
            GetTaskStat();
            GetProjectStats();
            GetJobStats();

        }



    }
}