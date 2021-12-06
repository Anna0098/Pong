using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {

        Rectangle player1 = new Rectangle(28, 200, 20, 20);
        Rectangle player2 = new Rectangle(330, 200, 20, 20);
        Rectangle ball = new Rectangle(300, 300, 10, 10);
        Rectangle ball2 = new Rectangle(200, 200, 5, 5);



        Random randGen = new Random();
        

        int player1Score = 0;
        int player2Score = 0;
        int playerSpeed = 4;
        int player1Speed = 4;
        int player2Speed = 4;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }
      

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
               
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Left:
                   leftDown  = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
            

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(purpleBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball);
            e.Graphics.FillRectangle(yellowBrush, ball2);

        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
           
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            if (aDown == true && player1.X > 0)
            { player1.X -= player1Speed; }

            if (dDown == true && player1.X < this.Height + player1.Height)
            { player1.X += player1Speed; }


            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            if ( leftDown == true && player2.X > 0)
            {
                player2.X -= player2Speed;
            }

            if (rightDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += player2Speed; 
            }

            //check if ball hit top or bottom wall and change direction if it does 
          
            //check if ball hits either player. If it does change the direction 
            //and place the ball in front of the player hit 


            {
                int randValue = randGen.Next(1,361);
                if (player1.IntersectsWith(ball))
                {
                    player1Score++;
                    p1ScoreLabel.Text = $"{player1Score}";
                    ball.X = randValue;
                    ball.Y = randValue;
                }
            }
            if (player2.IntersectsWith(ball))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                int randValue = randGen.Next(1, 361);
                ball.X = randValue;
                ball.Y = randValue;
            }
            if (player1.IntersectsWith(ball2))
            {
                player1Speed++;
                int randValue = randGen.Next(1, 361);
                ball2.X = randValue;
                ball2.Y = randValue;
            }
            if (player2.IntersectsWith(ball2))
            {
                player2Speed++;
                int randValue = randGen.Next(1, 361);
                ball2.X = randValue;
                ball2.Y = randValue;
            }






            //check if a player missed the ball and if true add 1 to score of other player  



            // check score and stop game if either player is at 3 
            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
            }
            Refresh(); 

        }

       
    }
}
