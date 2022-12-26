using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trex_Najam_Mshahid_bilal
{
   
    public partial class Form1 : Form
    {
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
        public Form1()
        {
            InitializeComponent();
            GameReset();
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            trex.Top += jumpSpeed;
            txtScore.Text = "Score: " + score;
            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;

            }
            else
            {
                jumpSpeed = 12;
            }
            if (trex.Top > 281 && jumping == false)
            {
                force = 12;
                trex.Top = 280;
                jumpSpeed = 0;
            }

            //moving the obstacles

            foreach (Control x in this.Controls)

            {
                if(x is PictureBox && (string)x.Tag=="obstacles")
                {
                    x.Left -= obstacleSpeed;
                    if(x.Left< -100)
                    {
                        x.Left=this.ClientSize.Width + rand.Next(200,500) + (x.Width * 15);
                        score++;
                    }

                    //checking if the obstacle collapses with diano Mshahaid
                    if(trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        trex.Image = Properties.Resources.dead;
                        txtScore.Text += "press R to restart the game";
                        isGameOver = true;
                    }
                }
            
            }
        
        
        }


        private void keyisdown(object sender, KeyEventArgs e)
        {   //here checking the "space" key  if pressed then we will make it jump M.Shahid
            if(e.KeyCode==Keys.Space && jumping==false)
            {
                jumping = true;
            }
        }

       
        private void keyisup(object sender, KeyEventArgs e)
        { //here will check whether a dianaso is in jump postion so we will make it
          // come back to floor Mshahid
            if (jumping==true)
            {
                jumping = false;
            }
            // when the R button is pressed and the status of game is gameover Mshahid
          
            if(e.KeyCode==Keys.R && isGameOver == true)
            {
                GameReset();
            }
        }
        private void GameReset()
        {
            pictureBox3.Left = 700;
            pictureBox4.Left = 1000;
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            txtScore.Text = "score: " + score;
            trex.Image = Properties.Resources.running;
            isGameOver = false;
            trex.Top = 280;
            foreach(Control x in this.Controls)
            {
               
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    position = this.ClientSize.Width + rand.Next(500,800) + (x.Width * 10);  
                    x.Left = position;
                }

                        }
            gameTimer.Start();


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
