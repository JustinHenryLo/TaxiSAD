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
    public partial class MainMenu : Form
    {
        MySqlConnection con = new MySqlConnection("Server = localhost; Database=sad;Uid=root;Pwd=root;");
        public Login login { get; set; } 
        public MainMenu()
        {
            InitializeComponent();
        }
        Color MenuButtonDownColor = Color.White;
        Color MenuButtonUpColor = Color.Gray;
        Color MenuButtonHover = Color.DodgerBlue;
        #region 
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.ForeColor = MenuButtonDownColor;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = MenuButtonHover;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            button1.ForeColor = MenuButtonUpColor;
        }
        #endregion  button1
        #region
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.ForeColor = MenuButtonDownColor;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = MenuButtonHover;
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            button2.ForeColor = MenuButtonUpColor;
        }
        #endregion
        #region
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.ForeColor = MenuButtonDownColor;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = MenuButtonHover;
        }

        private void button3_MouseLeave_1(object sender, EventArgs e)
        {
            button3.ForeColor = MenuButtonUpColor;
        }
        #endregion
        #region
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.ForeColor = MenuButtonDownColor;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor = MenuButtonHover;
        }

        private void button4_MouseLeave_1(object sender, EventArgs e)
        {
            button4.ForeColor = MenuButtonUpColor;
        }
        #endregion
        #region
        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.ForeColor = MenuButtonDownColor;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.ForeColor = MenuButtonHover;
        }

        private void button5_MouseLeave_1(object sender, EventArgs e)
        {
            button5.ForeColor = MenuButtonUpColor;
        }
        #endregion
        #region
        bool clicked = false;
        bool move = false;
        private void button6_Click(object sender, EventArgs e)
        {
            if (clicked == false)
            {
                timer1.Start();
                clicked = true;
                move = true;

            }
            else if(clicked ==true)
            {
                timer1.Start();
                clicked = false;
                move = false;
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (move == true)
            {
                if (panel1.Location.X < -300)
                {
                    timer1.Stop();
                    
                }
                else
                {
                    panel1.Location = new Point(panel1.Location.X - 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X - 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X - 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X - 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X - 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X - 1, panel1.Location.Y);
                }
            }
            else
            {
                if (panel1.Location.X >= 0)
                {
                    timer1.Stop();

                }
                else
                {
                    panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
                    panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
                }
            }
           
        }


        #endregion
        #region profiles 
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Show();
            timer1.Start();
            clicked = true;
            move = true;
            try
            {
                refresh();
                
            }
            catch
            {
                con.Close();
            }
               
            
        }
        private void refresh()
        {
            con.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM user", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["userid"].Visible = false;
            dataGridView1.Columns["userid"].Visible = false;
            dataGridView1.Columns["userid"].Visible = false;
            
            con.Close();
        }
        #endregion
        private void button7_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == textBox5.Text)
            {
                String A = textBox1.Text;
                String B = textBox2.Text;
                String C = textBox3.Text;
                String D = textBox4.Text;
                String E = textBox5.Text;

                MySqlCommand com;


                    con.Open();
                if (checkBox1.Checked == true) {
                    if (comboBox1.Text == "Admin")
                    {
                         com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',0,0)", con);
                    }
                    else
                    {
                         com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',1,0)", con);
                    }

                }
                else
                {
                    if (comboBox1.Text == "Admin")
                    {
                         com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',0,1)", con);
                    }
                    else
                    {
                         com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',1,1)", con);
                    }

                }

                com.ExecuteNonQuery();
                    //MessageBox.Show("--------------");
                    con.Close();
                    refresh();
                    
                   
               
            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MySqlCommand com = new MySqlCommand("SELECT * FROM user WHERE firstname='" + dataGridView1.Rows[e.RowIndex].Cells["firstname"].Value.ToString() + "'  AND lastname= '" + dataGridView1.Rows[e.RowIndex].Cells["lastname"].Value.ToString() + "'", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                textBox1.Text = dt.Rows[0]["firstname"].ToString();
                textBox2.Text = dt.Rows[0]["middlename"].ToString();
                textBox3.Text = dt.Rows[0]["lastname"].ToString();
                textBox4.Text = dt.Rows[0]["username"].ToString();
                textBox5.Text = dt.Rows[0]["password"].ToString();
                if(dt.Rows[0]["accountype"].ToString()== "0")
                { comboBox1.Text = "Admin"; }
                else
                { comboBox1.Text = "Staff"; }
                if (dt.Rows[0]["accountstatus"].ToString() == "0")
                { checkBox1.Checked = true; }
                else
                { checkBox1.Checked = false; }
            }
            catch
            {

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
         
            timer1.Start();
            clicked = true;
            move = true;

        }
    }
}