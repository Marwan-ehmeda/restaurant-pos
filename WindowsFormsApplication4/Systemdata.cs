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
    public partial class Systemdata : Form
    {
        SqlConnection connection;
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        SqlCommand cmd;
        SqlCommand command;
        DataTable data;
        CurrencyManager manger;
        SqlCommandBuilder builder;
        public Systemdata()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection.Open();
            var image_Meal = new ImageConverter().ConvertTo(pictureBox2.Image, typeof(Byte[]));
            


            string insertProd1 = "insert into Company_data values(@Company_Name,@phone1,@phone2,@Email,@facebook,@City,@Country,@Address,@vat_NO,@logo)";
            cmd = new SqlCommand(insertProd1, connection);
            cmd.Parameters.AddWithValue("@Company_Name", textBox9.Text);
            cmd.Parameters.AddWithValue("@phone1", textBox6.Text);
            cmd.Parameters.AddWithValue("@phone2", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@facebook", textBox4.Text);
            cmd.Parameters.AddWithValue("@City", textBox5.Text);
            cmd.Parameters.AddWithValue("@Country", textBox7.Text);
            cmd.Parameters.AddWithValue("@Address", textBox10.Text);
            cmd.Parameters.AddWithValue("@vat_NO", textBox1.Text);
            cmd.Parameters.AddWithValue("@logo", image_Meal);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("done");



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
            if (OP.ShowDialog() == DialogResult.OK)
            {

                pictureBox2.Load(OP.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connection.Open();
            string delete = "delete from Company_data";
            cmd = new SqlCommand(delete, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            connection.Open();

            //string check = "select*from Company_data";
            //cmd = new SqlCommand(check, connection);
            //reader = cmd.ExecuteReader();
            //reader.Read();
            //if (reader.HasRows) {}
            var image_Meal = new ImageConverter().ConvertTo(pictureBox2.Image, typeof(Byte[]));



            string insertProd1 = "insert into Company_data values(@Company_Name,@phone1,@phone2,@Email,@facebook,@City,@Country,@Address,@vat_NO,@logo)";
            cmd = new SqlCommand(insertProd1, connection);
            cmd.Parameters.AddWithValue("@Company_Name", textBox9.Text);
            cmd.Parameters.AddWithValue("@phone1", textBox6.Text);
            cmd.Parameters.AddWithValue("@phone2", textBox2.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@facebook", textBox4.Text);
            cmd.Parameters.AddWithValue("@City", textBox5.Text);
            cmd.Parameters.AddWithValue("@Country", textBox7.Text);
            cmd.Parameters.AddWithValue("@Address", textBox10.Text);
            cmd.Parameters.AddWithValue("@vat_NO", textBox1.Text);
            cmd.Parameters.AddWithValue("@logo", image_Meal);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("done");
        }

        private void Systemdata_Load(object sender, EventArgs e)
        {

            
            connection.Open();

            string show = "select * from Company_data";
            cmd = new SqlCommand(show, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            textBox9.Text = reader["Company_Name"].ToString();
            textBox6.Text = reader["phone1"].ToString() ;
            textBox2.Text = reader["phone2"].ToString();
            textBox3.Text = reader["Email"].ToString() ;
            textBox4.Text = reader["facebook"].ToString(); 
            textBox5.Text = reader["City"].ToString() ;
            textBox7.Text = reader["Country"].ToString() ;
            textBox10.Text = reader["Address"].ToString() ;
            textBox1.Text = reader["vat_NO"].ToString() ;
           

           
            
            connection.Close();




        }
    }
}
