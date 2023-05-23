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
    public partial class Form5 : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        CurrencyManager manger;
        SqlCommandBuilder builder;
        public static string n = "";
        public string tag = "";
        public string billNumber = "";
        private Panel activeForm = new Panel();
        public Form5()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.Show();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.Hide();
            Form4 f4 = new Form4();
            
            
        }
        public void FormLoad(Panel childForm)
        {

            activeForm.Hide();

            activeForm = childForm;
             
     
            activeForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(activeForm);
            activeForm.Show();



        }
        public void show_DataGV()

        {
            dataGridView3.Show();
            dataGridView3.Rows.Clear();
            connection.Close();
            connection.Open();
            cmd = new SqlCommand("select * from users", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                dataGridView3.Rows.Add(reader["casher_id"], reader["full_name"], reader["casher_user_name"], reader["casher_password"], reader["casher_phnoe"], reader["casher_address"], reader["casher_gender"], reader["time_work"]);



            }
            connection.Close();}
        private void Form5_Load(object sender, EventArgs e)
        {
            panel5.Hide();
            panel4.Hide();
            dataGridView3.Hide();
            
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            panel4.Hide();
            show_DataGV();

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel5.Hide();
            dataGridView3.Hide();
             
            panel4.Show();


         
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            connection.Close();
            connection.Open();

             string check = " select  * from users where full_name= '" + full_txt.Text + "'"; 
            // كتابة الاستعلام المطلوب بشكل منفصل في متغير



            cmd = new SqlCommand(check, connection);

            reader = cmd.ExecuteReader();

             
            reader.Read();
            if (reader.HasRows)
            {
                MessageBox.Show(" ! هذا الاسم موجود بالفعل  ");
                
            }
            else
            {
                connection.Close();
                connection.Open();



                var image_Meal = new ImageConverter().ConvertTo(pictureBox2.Image, typeof(Byte[]));
                cmd.Parameters.AddWithValue("@image", image_Meal);



                string insertProd1 = "insert into users (full_name,casher_user_name,casher_password,casher_address,casher_gender,time_work,casher_phnoe,user_imge,access) values(@full_name,@casher_user_name,@casher_password,@casher_address,@casher_gender,@time_work,@casher_phnoe,@user_imge,@access)";
                cmd = new SqlCommand(insertProd1, connection);
                //cmd = new SqlCommand("update users set full_name=@full_name,casher_user_name=@casher_user_name,casher_password=@casher_password,casher_address=@casher_address,casher_gender=@casher_gender,time_work=@time_work,user_imge=@user_imge,access=@access where casher_id=@current_user", connection);

                cmd.Parameters.AddWithValue("@full_name", full_txt.Text);
                cmd.Parameters.AddWithValue("@casher_user_name", username_txt.Text);
                cmd.Parameters.AddWithValue("@casher_password", password_txt.Text);
                cmd.Parameters.AddWithValue("@casher_address", address_txt.Text);
                cmd.Parameters.AddWithValue("@casher_gender", gender_txt.Text);
                cmd.Parameters.AddWithValue("@time_work", worktime_txt.Text);
                cmd.Parameters.AddWithValue("@user_imge", image_Meal);
                cmd.Parameters.AddWithValue("@access", access_txt.Text);
                cmd.Parameters.AddWithValue("@casher_phnoe", phone_txt.Text);





                cmd.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("تم تسجيل المستخدم بنجاح");
            
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Close(); 
            connection.Open();


            string check = " select  * from users where full_name Like '" + textBox2.Text + "'"; 
         //   "select * from Order_tbl where Table_Name Like'" + s + "'"
            // كتابة الاستعلام المطلوب بشكل منفصل في متغير



            cmd = new SqlCommand(check, connection);

            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                reader.Close();
                connection.Close();
                connection.Open();

                string delete = "delete from users where full_name like'"+textBox2.Text+"'";
                cmd = new SqlCommand(delete, connection);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("تم حذف المستخدم بنجاح");


            }

            else 
            { MessageBox.Show("هذا المستخدم غير موجود"); connection.Close();  }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            
            panel5.Show();
            dataGridView3.Hide();
             
            
        }

        private void Form5_Activated(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
      
    }
}
