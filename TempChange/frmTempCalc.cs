using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempChange
{
    public partial class frmTempCalc : Form
    {
        //private variables only used to identify if a btn was clicked.
        public bool ifbtnFarhrenheithClicked = false;
        public bool ifbtnCelciusClicked = false;

        public frmTempCalc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*When button is clicked it takes the input changes it to an int does the math equation
          and then returns it to a string to print out*/
         
        private void btnFahrenheit_Click(object sender, EventArgs e)
        {
            ifbtnFarhrenheithClicked = true;
            Calculations();
        }

        /*When button is clicked it takes the input changes it to an int does the math equation
          and then returns it to a string to print out*/
        private void btnCelsius_Click(object sender, EventArgs e)
        {
            ifbtnCelciusClicked = true;
            Calculations();
        }
        
        //tried to be fancy and put everything together. 
        private void Calculations()
        {
            //try statement to do the equations
            try
            {
                int input = Convert.ToInt32(txtInput.Text);
                int result = 0;

                //if statement that looks to see if one of the buttons were clicked.
                if (ifbtnCelciusClicked)
                {
                    result = (input - 32) * 5 / 9;
                }
                if (ifbtnFarhrenheithClicked)
                {
                    result = ((input * 9) / 5) + 32;
                }

                txtResult.Text = result.ToString();
            }
            //all of my catch statements some I believe may be redundent but you can never be to careful when you trust humans.
            //catch statement if you divide by 0 (impossible to throw this?)
            catch (DivideByZeroException de)
            {
                MessageBox.Show(de.Message, "Congrats IDK how you did this!");
            }
            // catch if the int is too big (Temps never get this high)
            catch (OverflowException oe)
            {
                MessageBox.Show(oe.Message, "Temperature is too high!");
            }
            //catch if they put a letter, symbol, or decimal instead of a int
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message, "Please use real numbers!");
            }
            //catch if math is done wrong.
            catch (ArithmeticException ae)
            {
                MessageBox.Show(ae.Message, "Somehow you did math wrong!?");
            }
            //catch if something unexpected happens. Generic
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error has Occured!");
            }


            ResetBtn();

        }

        //resets button click so you dont have to retype the number.
        //If this is a more difficult way to do this could you please let me know if there is an easier way?
        private void ResetBtn()
        {
           if (ifbtnFarhrenheithClicked)
            {
                ifbtnFarhrenheithClicked = false;
            }
            if (ifbtnCelciusClicked)
            {
                ifbtnFarhrenheithClicked = false;
            } 
        } 
    }
}
