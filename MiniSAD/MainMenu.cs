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


        #region//buttonColor
        Color MenuButtonDownColor = Color.White;
        Color MenuButtonUpColor = Color.Gray;
        Color MenuButtonHover = Color.DodgerBlue;
        #endregion
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
        #region//button
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
        #region//logout

        #endregion
        #region//sql
        private void refresh()
        {
            if (login.Admin == "1")
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
            else
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("SELECT * FROM user WHERE username != '"+login.username+"'", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["userid"].Visible = false;
                dataGridView1.Columns["userid"].Visible = false;
                dataGridView1.Columns["userid"].Visible = false;

                con.Close();

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "") { MessageBox.Show("Please fill in all fields"); }
            else
            {
                try
               {

                    String A = textBox1.Text;
                    String B = textBox2.Text;
                    String C = textBox3.Text;
                    String D = textBox4.Text;
                    String E = textBox5.Text;

                    MySqlCommand com;


                    con.Open();
                    if (checkBox1.Checked == true)
                    {
                        if (comboBox1.Text == "Admin")

                            com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',0,0)", con);

                        else

                            com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',1,0)", con);


                    }
                    else
                    {
                        if (comboBox1.Text == "Admin")

                            com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',0,1)", con);

                        else

                            com = new MySqlCommand("INSERT INTO user (firstname,middlename,lastname,username, password,accounttype,accountstatus) VALUES ('" + A + "','" + B + "','" + C + "','" + D + "','" + E + "',1,1)", con);


                    }


                    com.ExecuteNonQuery();

                    con.Close();
                    refresh();
                    reset();

                }




                catch
                {
                    MessageBox.Show("Username is already used");
                    con.Close();
                }
            }
        }
        int selectedID;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // MySqlCommand com = new MySqlCommand("SELECT * FROM user WHERE firstname='" + dataGridView1.Rows[e.RowIndex].Cells["firstname"].Value.ToString() + "'  AND lastname= '" + dataGridView1.Rows[e.RowIndex].Cells["lastname"].Value.ToString() + "'", con);
                //MySqlDataAdapter adp = new MySqlDataAdapter(com);
                //DataTable dt = new DataTable();
                //adp.Fill(dt);
                fromClick = true;
                selectedID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["userid"].Value.ToString());

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["firstname"].Value.ToString();//dt.Rows[0]["firstname"].ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["middlename"].Value.ToString();//dt.Rows[0]["middlename"].ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["lastname"].Value.ToString();//dt.Rows[0]["lastname"].ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();//dt.Rows[0]["username"].ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();//dt.Rows[0]["password"].ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["accounttype"].Value.ToString() == "0")
                { comboBox1.Text = "Admin"; }
                else
                { comboBox1.Text = "Staff"; }
                if (dataGridView1.Rows[e.RowIndex].Cells["accountstatus"].Value.ToString() == "0")
                { checkBox1.Checked = true; }
                else
                { checkBox1.Checked = false; }
                Console.WriteLine(selectedID);
                Validate();
               

            }
            catch
            {

            }
        }
        #endregion
        #region//animation

        bool mode = false;
        private void timer1_Tick_1(object sender, EventArgs e)
        {


            if (mode == true)
            {

                if (panel1.Location.X >= -24)
                {
                    timer1.Stop();
                    mode = false;
                }
                else
                {
                    panel1.Location = new Point(panel1.Location.X + 15, panel1.Location.Y);

                }
            }
            else
            {

                if (panel1.Location.X <= -300)
                {
                    timer1.Stop();
                    mode = true;
                }
                else
                {
                    //int x = 0;
                    //while (x != 15) {
                        panel1.Location = new Point(panel1.Location.X - 15, panel1.Location.Y);
                     //   x++;
                   // }
                    


                }
            }
        }
        #endregion
        #region//data validation
        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            con.Open();
            try
            {
                MySqlCommand com= new MySqlCommand();

                Console.WriteLine(selectedID);
                if (comboBox1.Text == "Admin") {
                    
                    if (checkBox1.Checked == true)
                    {
                        com = new MySqlCommand("UPDATE user SET UserName= '" + textBox4.Text + "', Password= '" + textBox5.Text + "', FirstName= '" + textBox1.Text + "',LastName= '" + textBox3.Text + "', MiddleName= '" + textBox2.Text + "', AccountType= 0, AccountStatus= 0 WHERE UserID= " + selectedID, con);
                    }
                    else
                    {
                        com = new MySqlCommand("UPDATE user SET UserName= '" + textBox4.Text + "', Password= '" + textBox5.Text + "', FirstName= '" + textBox1.Text + "',LastName= '" + textBox3.Text + "', MiddleName= '" + textBox2.Text + "', AccountType= 0, AccountStatus= 1 WHERE UserID= " + selectedID, con);
                    }
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        com = new MySqlCommand("UPDATE user SET UserName= '" + textBox4.Text + "', Password= '" + textBox5.Text + "', FirstName= '" + textBox1.Text + "',LastName= '" + textBox3.Text + "', MiddleName= '" + textBox2.Text + "', AccountType= 1, AccountStatus= 0 WHERE UserID= " + selectedID, con);
                    }
                    else
                    {
                        com = new MySqlCommand("UPDATE user SET UserName= '" + textBox4.Text + "', Password= '" + textBox5.Text + "', FirstName= '" + textBox1.Text + "',LastName= '" + textBox3.Text + "', MiddleName= '" + textBox2.Text + "', AccountType= 1, AccountStatus= 1 WHERE UserID= " + selectedID, con);
                    }
                }


                Console.Write(com.ToString());
                com.ExecuteNonQuery();
                con.Close();
                refresh();
                fromClick = false;
                reset();
            }
            catch
            {
                MessageBox.Show("Please change username");
                con.Close();
                refresh();
            }
        }
        private void validate() {
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                {
                    button8.BackColor = Color.Silver;
                    button8.Enabled = false;
                    button9.BackColor = Color.Silver;
                    button9.Enabled = false;
                }
                else
                {
                    if (fromClick == true)
                    {
                        button8.BackColor = Color.Silver;
                        button8.Enabled = false;
                        button9.BackColor = Color.White;
                        button9.Enabled = true;
                        //fromClick = false;


                    }
                    else
                    {
                        button8.BackColor = Color.White;
                        button8.Enabled = true;
                        button9.BackColor = Color.Silver;
                        button9.Enabled = false;
                    }
                }

            }
        }

        bool fromClick= false;////////////////////////data view_click/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            validate();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            validate();
        }
        bool check = true;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            check = !check;
            validate();
        }
        #endregion
        #region //random



        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.TabStop = true;
            textBox2.TabStop = true;
            textBox3.TabStop = true;
            textBox4.TabStop = true;
            textBox5.TabStop = true;
           // button7.TabStop = true;
            button8.TabStop = true;
            button9.TabStop = true;
            button10.TabStop = true;
            comboBox1.TabStop = true;
            checkBox1.TabStop = true;


            textBox1.TabIndex = 1;
            textBox2.TabIndex = 2;
            textBox3.TabIndex = 3;
            textBox4.TabIndex = 4;
            textBox5.TabIndex = 5;
            comboBox1.TabIndex = 6;
            checkBox1.TabIndex = 7;
            button8.TabIndex = 9;
            button9.TabIndex = 10;
            button10.TabIndex = 11;


            mode = false;
            panel3.Show();
            panel4.Hide();
            //panel 5
            //panel 6
            timer1.Start();


        }
        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
            checkBox1.Checked = true;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            reset();
            validate();
        }
        #endregion
        #region //unused
        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            refresh();
            label7.Text = label7.Text + " " + login.name;
            validate();
          
            

        }
        private void button7_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = false;
            panel3.Hide();
            panel4.Show();
            //panel 5
            //panel 6
            timer1.Start();
        }



        #endregion

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Show();
            
        }

        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
         
        }
    }
}
   // if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
           