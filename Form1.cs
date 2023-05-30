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
            if (textBox1.Text == "0") textBox1.Clear();

            if (textBox1.Text.Contains(".") && ((Button)sender).Text == ".") { }
            else textBox1.Text += ((Button)sender).Text;
        }
        private void CE_Click(object sender, EventArgs e)
        {
            first_operand = "";
            chosen_operator = "";
            textBox1.Text = "0";
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void operator_Click(object sender, EventArgs e)
        {
            chosen_operator = ((Button)sender).Text;
            first_operand = textBox1.Text;
            textBox1.Clear();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            Double result = 0;
            switch (chosen_operator)
            {
                case "+":
                    result = Double.Parse(first_operand) + Double.Parse(textBox1.Text);
                    break;
                case "-":
                    result = Double.Parse(first_operand) - Double.Parse(textBox1.Text);
                    break;
                case "/":
                    result = Double.Parse(first_operand) / Double.Parse(textBox1.Text);
                    break;
                case "*":
                    result = Double.Parse(first_operand) * Double.Parse(textBox1.Text);
                    break;
            }

            textBox1.Text = result.ToString();
        }
    }
}
