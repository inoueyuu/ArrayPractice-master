using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayPractice
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();
        const int LabelMax = 10;
        int[] vx = new int[LabelMax];
        int[] vy = new int[LabelMax];
        Label[] labels = new Label[LabelMax];
        int score = 100;

        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0;i < LabelMax; i++)
            {
                vx[i] = rand.Next(-20, 21);
                vy[i] = rand.Next(-20, 21);
                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "★";
                Controls.Add(labels[i]);
                labels[i].Left = rand.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = rand.Next(ClientSize.Height - labels[i].Height);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score--;
            scoreLabel.Text = $"Score {score:000}";
            Point fpos = PointToClient(MousePosition);

            for (int i = 0;i < LabelMax; i++)
            {
                
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];
                if (labels[i].Left < 0)
                {
                    vx[i] = Math.Abs(vx[i]);
                }
                if (labels[i].Top < 0)
                {
                    vy[i] = Math.Abs(vy[i]);
                }
                if (labels[i].Right > ClientSize.Width)
                {
                    vx[i] = -Math.Abs(vx[i]);
                }
                if (labels[i].Bottom > ClientSize.Height)
                {
                    vy[i] = -Math.Abs(vy[i]);
                }
                if (    (fpos.X >= labels[i].Left)
                     && (fpos.X < labels[i].Right)
                     && (fpos.Y >= labels[i].Top)
                     && (fpos.Y < labels[i].Bottom))
                {
                    labels[i].Visible = false;
                }


            }


            if (label1.Visible == false && label2.Visible == false && label3.Visible == false)
            {
                timer1.Enabled = false;
                label4.Visible = true;
            }
            /*if (score == 0)
            {
                timer1.Enabled = false;
                label5.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }*/
        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if(i == 2)
                {
                    continue;
                }
                if(i == 5)
                {
                    break;
                }
                MessageBox.Show("" + i);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}