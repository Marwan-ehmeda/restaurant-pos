using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace WindowsFormsApplication4
{
    public partial class Form8 : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        CurrencyManager manger;
        SqlCommandBuilder builder;
        public string admin;
        public static string n = "";
        public string tag = "";
        public string billNumber = "";
        public string cahser_id_active = "";
        public Form8()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int j = 1;
        int left = 4;
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "") { MessageBox.Show("الرجاء ادخال اسم المستخدم و كلمة الرمرو"); }

            else
            {

                if (j != 4)
                {

                    connection.Open();

                    cmd = new SqlCommand("select * from users where casher_password= '" + textBox8.Text + "' and casher_user_name='" + textBox7.Text + "'", connection);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        //if (Boolean.Parse(reader["status"].ToString()) != true)
                        //{
                            Form1 f = new Form1();
                            Form6 f6 = new Form6();
                             
                            f.admin = textBox7.Text;

                            //f6.casher_user_name = textBox7.Text;
                            //f6.casher_password = textBox8.Text;
                            f6.casher_id = int.Parse(reader["casher_id"].ToString());
                            f6.status = Boolean.Parse(reader["status"].ToString());


                            f6.ShowDialog();

                            connection.Close();

                            Profile p = new Profile();

                            p.casher_password = textBox8.Text;
                            p.casher_user_name = textBox7.Text;

                            this.Close();

                        }
                      




                    

                    else
                    {


                        j += 1;

                        MessageBox.Show((left -= 1).ToString() + " كلمة المرور  غير صحيحة عدد المحاولات المتبقية ");
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox7.Focus();
                        connection.Close();

                    }
                }
                else
                {

                    this.Close();
                }


            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
             
        }
        public int check_cashier_status()
        {
            connection.Close();
            connection.Open();
            string check_casheir_status = "select * from users where status = 1";
            cmd = new SqlCommand(check_casheir_status, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {

                cahser_id_active = reader["casher_id"].ToString();
                return int.Parse(cahser_id_active);


            }
            else
            {
                cahser_id_active = "0";
                return int.Parse(cahser_id_active);
            }
            connection.Close();


        }
        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox7.Text == "" || textBox8.Text == "") { MessageBox.Show("الرجاء ادخال اسم المستخدم و كلمة الرمرو"); }

                else
                {

                    if (j != 4)
                    {
                        connection.Close();
                            connection.Open();

                            cmd = new SqlCommand("select * from users where casher_password= '" + textBox8.Text + "' and casher_user_name='" + textBox7.Text + "'", connection);
                            reader = cmd.ExecuteReader();
                            reader.Read();
                            if (reader.HasRows)
                            {


                                Form1 f = new Form1();
                                Form6 f6 = new Form6();

                                f.admin = textBox7.Text;
                                f6.casher_id = int.Parse(reader["casher_id"].ToString());
                                f6.status = Boolean.Parse(reader["status"].ToString());

                                if (int.Parse(reader["casher_id"].ToString()) == check_cashier_status())
                                {
                                    MessageBox.Show(reader["casher_id"].ToString());
                                    MessageBox.Show(check_cashier_status().ToString());
                                    



                                    f6.ShowDialog();

                                    connection.Close();

                                    Profile p = new Profile();

                                    p.casher_password = textBox8.Text;
                                    p.casher_user_name = textBox7.Text;

                                    this.Close();
                                }

                                else
                                {

                                    if (check_cashier_status() <= 0)

                                    {
                                        MessageBox.Show(check_cashier_status().ToString());
                                        f6.ShowDialog();

                                        connection.Close();

                                        Profile p = new Profile();

                                        p.casher_password = textBox8.Text;
                                        p.casher_user_name = textBox7.Text;

                                        this.Close();
                                    }
                                    else {


                                        MessageBox.Show("some else is open");
                                    }
                                
                                }






                            }

                            else
                            {


                                j += 1;

                                MessageBox.Show((left -= 1).ToString() + " كلمة المرور  غير صحيحة عدد المحاولات المتبقية ");
                                textBox7.Text = "";
                                textBox8.Text = "";
                                textBox7.Focus();
                                connection.Close();

                            }
                        }
                    
                    else
                    {

                        this.Close();
                    }

                }
            
            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            textBox8.UseSystemPasswordChar = false;
            pictureBox3.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Hide();
            textBox8.UseSystemPasswordChar = true;
            pictureBox2.Show();

        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { textBox8.Focus(); }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            pictureBox3.Hide();
            textBox8.UseSystemPasswordChar = false;
            pictureBox2.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            pictureBox2.Hide();
            textBox8.UseSystemPasswordChar = true;
            pictureBox3.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
