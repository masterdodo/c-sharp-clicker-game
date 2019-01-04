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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
        }

        public static int ID;
        public static string user;
        string password;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("data source=clicker_db.sqlite");
            user = textBox1.Text;
            password = textBox2.Text;

                conn.Open();
                using (SQLiteCommand com = new SQLiteCommand(conn))
                {
                    com.CommandText = "SELECT * FROM users;";
                    SQLiteDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        if(user == reader.GetString(1))
                    {
                        if(password == reader.GetString(2))
                        {
                            ID = reader.GetInt32(0);
                            Form1 mainForm = new Form1();
                            LoginForm loginForm = new LoginForm();
                            this.Hide();
                            mainForm.Show();
                        }
                        else
                        {
                            errorlabel.Text = "Napačno geslo.";
                        }
                    }
                    else
                    {
                        errorlabel.Text = "Ne obstaja uporabnik z imenom " + user;
                    }
//                        MessageBox.Show("Polje ID: " + reader.GetInt32(0));
//                        MessageBox.Show("Polje User: " + reader.GetString(1));
//                        MessageBox.Show("Polje Password: " + reader.GetString(2));
                    }
                //errorlabel.Text = "Ne obstaja uporabnik z imenom " + user;
                    com.Dispose();
                }
                conn.Close();
            }

    }
}
