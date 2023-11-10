using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string operand = "";
        private string second_operand = "";
        private string chosen_operator = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (inputValueTextBlock.Text == "0") inputValueTextBlock.Text = "";
            if (operandValueTextBlock.Text.Contains("="))
            {
                inputValueTextBlock.Text = "";
                operandValueTextBlock.Text = "";
                operandValueTextBlock.Visibility = Visibility.Hidden;
                second_operand = "";
            }
            inputValueTextBlock.Text += ((Button)sender).Content.ToString();
        }
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            chosen_operator = ((Button)sender).Content.ToString();
            operand = inputValueTextBlock.Text;
            second_operand = "";
            operandValueTextBlock.Text = inputValueTextBlock.Text + chosen_operator;
            operandValueTextBlock.Visibility = Visibility.Visible;
            inputValueTextBlock.Text = "0";
        }
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (inputValueTextBlock.Text == "0" || operand == "") return;
            if (second_operand == "") second_operand = inputValueTextBlock.Text;
            Double result = 0;
            Double input = Double.Parse(second_operand);
            switch (chosen_operator)
            {
                case "+":
                    result = Double.Parse(operand) + input;
                    break;
                case "−":
                    result = Double.Parse(operand) - input;
                    break;
                case "×":
                    result = Double.Parse(operand) * input;
                    break;
                case "÷":
                    result = Double.Parse(operand) / input;
                    break;
                default:
                    operandValueTextBlock.Text = operand + "=";
                    return;
            }
            operandValueTextBlock.Visibility = Visibility.Visible;
            operandValueTextBlock.Text = operand + chosen_operator + second_operand + "=";
            inputValueTextBlock.Text = result.ToString();
            operand = inputValueTextBlock.Text;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            inputValueTextBlock.Text = "0";
            if (((Button)sender).Content.ToString() == "C")
            {
                operandValueTextBlock.Text = "";
                operandValueTextBlock.Visibility = Visibility.Hidden;
                operand = "";
                second_operand = "";
                chosen_operator = "";
            }
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            string input = inputValueTextBlock.Text;
            if (input.Length == 1) { inputValueTextBlock.Text = "0"; return; }
            else
            {
                inputValueTextBlock.Text = input.Remove(input.Length - 1);
            }
        }

        private void FunctionButton_Click(object sender, RoutedEventArgs e)
        {
            String inputStr = inputValueTextBlock.Text;
            Double result = 0;

            chosen_operator = ((Button)sender).Content.ToString();
            operand = inputValueTextBlock.Text;
            switch (chosen_operator)
            {
                case "%":
                    operandValueTextBlock.Text = inputStr;
                    break;
                case "1/X":
                    operandValueTextBlock.Text = "1/(" + inputStr + ")";
                    break;
                case "x²":
                    operandValueTextBlock.Text = "Sqr(" + inputStr + ")";
                    break;
                case "√X":
                    operandValueTextBlock.Text = "Sqrt(" + inputStr + ")";
                    break;
                case "±":
                    operandValueTextBlock.Text = "Negate(" + inputStr + ")";
                    break;
            }
            operandValueTextBlock.Visibility = Visibility.Visible;
            Double input = Double.Parse(inputStr);
            switch (chosen_operator)
            {
                case "%":
                    result = input / 100;
                    break;
                case "1/X":
                    result = 1 / input;
                    break;
                case "x²":
                    result = input * input;
                    break;
                case "√X":
                    result = Math.Sqrt(input);
                    break;
                case "±":
                    result = -(input);
                    break;
            }
            inputValueTextBlock.Text = result.ToString();
            operand = inputValueTextBlock.Text;
        }
    }
}
