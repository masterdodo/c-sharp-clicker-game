using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Clicker
{
    public partial class Form1 : Form
    {
        int score = 0;
        int klik = 1;
        int sec = 0;
        public Form1()
        {
            updatescore();
            InitializeComponent();
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            label7.Text = Convert.ToString(klik);
            label16.Text = Convert.ToString(sec);
            timer1.Enabled = true;
        }
        
        void updatescore()
        {
            SQLiteConnection conn = new SQLiteConnection("data source=clicker_db.sqlite");

            conn.Open();
            using (SQLiteCommand com = new SQLiteCommand(conn))
            {
                com.CommandText = "SELECT * FROM cookies;";
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    if (LoginForm.user == reader.GetString(1))
                    {
                       score = reader.GetInt32(2);
                       sec = reader.GetInt32(3);
                       klik = reader.GetInt32(4);
                    }
                    else { }
                }
                com.Dispose();
            }
            conn.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            score += klik;
            label2.Text = Convert.ToString(score);
            label7.Text = Convert.ToString(klik);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (score >= 100)
            {
                klik += 2;
                score -= 100;
                label7.Text = Convert.ToString(klik);
                label2.Text = Convert.ToString(score);
            }
            else { }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (score >= 500)
            {
                klik += 5;
                score -= 500;
                label7.Text = Convert.ToString(klik);
                label2.Text = Convert.ToString(score);
            }
            else { }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (score >= 1000)
            {
                klik += 10;
                score -= 1000;
                label7.Text = Convert.ToString(klik);
                label2.Text = Convert.ToString(score);
            }
            else { }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (score >= 5000)
            {
                klik += 50;
                score -= 5000;
                label7.Text = Convert.ToString(klik);
                label2.Text = Convert.ToString(score);
            }
            else { }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (score >= 10000)
            {
                klik += 100;
                score -= 10000;
                label7.Text = Convert.ToString(klik);
                label2.Text = Convert.ToString(score);
            }
            else { }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (score >= 100000)
            {
                klik += 1000;
                score -= 100000;
                label7.Text = Convert.ToString(klik);
                label2.Text = Convert.ToString(score);
            }
            else { }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (score >= 100)
            {
                sec += 2;
                score -= 100;
                label2.Text = Convert.ToString(score);
                label16.Text = Convert.ToString(sec);
            }
            else { }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (score >= 500)
            {
                sec += 5;
                score -= 500;
                label2.Text = Convert.ToString(score);
                label16.Text = Convert.ToString(sec);
            }
            else { }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (score >= 1000)
            {
                sec += 10;
                score -= 1000;
                label2.Text = Convert.ToString(score);
                label16.Text = Convert.ToString(sec);
            }
            else { }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (score >= 100000000)
            {
                sec += 1000000;
                klik += 1000000;
                score -= 100000000;
                label7.Text = Convert.ToString(klik);
                label2.Text = Convert.ToString(score);
                label16.Text = Convert.ToString(sec);
            }
            else { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score += sec;
            label2.Text = Convert.ToString(score);
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("data source=clicker_db.sqlite");

            conn.Open();
            using (SQLiteCommand com = new SQLiteCommand(conn))
            {
                com.CommandText = "SELECT * FROM cookies;";
                SQLiteDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show("Polje ID: " + reader.GetInt32(0));
                    MessageBox.Show("Polje User: " + reader.GetString(1));
                    MessageBox.Show("Polje Cookies: " + reader.GetInt64(2));
                    MessageBox.Show("Polje Per second: " + reader.GetInt64(3));
                    MessageBox.Show("Polje Per click: " + reader.GetInt64(4));
                }
                com.Dispose();
            }
            conn.Close();

        }*/

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
            SQLiteConnection conn = new SQLiteConnection("data source=clicker_db.sqlite");

            conn.Open();
            using (SQLiteCommand com = new SQLiteCommand(conn))
            {
                com.CommandText = "UPDATE main.cookies SET cookie_amount = ?1, cookiepersecond = ?2, cookieperclick = ?3 WHERE  ID = 1 " +
                    "Parameters: " +
                    "param 1(integer): 2 " +
                    "param 2(integer): 2 " +
                    "param 3(integer): 2";

                com.Dispose();
            }
            conn.Close();
            */

            Application.Exit();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("data source=clicker_db.sqlite");

            conn.Open();
            using (SQLiteCommand com = new SQLiteCommand(conn))
            {
                string komanda = "UPDATE cookies SET cookie_amount = " + score + ", cookiepersecond = " + sec + ", cookieperclick = " + klik + " WHERE ID = " + LoginForm.ID + ";";
                //MessageBox.Show(komanda);  //testing
                com.CommandText = komanda;
                com.ExecuteNonQuery();
                com.Dispose();
            }
            conn.Close();
        }
    }
}
