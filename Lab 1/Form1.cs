using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_1
{
  
    public partial class MainForm : Form
    {
        private bool wasDot;
        private int lastSymbolPos;
        public MainForm()
        {
            InitializeComponent();
            OutTextBox.Text = "";
        }

        private void ZeroButton_Click(object sender, EventArgs e)
        {
            if (OutTextBox.Text == "0")
                return;
            OutTextBox.Text += "0";
        }

        private void ZeroButton_MouseDown(object sender, MouseEventArgs e)
        {
            ZeroButton.BackColor = Color.Gray;
        }

        private void ZeroButton_MouseUp(object sender, MouseEventArgs e)
        {
            ZeroButton.BackColor = Color.White;
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "1";
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "2";
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "3";
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "4";
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "5";

        }

        private void SixButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "6";
        }

        private void SevenButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "7";
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "8";
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            OutTextBox.Text += "9";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OutTextBox.Text = "";
        }

        private void DeleteLastButton_Click(object sender, EventArgs e)
        {
            if (OutTextBox.Text == "")
                return;
            if (OutTextBox.Text[OutTextBox.Text.Length - 1] == '.')
                wasDot = false;
            OutTextBox.Text = OutTextBox.Text.Remove(OutTextBox.Text.Length - 1);
            
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            if (OutTextBox.Text.Length != 0)
            {
                if (lastSymbolPos == 0)
                {
                    if (OutTextBox.Text[0] == '-')
                        OutTextBox.Text = OutTextBox.Text.Remove(0, 1);
                    else
                        OutTextBox.Text = OutTextBox.Text.Insert(0, "-");
                }
                else
                {
                    OutTextBox.Text = OutTextBox.Text.Insert(lastSymbolPos, "-");    
                }
            }

        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            if (!CheckOperationBefore())
                return;
            if (!wasDot)
            {
                OutTextBox.Text += ".";
                wasDot = true;
            }
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (OutTextBox.Text != "")
                    OutTextBox.Text = new DataTable().Compute(OutTextBox.Text, null).ToString();
            }
            catch (WrongFormatException a)
            {
                MessageBox.Show(a.Message);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }

        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (CheckOperationBefore())
                OutTextBox.Text += '+';
            lastSymbolPos = OutTextBox.Text.Length;
            wasDot = false;
        }
        

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (CheckOperationBefore())
                OutTextBox.Text += '-';
            lastSymbolPos = OutTextBox.Text.Length;
            wasDot = false;
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            if (CheckOperationBefore())
                OutTextBox.Text += '*';
            lastSymbolPos = OutTextBox.Text.Length;
            wasDot = false;
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            if (CheckOperationBefore())
                OutTextBox.Text += '/';
            lastSymbolPos = OutTextBox.Text.Length;
            wasDot = false;


        }
        private bool CheckOperationBefore()
        {
            if (OutTextBox.Text.Length > 0)
            {
                if (OutTextBox.Text[OutTextBox.Text.Length - 1] == '+' ||
                    OutTextBox.Text[OutTextBox.Text.Length - 1] == '-' ||
                    OutTextBox.Text[OutTextBox.Text.Length - 1] == '*' ||
                    OutTextBox.Text[OutTextBox.Text.Length - 1] == '/')
                    return false;
                return true;
            }
            return false;
        }
        public class WrongFormatException : Exception
        {
            public WrongFormatException(string message) : base(message)
            {

            }
        }
    }
}
