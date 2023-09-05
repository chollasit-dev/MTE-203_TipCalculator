using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//Ref: https://www.youtube.com/watch?v=JOJHFl_tk5I

namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked, isDecimalClicked;

        private void btnCommon_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            //Ref: https://stackoverflow.com/questions/29297305/how-to-break-out-of-an-if-statement
            do
            {
                if (lblDisplay1.Text.Length > 21)
                {
                    break;
                }
                if (lblDisplay1.Text == "0" || isOperatorClicked == true)
                {
                    if (isDecimalClicked == true)
                    {
                        lblDisplay1.Text += btn.Text;
                        break;
                    }
                    isOperatorClicked = false;
                    lblDisplay1.Text = btn.Text;
                }
                else
                {
                    lblDisplay1.Text += btn.Text;
                    if (lblDisplay1.Text.Length > 3 && isDecimalClicked == false)
                    {
                        /*lblDisplay1.Text = lblDisplay1.Text.ToString("0.##");
                          --> Can't Apply ToString() to Variable that originally is string*/
                        Decimal display = Decimal.Parse(lblDisplay1.Text);
                        lblDisplay1.Text = display.ToString("####,###,###,###,###,###.#########");
                    }
                }
            } while (false);
        }

        private void btnDecimal_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (lblDisplay1.Text == "0")
            {
                lblDisplay1.Text += btn.Text;
                isDecimalClicked = true;
            }
            else if (isDecimalClicked == true)
            {
                lblDisplay1.Text = lblDisplay1.Text;
            }
            else if (isOperatorClicked == true)
            {
                lblDisplay1.Text = "0.";
                isDecimalClicked = true;
            }
            else
            {
                isDecimalClicked = true;
                /*Ref: https://stackoverflow.com/questions/21912902/call-a-function-in-another-function-c-sharp
                Parameters the Same as the Function is Called*/
                btnCommon_Clicked(sender, e);
            }
        }

        private void btnCommonOperator_Clicked(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                if (isOperatorClicked == true)
                {
                    btnEqual_Clicked(sender, e);
                }
                isOperatorClicked = true;
                operatorName = btn.Text;
                isDecimalClicked = false;
                firstNumber = Convert.ToDecimal(lblDisplay1.Text);
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            lblDisplay1.Text = "0";
            isOperatorClicked = false;
            isDecimalClicked = false;
            firstNumber = 0;
        }

        private async void btnPercent_Clicked(object sender, EventArgs e)
        {
            try
            {
                String num = lblDisplay1.Text;
                if (num != "0")
                {
                    decimal percentValue = decimal.Parse(num);
                    //decimal percentValue = Convert.ToDecimal(num);
                    num = (percentValue / 100).ToString("0.#########");
                    lblDisplay1.Text = num;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void btnEqual_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secondNum = Convert.ToDecimal(lblDisplay1.Text);
                //Ref: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings
                string result = calculate(firstNumber, secondNum).ToString("###,###,###,###,###,###.#########");
                while (result.Length > 21)
                {
                    result = result.Remove(result.Length - 1, 1);
                }
                lblDisplay1.Text = result;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public decimal calculate(decimal firstNum, decimal secondNum)
        {
            if (operatorName == "+")
            {
                return firstNum + secondNum;
            }
            else if (operatorName == "-")
            {
                return firstNum - secondNum;
            }
            else if (operatorName == "x")
            {
                return firstNum * secondNum;
            }
            else if (operatorName == "/")
            {
                return firstNum / secondNum;
            }
            return decimal.Parse(lblDisplay1.Text);
        }
    }
}
