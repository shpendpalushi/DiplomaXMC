using DiplomaXMC.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DiplomaXMC
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    //[DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new Dashboard());
            IsPresented = false;
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }

        private void btnDashboard_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Dashboard());
            IsPresented = false;
        }
        private void btnTasks_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TaskPage());
            IsPresented = false;
        }

        private void btnProjektet_Clicked(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new AboutUs());
            //IsPresented = false;
        }
        private void btnStatistika_Clicked(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new ContactUs());
            //IsPresented = false;
        }
        private void btnDokumenta_Clicked(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new ContactUs());
            //IsPresented = false;
        }
        private void btnInfo_Clicked(object sender, EventArgs e)
        {
            //Detail = new NavigationPage(new ContactUs());
            //IsPresented = false;
        }
        private void btnLogut_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
        
    }
}
