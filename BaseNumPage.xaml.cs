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
    public partial class BaseNumPage : ContentPage
    {

        public BaseNumPage()
        {
            InitializeComponent();

            red.ValueChanged += Red_ValueChanged;
            green.ValueChanged += Green_ValueChanged;
            blue.ValueChanged += Blue_ValueChanged;
        }

        private void Blue_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            blueValue.Text = blue.Value.ToString("N0");
        }

        private void Green_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            greenValue.Text = green.Value.ToString("N0");
        }

        private void Red_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            redValue.Text = red.Value.ToString("N0");
        }

        private void calculateHEX_Clicked(object sender, EventArgs e)
        {

        }
    }
}