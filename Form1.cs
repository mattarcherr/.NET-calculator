using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (EntryBox.Text == "0") EntryBox.Clear();

            if (EntryBox.Text.Contains(".") && ((Button)sender).Text == ".") { }
            else EntryBox.Text += ((Button)sender).Text;
        }
        private void CE_Click(object sender, EventArgs e)
        {
            first_operand = "";
            chosen_operator = "";
            EntryBox.Text = "0";
        }

        private void operator_Click(object sender, EventArgs e)
        {
            chosen_operator = ((Button)sender).Text;
            first_operand = EntryBox.Text;
            EntryBox.Clear();
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            Double result = 0;
            switch (chosen_operator)
            {
                case "+":
                    result = Double.Parse(first_operand) + Double.Parse(EntryBox.Text);
                    break;
                case "-":
                    result = Double.Parse(first_operand) - Double.Parse(EntryBox.Text);
                    break;
                case "/":
                    result = Double.Parse(first_operand) / Double.Parse(EntryBox.Text);
                    break;
                case "*":
                    result = Double.Parse(first_operand) * Double.Parse(EntryBox.Text);
                    break;
            }

            EntryBox.Text = result.ToString();
        }
    }
}
