using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class formTTT : Form
    {
        //Clicking button should generate X or O on screen
        //Have a bool variable that switches between X and O
        bool value = true; //true is X and false is O
        int countForDraw =0;

        public formTTT()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exit Applicaiton when clicked on Exit
            Application.Exit();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            //Show value on screen when button is clicked. 
            Button btnClicked = (Button)sender;
            //We should check if game is won after every click
            if (value == true)
            {
                btnClicked.Text = "X"; value = false;
            }
            else
            {
                btnClicked.Text = "O";
                value = true;
            }
            //We can simply write one line if statements
            //And switch the flag using value = !value;            
            btnClicked.Enabled = false;
            countForDraw++;
            checkGameWinner();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Created and Distributed Under LAT Corporations", "LAT");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            freshGame();
        }

        private void freshGame()
        {
            value = true;
            countForDraw = 0;
            try
            {
                foreach (Control item in Controls)
                {
                    Button b = (Button)item;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void checkGameWinner()
        {
            //Check Vertically
            bool do_we_have_a_winner = false;
            string winner="";
            if((btnOne.Text == btnTwo.Text) && (btnTwo.Text == btnThree.Text) && (btnOne.Enabled == false))
            {
                do_we_have_a_winner = true;
            }
            else if((btnFour.Text == btnFive.Text) && (btnFive.Text == btnSix.Text) && (btnFour.Enabled == false))
            {
                do_we_have_a_winner = true;
            }
            else if((btnSeven.Text == btnEight.Text) && (btnEight.Text == btnNine.Text) && (btnNine.Enabled == false))
            {
                do_we_have_a_winner = true;
            }

            //Check Horizontally
            if ((btnOne.Text == btnFour.Text) && (btnFour.Text == btnSeven.Text) && (btnSeven.Enabled == false))
            {
                do_we_have_a_winner = true;
            }
            else if ((btnTwo.Text == btnFive.Text) && (btnFive.Text == btnEight.Text) && (btnTwo.Enabled == false))
            {
                do_we_have_a_winner = true;
            }
            else if ((btnThree.Text == btnNine.Text) && (btnNine.Text == btnSix.Text) && (btnNine.Enabled == false))
            {
                do_we_have_a_winner = true;
            }

            //Check Diagnolly
            if ((btnOne.Text == btnFive.Text) && (btnFive.Text == btnNine.Text) && (btnOne.Enabled == false))
            {
                do_we_have_a_winner = true;
            }
            else if ((btnThree.Text == btnFive.Text) && (btnFive.Text == btnSeven.Text) && (btnThree.Enabled == false))
            {
                do_we_have_a_winner = true;
            }
            
            //
            
            if (do_we_have_a_winner == true)
            {
                try
                {
                    foreach (Control c in Controls) // Go through each control
                    {
                        Button disableAll = (Button)c;
                        disableAll.Enabled = false;
                    }
                }
                catch
                {

                }
                if (value==true)
                    winner = "O"; //We print in reverse since flag changes T/F after click
                else
                    winner = "X";
                MessageBox.Show("Congrats! " + winner + " wins","Winner");
                freshGame();
            }

            else if (countForDraw == 9) //Game is draw
            {
                MessageBox.Show("Draw!");
                freshGame();
            }

        }
    }
}
