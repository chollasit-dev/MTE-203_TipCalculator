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
    public partial class BMIPage : ContentPage
    {
        //Field Initializer Can't Ref Non-Static Field, ...: https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0236#example
        string heightValue; double weightValue;

        public BMIPage()
        {
            InitializeComponent();

            sldHeight.ValueChanged += SldHeight_ValueChanged;
        }

        private void SldHeight_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            height.Text = sldHeight.Value.ToString("N0") + " cm";
            //height.Text = e.NewValue.ToString("N0") + " cm";      //Alternative Method
            //"N0": No Decimal
        }

        private void calculateBMI_Clicked(object sender, EventArgs e)
        {
            weightValue = Convert.ToDouble(weight.Text);
            heightValue = height.Text;
            double hv = Convert.ToDouble(heightValue.Remove(heightValue.Length - 3, 3));

            do
            {
                if (weightValue <= 0 || weightValue > 300)
                {
                    DisplayAlert("Error", "Your input weight is invalid! Please retype your weight.", "OK");
                    break;
                }
                //Ref: https://stackoverflow.com/questions/3034604/is-there-an-exponent-operator-in-c
                double result = weightValue / Math.Pow(hv * 0.01, 2);
                lblDisplay3.Text = result.ToString("#.##");
            } while (false);
        }
    }
}
