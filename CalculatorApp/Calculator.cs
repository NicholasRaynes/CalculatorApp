using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        private double result;
        private string operationPerformed;

        public Calculator()
        {
            InitializeComponent();

            this.Load += Calculator_Load;

            this.btnZero.Click += Button_Click;
            this.btnOne.Click += Button_Click;
            this.btnTwo.Click += Button_Click;
            this.btnThree.Click += Button_Click;
            this.btnFour.Click += Button_Click;
            this.btnFive.Click += Button_Click;
            this.btnSix.Click += Button_Click;
            this.btnSeven.Click += Button_Click;
            this.btnEight.Click += Button_Click;
            this.btnNine.Click += Button_Click;

            this.btnDivide.Click += Operator_Click;
            this.btnMultiply.Click += Operator_Click;
            this.btnSubtract.Click += Operator_Click;
            this.btnAdd.Click += Operator_Click;

            this.btnClearEntry.Click += BtnClearEntry_Click;
            this.btnClear.Click += BtnClear_Click;

            this.btnEquals.Click += BtnEquals_Click;
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    this.txtResult.Text = (result + Double.Parse(this.txtResult.Text)).ToString();
                    break;
                case "-":
                    this.txtResult.Text = (result - Double.Parse(this.txtResult.Text)).ToString();
                    break;
                case "*":
                    this.txtResult.Text = (result * Double.Parse(this.txtResult.Text)).ToString();
                    break;
                case "/":
                    this.txtResult.Text = (result / Double.Parse(this.txtResult.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "0";
            result = 0;
        }

        private void BtnClearEntry_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "0";
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            result = 0;
            operationPerformed = "";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if(this.txtResult.Text == "0")
            {
                this.txtResult.Clear();
            }

            Button button = (Button)sender;

            this.txtResult.Text = this.txtResult.Text + button.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            operationPerformed = button.Text;

            result = Double.Parse(this.txtResult.Text);
        }
    }
}
