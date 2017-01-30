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
            if (button2.Location.X <= -489)
                timer1.Stop();
                
            
               

        
            button2.Location = new Point(button2.Location.X - 1, button2.Location.Y);
            button2.Location = new Point(button2.Location.X - 1, button2.Location.Y);
            button2.Location = new Point(button2.Location.X - 1, button2.Location.Y);
            button2.Location = new Point(button2.Location.X - 1, button2.Location.Y);
            button2.Location = new Point(button2.Location.X - 1, button2.Location.Y);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM user WHERE password ='" + textBox2.Text + "' AND username='" + textBox1.Text+"' AND Accountstatus = 0" , con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    MainMenu mm = new MainMenu();
                    mm.login = this;
                    mm.Location = this.Location;
                    mm.Show();
                    

                 con.Close();
                }
                else
                {
                 MessageBox.Show("Incorrect username or password");
                 con.Close();
                }

                
            }
            catch (Exception ee) {

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
