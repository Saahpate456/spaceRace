using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player2 = new Rectangle(650, 575, 20, 20);
        Rectangle player1 = new Rectangle(150, 575, 20, 20);
        int playerSpeed = 7;


        Rectangle safezone = new Rectangle();
        int safezoneHeight = 50;

        //asteroids
        List<Rectangle> asteroids = new List<Rectangle>();
        List<Rectangle> asteroidsRight = new List<Rectangle>();
        int asteroidSpeeds = 5;
        int asteroidRightSpeeds = -5;
        int asteroidSize = 15;

        //Screen items
        int time = 750;
        int P1score = 0;
        int P2score = 0;

        //random
        Random randGen = new Random();
        int randValue;

        //gamestate
        string gameState = "waiting";

        //player movement
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        //colours
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);

        public Form1()
        {
            InitializeComponent();
            safezone = new Rectangle(0, this.Height - safezoneHeight, this.Width, safezoneHeight);
        }

        public void GameSetup()
        {
            gameState = "running";

            titleLabel.Text = "";
            winLabel.Text = "";

            gameLoop.Enabled = true;
            P1score = 0;
            P2score = 0;
            time = 750;

            player1.X = 150;
            player1.Y = 575;

            player2.X = 650;
            player2.Y = 575;
        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //move player 1 
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }
            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
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

            //Random asteroid
            int randValue = randGen.Next(1, 550);
            int randValue2 = randGen.Next(1, 550);
            int chance = randGen.Next(1, 500);
            if (chance < 35)
            {
                asteroids.Add(new Rectangle(3, randValue, asteroidSize, asteroidSize));
                asteroidsRight.Add(new Rectangle(this.Width, randValue2, asteroidSize, asteroidSize));
            }
            //move asteroid objects
            for (int i = 0; i < asteroids.Count; i++)
            {
                int x = asteroids[i].X + asteroidSpeeds;
                asteroids[i] = new Rectangle(x, asteroids[i].Y, asteroidSize, asteroidSize);
            }
            //move asteroid objects from right
            for (int i = 0; i < asteroidsRight.Count; i++)
            {
                int x = asteroidsRight[i].X - asteroidSpeeds;
                asteroidsRight[i] = new Rectangle(x, asteroidsRight[i].Y, asteroidSize, asteroidSize);
            }

            //generate a random value
            randValue = randGen.Next(1, 101);

            //generate new asteroid if it is time
            if (randValue < 3)
            {
                asteroids.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
                asteroidsRight.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
            }
            else if (randValue < 8)
            {
                asteroids.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
                asteroidsRight.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
            }
            else if (randValue < 20)
            {
                asteroids.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
                asteroidsRight.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
            }
            
            //remove asteroid if it goes off the screen
            for (int i = 0; i < asteroids.Count; i++)
            {
                if (asteroids[i].X >= this.Width)
                {
                    asteroids.RemoveAt(i);
                }
            }
            //remove asteroidRight if it goes off the screen
            for (int i = 0; i < asteroidsRight.Count; i++)
            {
                if (asteroidsRight[i].X <= 0)
                {
                    asteroidsRight.RemoveAt(i);
                }
            }

            //Check for collision
            for (int i = 0; i < asteroids.Count; i++)
            {
                if (player2.IntersectsWith(asteroids[i]))
                {
                    player2.X = 650;
                    player2.Y = 575;
                    asteroids.RemoveAt(i);
                }
                if (player1.IntersectsWith(asteroids[i]))
                {
                    player1.X = 150;
                    player1.Y = 575;
                    asteroids.RemoveAt(i);
                }
                //if (asteroids[i].IntersectsWith(asteroidsRight[i]))
                //{
                //    asteroids.RemoveAt(i);
                //    asteroidsRight.RemoveAt(i);
                //}
            }
            //check for asteroidRight collisions
            for (int i = 0; i < asteroidsRight.Count; i++)
                {
                    if (player2.IntersectsWith(asteroidsRight[i]))
                    {
                        player2.X = 650;
                        player2.Y = 575;
                        asteroidsRight.RemoveAt(i);
                    }
                    if (player1.IntersectsWith(asteroidsRight[i]))
                    {
                        player1.X = 150;
                        player1.Y = 575;
                        asteroidsRight.RemoveAt(i);
                    }
                //if (asteroidsRight[i].IntersectsWith(asteroids[i]))
                //{
                //    asteroids.RemoveAt(i);
                //    asteroidsRight.RemoveAt(i);
                //}
            }
            //Give player points
            if (player2.Y < 0 || player2.Y > this.Height - player2.Height)
            {
                P2score = P2score + 1;
                player2.X = 650;
                player2.Y = 575;
            }
            //Give player points
            if (player1.Y < 0 || player1.Y > this.Height - player1.Height)
            {
                P1score = P1score + 1;
                player1.X = 150;
                player1.Y = 575;
            }

            //determine winner
            if (P1score > P2score)
            {
                
            }

            //decreace time
            time--;

            //end game if time runs out
            if (time <= 0)
            {
                gameLoop.Enabled = false;
                gameState = "over";
            }
            Refresh();
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
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameSetup();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        this.Close();
                    }
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
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                timeLabel.Text = "";
                p1Score.Text = "";
                p2Score.Text = "";
                winLabel.Text = "";

                titleLabel.Text = "Space Race";
                subtitleLabel.Text = "Press Space to Start or Esc to Exit";
            }
            else if (gameState == "running"){
                //update labels
                timeLabel.Text = $"{time}";
                p1Score.Text = $"{P1score}";
                p2Score.Text = $"{P2score}";

                titleLabel.Text = "";
                subtitleLabel.Text = "";

                //draw players
                e.Graphics.FillRectangle(redBrush, player1);
                e.Graphics.FillRectangle(yellowBrush, player2);

                //draw asteroids
                for (int i = 0; i < asteroids.Count; i++)
                {
                    e.Graphics.FillRectangle(grayBrush, asteroids[i]);
                }
                for (int i = 0; i < asteroidsRight.Count; i++)
                {
                    e.Graphics.FillRectangle(grayBrush, asteroidsRight[i]);
                }

                ////draw safezone
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(155, 155, 155, 155)), safezone);
            }
            else if (gameState == "over")
            {
                timeLabel.Text = "";
                p1Score.Text = "";
                p2Score.Text = "";
                if (P1score > P2score)
                {
                    winLabel.Text = "Player 1 wins!";
                }
                else if (P2score > P1score)
                {
                    winLabel.Text = "Player 2 wins!";
                }
                else
                {
                    winLabel.Text = "It's a tie\n, play again to \ndecide a winner!";
                }

                titleLabel.Text = "Game Over";
                subtitleLabel.Text = "Press Space to Start or Esc to Exit";
            }
        }
    }
}
