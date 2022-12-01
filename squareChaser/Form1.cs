using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace squareChaser
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(10, 170, 20, 20);
        Rectangle player2 = new Rectangle(480, 170, 20, 20);
        Rectangle point = new Rectangle(295, 195, 10, 10);
        Rectangle border = new Rectangle(60, 0, 10, 500);
        Rectangle border2 = new Rectangle(455, 0, 10, 500);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 6;
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
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }
            if (aLeft == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }
            if (dRight == true && player1.X < 435)
            {
                player1.X += playerSpeed;
            }
        

            //move player 2 
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftArrowDown == true && player2.X >70)
            {
                player2.X -= playerSpeed;
            }
            if (rightArrowDown == true && player2.X <500)
            {
                player2.X += playerSpeed;
            }


           
            if(player1.IntersectsWith (point))
            {

            }


            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(redBrush, player2);
            e.Graphics.FillRectangle(blueBrush, border);
            e.Graphics.FillRectangle(blueBrush, border2);

             //CheckIfBothPlayersAreTouchingTheWallToBegin
                if (player1.IntersectsWith(border) && player2.IntersectsWith(border2))
                {

                if (aLeft == true && player1.X > 70)
                {
                    player1.X -= playerSpeed;
                }
                if (dRight == true && player1.X < 435)
                {
                    player1.X += playerSpeed;
                }

                if (leftArrowDown == true && player2.X > 70)
                {
                    player2.X -= playerSpeed;
                }
                if (rightArrowDown == true && player2.X < 435)
                {
                    player2.X += playerSpeed;
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
