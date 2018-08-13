using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniSAD
{
    public partial class Login : Form
    {
        public String name { get; set; }
         MySqlConnection con = new MySqlConnection("Server = localhost; Database=sad;Uid=root;Pwd=root;") ;
        public Login()
        {
            InitializeComponent();
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
            
            timer1.Start();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.Size.Width >= 277)
                timer1.Stop();





            panel1.Size = new Size(panel1.Size.Width+1,panel1.Height);
            panel1.Size = new Size(panel1.Size.Width + 1, panel1.Height);
            panel1.Size = new Size(panel1.Size.Width + 1, panel1.Height);
            //panel1.Size = new Size(panel1.Size.Width + 1, panel1.Height);
            //  panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
            //panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
            //panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
            //panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);


        }
       public String username { get; set; }
        public String Admin { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
              
            }
           
        private void login()
        {

            con.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM user WHERE password ='" + textBox2.Text + "' AND username='" + textBox1.Text + "'", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 1)
            {
                name = dt.Rows[0]["firstname"].ToString();
                username = dt.Rows[0]["username"].ToString();
                Admin = dt.Rows[0]["AccountType"].ToString();
                if (dt.Rows[0]["accountstatus"].ToString() == "1")
                {
                    MessageBox.Show("Sorry but your account has been disabled");
                }
                else
                {
                    if (dt.Rows[0]["accounttype"].ToString() == "1")
                    {
                        this.Hide();
                        MainMenu mm = new MainMenu();
                        mm.button2.Visible = false;
                        mm.button2.Enabled = false;
                        mm.login = this;
                        mm.Location = this.Location;
                        mm.Show();



                        con.Close();
                    }
                    else
                    {
                        this.Hide();
                        MainMenu mm = new MainMenu();
                        mm.login = this;
                        mm.Location = this.Location;
                        mm.Show();


                      
                    }

                }
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
                con.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                login();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
