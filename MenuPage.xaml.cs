using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

            normalCalculator.Clicked += NormalCalculator_Clicked;
            percentage.Clicked += Percentage_Clicked;
            BMI.Clicked += BMI_Clicked;
            baseNumber.Clicked += BaseNumber_Clicked;
        }

        private void BaseNumber_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as FlyoutPage;
            mp.Detail = new NavigationPage(new BaseNumPage());
            mp.IsPresented = false;
        }

        private void BMI_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as FlyoutPage;
            mp.Detail = new NavigationPage(new BMIPage());
            mp.IsPresented = false;
        }

        private void Percentage_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as FlyoutPage;
            mp.Detail = new NavigationPage(new PercentPage());
            mp.IsPresented = false;
        }

        private void NormalCalculator_Clicked(object sender, EventArgs e)
        {
            var mp = Parent as FlyoutPage;
            mp.Detail = new NavigationPage(new MainPage());
            mp.IsPresented = false;
        }
    }
}