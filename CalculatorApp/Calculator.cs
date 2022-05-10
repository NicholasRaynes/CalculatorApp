/*
 * Name: Nicholas Raynes
 * Version: 0.0.1
 * Description: A simple Windows Form calculator application. 
 * (Roughly based on the Windows calculator.)
 */

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
    /// <summary>
    /// This class represents a Windows calculator application.
    /// </summary>
    public partial class Calculator : Form
    {
        private double result;
        private string operationPerformed;
        private bool isOperationPerformed;

        /// <summary>
        /// Initializes an instance of the Calculator class.
        /// </summary>
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
            this.btnDecimal.Click += Button_Click;

            this.btnDivide.Click += Operator_Click;
            this.btnMultiply.Click += Operator_Click;
            this.btnSubtract.Click += Operator_Click;
            this.btnAdd.Click += Operator_Click;

            this.btnClearEntry.Click += BtnClearEntry_Click;
            this.btnClear.Click += BtnClear_Click;

            this.btnEquals.Click += BtnEquals_Click;
        }

        /// <summary>
        /// Handles the click event for the btnEquals control.
        /// </summary>
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

            result = Double.Parse(this.txtResult.Text);

            lblCurrentOperation.Text = "";
        }

        /// <summary>
        /// Handles the click event for the btnClear control.
        /// </summary>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "0";
            result = 0;
        }

        /// <summary>
        /// Handles the click event for the btnClearEntry control.
        /// </summary>
        private void BtnClearEntry_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = "0";
        }

        /// <summary>
        /// Handles the load event for this Calculator form.
        /// </summary>
        private void Calculator_Load(object sender, EventArgs e)
        {
            result = 0;
            operationPerformed = "";
            isOperationPerformed = false;
        }

        /// <summary>
        /// Handles the click event for all the button controls.
        /// </summary>
        private void Button_Click(object sender, EventArgs e)
        {
            if(this.txtResult.Text == "0" || isOperationPerformed)
            {
                this.txtResult.Clear();
            }

            isOperationPerformed = false;

            Button button = (Button)sender;

            if(button.Text == ".")
            {
                if(!this.txtResult.Text.Contains("."))
                {
                    this.txtResult.Text = this.txtResult.Text + button.Text;
                }
            }else
            {
                this.txtResult.Text = this.txtResult.Text + button.Text;
            }
        }

        /// <summary>
        /// Handles the click event for all the operator button controls.
        /// </summary>
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(result != 0)
            {
                btnEquals.PerformClick();

                operationPerformed = button.Text;

                isOperationPerformed = true;

                lblCurrentOperation.Text = String.Format("{0} {1}", result, operationPerformed);
            }
            else
            {
                operationPerformed = button.Text;

                result = Double.Parse(this.txtResult.Text);

                isOperationPerformed = true;

                lblCurrentOperation.Text = String.Format("{0} {1}", result, operationPerformed);
            }
        }
    }
}
