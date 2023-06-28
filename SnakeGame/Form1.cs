using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private readonly List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        public Form1()
        {
            InitializeComponent();

            //sets setting to default
            new Setting();

            //sets game speed an starts timer
            gameTimer.Interval = 1000 / Setting.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //starts new game
            StartGame();
        }
        private void StartGame()
        {
            lblGameOver.Visible = false;

            //sets setting to default
            new Setting();

            //create new player object
            Snake.Clear();
            Circle head = new Circle();
            Snake.Add(head);

            lblScore.Text = Setting.Score.ToString();
            GenerateFood();


        }

       
        private void GenerateFood()
        {
            int maxXpos = pbCanvas.Size.Width / Setting.Width;
            int maxYpos = pbCanvas.Size.Height / Setting.Height;

            Random random = new Random();

            //checks the food not being in any of snakes circle
            for (int i = 0; i < Snake.Count; i++)
            {
                do
                {
                    //Generates the food in random position
                    food = new Circle { X = random.Next(0, maxXpos), Y = random.Next(0, maxYpos) };
                }

                while (food.X == Snake[i].X || food.Y == Snake[i].Y);
            }
 
        }

        //Resets the snake speed and the pictures to default
        private void Reset()
        {

            gameTimer.Interval = 1000 / Setting.Speed;
            lblSpeed.ForeColor = Color.Green;
            lblSpeed.Text = "Slow";
            label4.Text = "->   1000";
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;

        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Setting.GameOver)
            {
                //checks if "Enter" is pressed
                if (Input.KeyPressed(Keys.Enter))
                {
                    Reset();
                    StartGame();
                }
                //checks if "Escape" is pressed
                else if (Input.KeyPressed(Keys.Escape))
                {
                    Application.Exit();
                }
            }
            else
            {
                //if "right" button is clicked and the snake was not going left  
                if (Input.KeyPressed(Keys.Right) && Setting.Direction != Direction.Left)
                    Setting.Direction = Direction.Right; //snake turns right if the condition was true

                //if "left" button is clicked and the snake was not going right
                else if (Input.KeyPressed(Keys.Left) && Setting.Direction != Direction.Right)
                    Setting.Direction = Direction.Left; //snake turns left if the condition was true 

                //if "right" button is clicked and the snake was not going left  
                else if (Input.KeyPressed(Keys.Up) && Setting.Direction != Direction.Down)
                    Setting.Direction = Direction.Up;//snake turns up if the condition was true

                //if "down" button is clicked and the snake was not going up
                else if (Input.KeyPressed(Keys.Down) && Setting.Direction != Direction.Up)
                    Setting.Direction = Direction.Down; //snake turns down if the condition was true


                MovePlayer();
                SpeedChange();
            }

            pbCanvas.Invalidate();
        }

        private void SpeedChange()
        {
            //controlling speed of the snake by changing "timer.interval" value
            switch (lblScore.Text)
            {

                case "1000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 5);
                    lblSpeed.ForeColor = Color.DarkOrange;
                    lblSpeed.Text = "Medium";
                    label4.Text = "->   2500";
                    break;

                case "1300":

                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                    break;

                case "2300":

                    pictureBox2.Visible = false;
                    pictureBox3.Visible = true;
                    break;

                case "2500":
                    gameTimer.Interval = 1000 / (Setting.Speed + 8);
                    lblSpeed.ForeColor = Color.DarkRed;
                    lblSpeed.Text = "Fast";
                    label4.Text = "->   4000";
                    break;

                case "4000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 2);
                    lblSpeed.ForeColor = Color.Green;
                    lblSpeed.Text = "Slow";
                    label4.Text = "->   4500";
                    break;

                case "4500":
                    gameTimer.Interval = 1000 / (Setting.Speed + 5);
                    lblSpeed.ForeColor = Color.DarkOrange;
                    lblSpeed.Text = "Medium";
                    label4.Text = "->   5500";
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = true;
                    break;

                case "5500":
                    gameTimer.Interval = 1000 / (Setting.Speed + 8);
                    lblSpeed.ForeColor = Color.DarkRed;
                    lblSpeed.Text = "Fast";
                    label4.Text = "->   7000";
                    break;

                case "6000":

                    pictureBox4.Visible = false;
                    pictureBox5.Visible = true;
                    break;

                case "7000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 13);
                    lblSpeed.ForeColor = Color.Red;
                    lblSpeed.Text = "Fast 2x";
                    label4.Text = "->   8500";
                    break;

                case "8300":

                    pictureBox5.Visible = false;
                    pictureBox6.Visible = true;
                    break;

                case "8500":
                    gameTimer.Interval = 1000 / (Setting.Speed + 2);
                    lblSpeed.ForeColor = Color.Green;
                    lblSpeed.Text = "Slow";
                    label4.Text = "->   10000";
                    break;

                case "10000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 5);
                    lblSpeed.ForeColor = Color.DarkOrange;
                    lblSpeed.Text = "Medium";
                    label4.Text = "->   13000";
                    pictureBox6.Visible = false;
                    pictureBox7.Visible = true;
                    break;

                case "13000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 8);
                    lblSpeed.ForeColor = Color.DarkRed;
                    lblSpeed.Text = "Fast";
                    label4.Text = "->   15000";
                    break;

                case "15000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 2);
                    lblSpeed.ForeColor = Color.Green;
                    lblSpeed.Text = "Slow";
                    label4.Text = "->   16000";
                    pictureBox7.Visible = false;
                    pictureBox8.Visible = true;
                    break;

                case "16000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 5);
                    lblSpeed.ForeColor = Color.DarkOrange;
                    lblSpeed.Text = "Medium";
                    label4.Text = "->   17500";
                    break;

                case "17500":
                    gameTimer.Interval = 1000 / (Setting.Speed + 13);
                    lblSpeed.ForeColor = Color.Red;
                    lblSpeed.Text = "Fast 2x";
                    label4.Text = "->   19000";
                    break;

                case "19000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 5);
                    lblSpeed.ForeColor = Color.DarkOrange;
                    lblSpeed.Text = "Medium";
                    label4.Text = "->   20000";
                    break;

                case "20000":
                    gameTimer.Interval = 1000 / (Setting.Speed + 2);
                    lblSpeed.ForeColor = Color.Green;
                    lblSpeed.Text = "Slow";
                    label4.Text = "->   -";
                    break;

            }

        }
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //move head
                if (i == 0)
                {
                    switch (Setting.Direction)
                    {

                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;

                    }

                    //get maximum X and Y positions
                    int maxX = pbCanvas.Size.Width / Setting.Width;
                    int maxY = pbCanvas.Size.Height / Setting.Height;

                    //checks if the snake hits With Game Border
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X >= maxX || Snake[i].Y >= maxY)
                    {
                        pictureBox10.Visible = true;
                        Die();
                    
                    }

                    //checks if the snake hits With its body
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            pictureBox9.Visible = true;
                            Die();
                        }
                    }

                    //checks if the snake's head eats the food 
                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        Eat();

                    }

                }
                else
                {
                    //Move Body of snake 
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Eat()
        {
            //Creats a Circle
            Circle circle = new Circle
            {
                X = Snake[Snake.Count - 1].X, 
                Y = Snake[Snake.Count - 1].Y
            };

           Snake.Add(circle); //Adds the circle to the body

            //Update Score
            Setting.Score += Setting.Points;
            lblScore.Text = Setting.Score.ToString();

            GenerateFood(); 

            //sets the best score label
            if (Convert.ToInt32(lblBestScore.Text) > Convert.ToInt32(lblScore.Text))
                return;
            else
            {

                lblBestScore.Text = Setting.Score.ToString();
            }

        }

        private void Die()
        {
            
            Setting.GameOver = true;

        }

        private void PbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (!Setting.GameOver)
            {
                //set color of snake 
                //draw snake

                for (int i = 0; i < Snake.Count; i++)
                {
                    Brush snakeColor;
                    if (i == 0)
                        snakeColor = Brushes.Black; //draw head
                    else if(i==Snake.Count-1)
                        snakeColor = Brushes.Green; //draw Tail
                    else
                        snakeColor = Brushes.SaddleBrown; // draw rest of body

                    //draw snake
                    graphics.FillEllipse(snakeColor,
                        new Rectangle(Snake[i].X * Setting.Width,
                         Snake[i].Y * Setting.Height,
                         Setting.Width, Setting.Height));

                    //draw food
                    graphics.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Setting.Width,
                         food.Y * Setting.Height,
                         Setting.Width, Setting.Height));
                }
            }

            //Displays the Gameover label when "setting.Gameover" was true
            else
            {
                string gameOver = "GameOver \n\n Your Final Score is: " + Setting.Score + "\nPress [Enter] To Play Again\nPress [esc] To Exit";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}
