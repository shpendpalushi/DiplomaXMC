using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomaXMC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            txtDesc.Text = Application.Current.Properties["userDescription"].ToString();
            txtEmail.Text = Application.Current.Properties["userEmail"].ToString();
            txtName.Text = Application.Current.Properties["userName"].ToString();
            txtUsername.Text =  Application.Current.Properties["userUsername"].ToString();

        }
    }
}