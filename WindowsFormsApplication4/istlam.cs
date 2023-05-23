using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class istlam : Form

    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        public int cahser_id = 0;
        public int bank = 0;
        public string Order_Date;
        public string name_current_cahser = "";
        public istlam()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }
        public void Istlam_History()
        {
            connection.Open();
            cmd = new SqlCommand("insert into Istlam_History values (@id_cahser,@name_casher,@total_Tsleam,@data_Tsleam)", connection);
            cmd.Parameters.AddWithValue("@id_cahser", cahser_id);
            cmd.Parameters.AddWithValue("@name_casher", name_current_cahser);
            cmd.Parameters.AddWithValue("@total_Tsleam", decimal.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@data_Tsleam", Order_Date);
            cmd.ExecuteNonQuery();
            connection.Close();


        }
       public void update_user_istlam()
        {
            connection.Open();
            string update = "update users set casher_Balance=casher_Balance+@casher_Balance,status=@status where casher_id=" + cahser_id.ToString();
            cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("@status", true);
            cmd.Parameters.AddWithValue("@casher_Balance", decimal.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            update_user_istlam();
            Istlam_History();
            
            
            MessageBox.Show("تم الاستلام");
             
             
            this.Close();
        }
        public void check_cashier_status() 
        {
            connection.Open();
            string check_casheir_status = "select * from users where status = 0";
            cmd = new SqlCommand(check_casheir_status, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                MessageBox.Show("someone else is open");

            }
            else 
            {
                MessageBox.Show("No one is open");
            }
            connection.Close();

        
        }
        public void sales_Today()
        {

            connection.Close();
            //and Move_date=@Move_date and Move_type like @Move_type
            connection.Open();
            string show = " select sum(Final_Total) summ  from Move_table  where   Move_date=@Move_date and Move_type like @Move_type";
            cmd = new SqlCommand(show, connection);

            cmd.Parameters.AddWithValue("@Move_type", "نقدي");
             
            cmd.Parameters.AddWithValue("@Move_date", Order_Date);
            reader = cmd.ExecuteReader();
            reader.Read();
            string s = reader["summ"].ToString();
            textBox1.Text = s;

        }
        public void safe_Balance() 
        {
            connection.Close();
            connection.Open();
            cmd = new SqlCommand("select*from safe_bank", connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            string s = reader["safe_balance"].ToString();
            textBox1.Text = s;
            connection.Close();
        
        }
        private void istlam_Load(object sender, EventArgs e)
        {
            safe_Balance();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
