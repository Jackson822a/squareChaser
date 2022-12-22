using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices.ComTypes;

namespace squareChaser
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(0, 170, 20, 20);
        Rectangle player2 = new Rectangle(500, 170, 20, 20);
        Rectangle point = new Rectangle(250, 180, 10, 10);
        Rectangle boost = new Rectangle(250, 220, 10, 10);
        Rectangle border = new Rectangle(60, 0, 10, 500);
        Rectangle border2 = new Rectangle(455, 0, 10, 500);

        List<Rectangle> balls = new List<Rectangle>();

        List<Rectangle> balls2 = new List<Rectangle>();
        int ballSize = 10;

        int ballSpeed = 8;

        int player1Score = 0;
        int player2Score = 0;

     
        int player1Speed = 6;
        int player2Speed = 6;
        int ballXSpeed = -6;
        int ballYSpeed = 6;

        string gameState = "waiting";

        bool wDown = false;
        bool sDown = false;
        bool aLeft = false;
        bool dRight = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;


        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red); 
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);  


        Random random = new Random();
        int randValue = 0;
        Random random2 = new Random();
        int randValue2 = 0;


        public Form1()
        {
            InitializeComponent();
           
            this.Focus();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //move player 1
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }
            if (aLeft == true && player1.X > 0)
            {
                player1.X -= player1Speed;
            }
            if (dRight == true && player1.X < 435)
            {
                player1.X += player1Speed;
            }
           
            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            if (leftArrowDown == true && player2.X >70)
            {
                player2.X -= player2Speed;
            }
            if (rightArrowDown == true && player2.X <500)
            {
                player2.X += player2Speed;
            }


           //PlayerIntersectonWithPoints
            if(player1.IntersectsWith (point))
            {
                point.X = random.Next(80,420);
                point.Y = random.Next(20, 400);
                player1Score++;
                p1Score.Text = $"{player1Score}";
            }
            if (player2.IntersectsWith(point))
            {
                point.X = random.Next(80, 420);
                point.Y = random.Next(20, 400);
                player2Score++;
                p2Score.Text = $"{player2Score}";
            }
            //Win
            if(player1Score == 5)
            {
                gameState = "over";
                winLabel.Text = "Player 1 Wins!";
                player1Speed = 0;
                player2Speed = 0;
                Refresh();
           
            }
            if (player2Score == 5)
            {
                gameState = "over";
                winLabel.Text = "Player 2 Wins!";
                player1Speed = 0;
                player2Speed = 0;
                Refresh();
               
              
            }
            //PlayerIntersectonWithBoost
            if (player1.IntersectsWith(boost))
            {
                boost.X = random.Next(80, 420);
                boost.Y = random.Next(20, 400);
                player1Speed++;
            }
            if (player2.IntersectsWith(boost))
            {
                boost.X = random.Next(80, 420);
                boost.Y = random.Next(20, 400);
                player2Speed++;
            }
            // move balls 2
            for (int i = 0; i < balls2.Count(); i++)
            {
                //find the new postion of y based on speed 
                int x = balls2[i].X + ballSpeed;

                //replace the rectangle in the list with updated one using new y 
                balls2[i] = new Rectangle(balls2[i].Y, x, ballSize, ballSize);
            }
            //check to see if a new ball should be created 
            randValue2 = random2.Next(0, 101);

            if (randValue2 < 5) //
            {
                int y = random2.Next(10, this.Width - ballSize * 2);
                balls2.Add(new Rectangle(y, 10, ballSize, ballSize));
            }
            
            for (int i = 0; i < balls2.Count(); i++)
            {
                if (player1.IntersectsWith(balls2[i]))
                {
                    player1.X = 0; player1.Y = 170;

                    balls2.RemoveAt(i);
                }
            }
                for (int i = 0; i < balls2.Count(); i++)
                {
                    if (player2.IntersectsWith(balls2[i]))
                    {
                        player2.X = 500; player1.Y = 170;

                        balls2.RemoveAt(i);
                    }

                }
            for (int i = 0; i < balls.Count(); i++)
            {
                //find the new postion of y based on speed 
                int y = balls[i].Y + ballSpeed;

                //replace the rectangle in the list with updated one using new y 
                balls[i] = new Rectangle(balls[i].X, y, ballSize, ballSize);
            }
            //check to see if a new ball should be created 
            randValue = random.Next(0, 101);

            if (randValue < 5) //
            {
                int x = random.Next(10, this.Width - ballSize * 2);
                balls.Add(new Rectangle(x, 10, ballSize, ballSize));
            }

            for (int i = 0; i < balls.Count(); i++)
            {
                if (player1.IntersectsWith(balls[i]))
                {
                    player1.X = 0; player1.Y = 170;

                    balls.RemoveAt(i);
                }
            }
            for (int i = 0; i < balls.Count(); i++)
            {
                if (player2.IntersectsWith(balls[i]))
                {
                    player2.X = 500; player1.Y = 170;

                    balls.RemoveAt(i);
                }

            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (gameState == "waiting")
            {
                titleLabel.Text = "Square Chaser";
                subtitleLabel.Text = "Press space to start or Esc to exit";
                p1Score.Visible = false;
                p2Score.Visible = false;
            }
            else if (gameState == "running")
            {
                e.Graphics.FillRectangle(blueBrush, player1);
                e.Graphics.FillRectangle(redBrush, player2);
                e.Graphics.FillRectangle(blueBrush, border);
                e.Graphics.FillRectangle(blueBrush, border2);
                e.Graphics.FillRectangle(yellowBrush, boost);
                e.Graphics.FillRectangle(whiteBrush, point);
                p1Score.Visible = true;
                p2Score.Visible = true;
                //draw balls 
                for (int i = 0; i < balls.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, balls[i]);
                }
                for (int i = 0; i < balls2.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, balls2[i]);
                }

            }
            else if (gameState == "over")
            {
                gameTimer.Enabled = false;
                titleLabel.Text = "Game Over!";
                subtitleLabel.Text = "Press Esc to Exit or Space to Play Again";  
            }


              
              
            
        }
        private void GameInitalize()
        {
            gameState = "running";

            titleLabel.Text = "";
            subtitleLabel.Text = "";

            gameTimer.Enabled = true;
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
                case Keys.A:
                    aLeft = false;
                    break;
                case Keys.D:
                    dRight = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;


            }
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
                case Keys.A:
                    aLeft = true;
                    break;
                case Keys.D:
                    dRight = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitalize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }

                    break;
            }
        }
    }
}
