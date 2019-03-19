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
        Double ResultValue = 0;
        String Operator = "";
        bool isPerformed = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            if ((Display.Text == "0")|| isPerformed)
                Display.Clear();
            Button button = (Button)sender;
            Display.Text = Display.Text + button.Text;
            isPerformed = false;
        }

        private void deci_click(object sender, EventArgs e)
        {
            char[] V = { '.' };
            if (Display.Text.IndexOfAny(V)<0)
            {
                Button button = (Button)sender;
                Display.Text = Display.Text + button.Text;
                isPerformed = false;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (ResultValue != 0)
            {
                Operator = button.Text;
                button_equals.PerformClick();
                label_current_opt.Text = ResultValue + "" + Operator;
                isPerformed = true;
            }
            else
            {
                Operator = button.Text;
                ResultValue = double.Parse(Display.Text);
                label_current_opt.Text = ResultValue + "" + Operator;
                isPerformed = true;
            }
        }

        private void button_clearentry_Click(object sender, EventArgs e)
        {
            Display.Text = "0"; 
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            Display.Text = "0";
            ResultValue = 0;
            label_current_opt.Text = "";
        }

        private void button_equals_Click(object sender, EventArgs e)
        {
            switch(Operator)
            {
                case "+":
                    Display.Text = (ResultValue + double.Parse(Display.Text)).ToString();
                    break;

                case "-":
                    Display.Text = (ResultValue - double.Parse(Display.Text)).ToString();
                    break;

                case "*":
                    Display.Text = (ResultValue * double.Parse(Display.Text)).ToString();
                    break;

                case "/":
                    Display.Text = (ResultValue / double.Parse(Display.Text)).ToString();
                    break;
                default:
                    break;
            }
            ResultValue = double.Parse(Display.Text);
            label_current_opt.Text = "";
        }
    }
}
