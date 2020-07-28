using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DiplomaXMC.Model;

namespace DiplomaXMC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpecificTask : ContentPage
    {
        private XMCTasks _task;
        public XMCTasks MyTask
        {
            get
            {
                return _task;
            }
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }
        public SpecificTask()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            MyTask = (DiplomaXMC.Model.XMCTasks)BindingContext;
            txtName.Text = MyTask.Task_Name;
            txtDesc.Text = MyTask.Task_Description;
        }

        protected override void OnBindingContextChanged()
        {
            MyTask = (DiplomaXMC.Model.XMCTasks)BindingContext;
        }
    }

    
}