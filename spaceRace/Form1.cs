using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(650, 575, 20, 20);
        Rectangle player2 = new Rectangle(150, 575, 20, 20);
        int playerSpeed = 7;


        Rectangle safezone = new Rectangle();
        int safezoneHeight = 50;

        //asteroids
        List<Rectangle> asteroids = new List<Rectangle>();
        List<int> asteroidSpeeds = new List<int>();

        int asteroidSize = 15;

        //random
        Random randGen = new Random();
        int randValue = 0;

        //player movement
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        //colours
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush grayBrush = new SolidBrush (Color.Gray);

        public Form1()
        {
            InitializeComponent();
            //safezone = new Rectangle(0, this.Height - safezoneHeight, this.Width, safezoneHeight);
            gameLoop.Enabled = true;
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

            //move ball objects
            for (int i = 0; i < asteroids.Count; i++)
            {
                int y = asteroids[i].X + asteroidSpeeds[i];
                asteroids[i] = new Rectangle(asteroids[i].Y, y, asteroidSize, asteroidSize);
            }
            //generate a random value
            randValue = randGen.Next(1, 101);

            //generate new ball if it is time
            if (randValue < 3)
            {
                asteroids.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
                asteroidSpeeds.Add(4);
            }
            else if (randValue < 8)
            {
                asteroids.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
                asteroidSpeeds.Add(8);
            }
            else if (randValue < 20)
            {
                asteroids.Add(new Rectangle(randGen.Next(0, this.Width - asteroidSize), 0, asteroidSize, asteroidSize));
                asteroidSpeeds.Add(12);
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
            //draw players
            e.Graphics.FillRectangle(redBrush, player1);
            e.Graphics.FillRectangle(yellowBrush, player2);

            //draw asteroids
            for (int i = 0; i < asteroids.Count; i++)
            {
                e.Graphics.FillRectangle(grayBrush, asteroids[i]);
            }


            //////draw safezone
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(155, 155, 155, 155)), safezone);

            //////draw safezone
            ////e.Graphics.FillRectangle(grayBrush, 0, this.Height - safezoneHeight,
            ////    this.Width, safezoneHeight);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
