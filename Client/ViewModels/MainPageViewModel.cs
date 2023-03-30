using DemoMaui.Helpers;
using DemoMaui.RazorClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMaui.ViewModels
{
    public class MainPageViewModel: ViewModelBase
    {
        private readonly SharedState sharedState;
        public RelayCommand CounterCommand { get; set; }

        private string labelText = "";
        public string LabelText
        {
            get { return labelText; } 
            set { 
                SetProperty(ref labelText,value); }
        }


        public MainPageViewModel(SharedState sharedState)
        {
            this.sharedState = sharedState;
            CounterCommand = new RelayCommand(() =>
            {
                this.sharedState.IncrementCount();
                
            });

            this.sharedState.CountChanged += SharedState_CountChanged;
        }

        private void SharedState_CountChanged(object sender, EventArgs e)
        {
            LabelText = this.sharedState.CurrentCount.ToString();
        }
    }
}
