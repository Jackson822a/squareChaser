﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
     

        int player1Score = 0;
        int player2Score = 0;

     
        int player1Speed = 6;
        int player2Speed = 6;
        int ballXSpeed = -6;
        int ballYSpeed = 6;

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

        public Form1()
        {
            InitializeComponent();
            gameTimer.Enabled = true;
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
            if(player1Score == 10)
            {
                winLabel.Text = "Player 1 Wins!";
                player1Speed = 0;
                player2Speed = 0;
                Refresh();
                Thread.Sleep(2000);
                Application.Exit();
            }
            if (player2Score == 10)
            {
                winLabel.Text = "Player 2 Wins!";
                player1Speed = 0;
                player2Speed = 0;
                Refresh();
                Thread.Sleep(2000);
                Application.Exit();
              
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

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(blueBrush, border);
            e.Graphics.FillRectangle(blueBrush, border2);
            e.Graphics.FillRectangle(yellowBrush, boost);

            //CheckIfBothPlayersAreTouchingTheWallToBegin
            if (player1.IntersectsWith(border) && player2.IntersectsWith(border2))
                {

                if (aLeft == true && player1.X > 70)
                {
                    player1.X -= player1Speed;
                }
                if (dRight == true && player1.X < 435)
                {
                    player1.X += player1Speed;
                }

                if (leftArrowDown == true && player2.X > 70)
                {
                    player2.X -= player2Speed;
                }
                if (rightArrowDown == true && player2.X < 435)
                {
                    player2.X += player2Speed;
                }
            }
              
                e.Graphics.FillRectangle(whiteBrush, point);
            
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
            }
        }
    }
}
