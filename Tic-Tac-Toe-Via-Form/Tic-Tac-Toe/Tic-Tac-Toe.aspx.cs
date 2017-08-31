using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tic_Tac_Toe
{
    public partial class Tic_Tac_Toe : System.Web.UI.Page
    {
        private static string turn = "X";
        private static string winner = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetMessage("X- Gets To Start");
        }
        protected void Button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (winner != null)
            {
                SetMessage("Game is Already Over");
            }
            else if (button.Text == " ")
            {
                button.Text =turn ;
                SwitchPlayer();
            }
            else
            {
                SetMessage("That Box Is Already Filled");
            }
        }
        public void SetMessage(string msg)
        {
            player_Turn.Text = msg;
        }
        public void SwitchPlayer()
        {
            if (CheckWinner(turn) == "Win")
            {
                SetMessage("Congo Player " + turn + "! You Have Won the Game ");
                winner = turn;
            }
            else if (CheckWinner(turn) == "Draw")
            {
                SetMessage("Game Draw");
                winner = turn;
            }
            else if (turn == "X" )
            {
                turn = "O";
                SetMessage(turn+"'s Turn!");
               
            }
            else if (turn == "O" )
            {
                turn = "X";
                SetMessage(turn + "'s Turn!");
            }

        }
        public string CheckWinner(string turn)
        {
            string result = ""; 
            if((Button1.Text == turn && Button2.Text == turn && Button3.Text == turn) ||
               (Button4.Text == turn && Button5.Text == turn && Button6.Text == turn) ||
               (Button7.Text == turn && Button8.Text == turn && Button9.Text == turn) ||
               (Button1.Text == turn && Button4.Text == turn && Button7.Text == turn) ||
               (Button1.Text == turn && Button5.Text == turn && Button9.Text == turn) ||
               (Button3.Text == turn && Button6.Text == turn && Button9.Text == turn) ||
               (Button2.Text == turn && Button5.Text == turn && Button8.Text == turn) ||
               (Button1.Text == turn && Button5.Text == turn && Button9.Text == turn) ||
               (Button3.Text == turn && Button5.Text == turn && Button7.Text == turn) 
                )
            {
                result="Win";
            }
            else if (DrawCheck())
            {
                result = "Draw";
            }
            return result;
        }
        public bool DrawCheck()
        {
            bool result = false;
            if (Button1.Text!=" "&& Button2.Text != " " && Button3.Text != " " && 
                Button4.Text != " " && Button5.Text != " " && Button6.Text != " "
                && Button7.Text != " " && Button8.Text != " " && Button9.Text != " ")
            {
                result = true;
            }
            return result;
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tic-Tac-Toe.aspx");
        }
    }
}