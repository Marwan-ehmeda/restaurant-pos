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
    public partial class Profile : Form

    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        CurrencyManager manger;
        SqlCommandBuilder builder;



        public int casher_id = 0;
        public string casher_user_name = "";
        public string casher_password = "";
        public string full_name = "";
        public string casher_phnoe = "";
        public string casher_address = "";
        public string casher_gender = "";
        public int time_work = 0;
        public int user_imge = 0;
        public int casher_Balance = 0;
        public Boolean status = false;
        public string access = "";


        public Profile()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");

        }

        private void Profile_Load(object sender, EventArgs e)
        {
            Load_user();
            panel2.Hide();
            //Form8 f = new Form8();
            //MessageBox.Show(f.textBox7.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }
        public void Load_user_Update()
        {


            connection.Open();
            string load_User_data = "select * from users where casher_id=" + casher_id;
            cmd = new SqlCommand(load_User_data, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {

                label3.Text = reader["full_name"].ToString();
                label10.Text = reader["casher_user_name"].ToString();
                label11.Text = reader["casher_password"].ToString();
                address.Text = reader["casher_address"].ToString();
                accessablity.Text = reader["access"].ToString();
                Phone.Text = reader["casher_phnoe"].ToString();
                Worktime.Text = reader["time_work"].ToString() + " ساعات  ";
                MemoryStream str = new MemoryStream(reader.GetSqlBytes(8).Buffer);
                pictureBox2.Image = Image.FromStream(str);



            }

            else
            //{ MessageBox.Show("no records"); }


            connection.Close();


        }
        
        public void Load_user() {


       connection.Open();
       string load_User_data = "select * from users where casher_id="+casher_id;
       cmd = new SqlCommand(load_User_data, connection);
       reader = cmd.ExecuteReader();
       
      // MemoryStream str = new MemoryStream(reader.GetSqlBytes(5).Buffer);
       if (reader.Read())
       {

           label3.Text = reader["full_name"].ToString();
           label10.Text = reader["casher_user_name"].ToString();
           label11.Text = reader["casher_password"].ToString();
           address.Text = reader["casher_address"].ToString();
           accessablity.Text = reader["access"].ToString();
           Phone.Text = reader["casher_phnoe"].ToString();
           Worktime.Text = reader["time_work"].ToString() + " ساعات  ";
           MemoryStream str = new MemoryStream(reader.GetSqlBytes(8).Buffer);
           pictureBox1.Image = Image.FromStream(str);
                
               // pictureBox2.Image = Image.FromStream(str);



       }

       else 
             {   }


       connection.Close();


        }



        
            




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
            
        {
            connection.Close();
            connection.Open();
            try
            {
                var image_Meal = new ImageConverter().ConvertTo(pictureBox2.Image, typeof(Byte[]));
                cmd.Parameters.AddWithValue("@image", image_Meal);



                string insertProd1 = "insert into users (full_name,casher_user_name,casher_password,casher_address,casher_gender,time_work,user_imge,access) values(@full_name,@casher_user_name,@casher_password,@casher_address,@casher_gender,@time_work,@user_imge,@access)";
                // cmd = new SqlCommand(insertProd1, connection);
                cmd = new SqlCommand("update users set full_name=@full_name,casher_user_name=@casher_user_name,casher_password=@casher_password,casher_address=@casher_address,casher_gender=@casher_gender,time_work=@time_work,user_imge=@user_imge,access=@access where casher_id=@current_user", connection);

                cmd.Parameters.AddWithValue("@full_name", full_txt.Text);
                cmd.Parameters.AddWithValue("@casher_user_name", username_txt.Text);
                cmd.Parameters.AddWithValue("@casher_password", password_txt.Text);
                cmd.Parameters.AddWithValue("@casher_address", address_txt.Text);
                cmd.Parameters.AddWithValue("@casher_gender", gender_txt.Text);
                cmd.Parameters.AddWithValue("@time_work", worktime_txt.Text);
                cmd.Parameters.AddWithValue("@user_imge", image_Meal);
                cmd.Parameters.AddWithValue("@access", access_txt.Text);
                cmd.Parameters.AddWithValue("@current_user", casher_id);





                cmd.ExecuteNonQuery();

                connection.Close();
                casher_user_name = username_txt.Text;
                casher_password = password_txt.Text;
                Load_user();
                panel2.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            

        }
        public void show_data_user() 
        {
            connection.Open();
            string load_User_data = "select * from users where casher_id=" + casher_id;
            cmd = new SqlCommand(load_User_data, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {

                full_txt.Text = reader["full_name"].ToString();
                username_txt.Text = reader["casher_user_name"].ToString();
                password_txt.Text = reader["casher_password"].ToString();
                address_txt.Text = reader["casher_address"].ToString();
                access_txt.Text = reader["access"].ToString();
                phone_txt.Text = reader["casher_phnoe"].ToString();
                worktime_txt.Text = reader["time_work"].ToString();
                gender_txt.Text = reader["casher_gender"].ToString();
                ///MemoryStream str = new MemoryStream(reader.GetSqlBytes(5).Buffer);
                ///pictureBox2.Image = Image.FromStream(str);
                ///
                MemoryStream str = new MemoryStream(reader.GetSqlBytes(8).Buffer);
                pictureBox2.Image = Image.FromStream(str);



            }

            else
            { //MessageBox.Show("no records");
            connection.Close();
            
            
            
            }
        }
        private void label12_Click_1(object sender, EventArgs e)

        {
            show_data_user();
            panel2.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
            if (OP.ShowDialog() == DialogResult.OK)
            {

                pictureBox2.Load(OP.FileName);
            }
        }

        private void Profile_Activated(object sender, EventArgs e)
        {
            Load_user();
            panel1.Refresh();

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
