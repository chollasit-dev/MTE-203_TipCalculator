using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //FlyoutPage
            var fp = new FlyoutPage();
            fp.Flyout = new MenuPage();
            fp.Detail = new NavigationPage(new MainPage());     //1st Page of the App

            MainPage = fp;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
