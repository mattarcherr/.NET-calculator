using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.XPath;

namespace Calculator
{
    public partial class Calculator : Form
    {
        string first_operand;
        string chosen_operator;

        public Calculator()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (EntryBox.Text == "0") EntryBox.Clear();

            if (EntryBox.Text.Contains(".") && ((Button)sender).Text == ".") {
                return;
            }
            else EntryBox.Text += ((Button)sender).Text;
        }
        private void CE_Click(object sender, EventArgs e)
        {
            first_operand = "";
            chosen_operator = "";
            EntryBox.Text = "0";
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            chosen_operator = ((Button)sender).Text;
            first_operand = EntryBox.Text;
            if (chosen_operator == "%")
            {
                ButtonEquals_Click(sender, e);
            }
            else
            {
                EntryBox.Clear();
            }
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            if (EntryBox.Text.Length == 0) return;
            Double result = 0;
            switch (chosen_operator)
            {
                case "+":
                    result = Double.Parse(first_operand) + Double.Parse(EntryBox.Text);
                    break;
                case "−":
                    result = Double.Parse(first_operand) - Double.Parse(EntryBox.Text);
                    break;
                case "÷":
                    result = Double.Parse(first_operand) / Double.Parse(EntryBox.Text);
                    break;
                case "×":
                    result = Double.Parse(first_operand) * Double.Parse(EntryBox.Text);
                    break;
                case "%":
                    result = Double.Parse(EntryBox.Text) / 100;
                    break;
                case "1/a":
                    result = 1 / Double.Parse(EntryBox.Text);
                    break;
                case "a^2":
                    result = Double.Parse(EntryBox.Text) * Double.Parse(EntryBox.Text);
                    break;
                case "√a":
                    result = Math.Sqrt(Double.Parse(EntryBox.Text));
                    break;
                default:
                    result = 0;
                    break;
            }

            EntryBox.Text = result.ToString();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Text: CE"))
            {
                first_operand = "";
            }
            EntryBox.Text = "";
            return;
        }
    }
}
