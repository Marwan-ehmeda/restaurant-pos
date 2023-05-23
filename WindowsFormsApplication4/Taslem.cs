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
    public partial class Taslem : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        public int cahser_id = 0;
        public string name_current_cahser = "";
        public Double Final;
        public string Order_No;
        public string Order_Date;
        public Double Order_total;
        public Double Order_taxValue;
        public Double Order_taxTotal;
        public int bank ;
         
        public Taslem()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");

        }
        public void Tsleam_History() 
        {
            connection.Open();
            cmd = new SqlCommand("insert into Tsleam_history values (@id_cahser,@name_casher,@total_Tsleam,@data_Tsleam)", connection);
            cmd.Parameters.AddWithValue("@id_cahser", cahser_id);
            cmd.Parameters.AddWithValue("@name_casher", name_current_cahser);
            cmd.Parameters.AddWithValue("@total_Tsleam", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@data_Tsleam", Order_Date);
            cmd.ExecuteNonQuery();
            connection.Close();
        
        
        }
        public void Taslem_user() 
        {
            connection.Close();


            connection.Open();
            string update = "update users set casher_Balance=@casher_Balance,status=@status where casher_id=" + cahser_id.ToString();
            cmd = new SqlCommand(update, connection);
            cmd.Parameters.AddWithValue("@status", false);
            cmd.Parameters.AddWithValue("@casher_Balance", 0);
            cmd.ExecuteNonQuery();
            connection.Close();
            


            MessageBox.Show("done");
          
        
        }
        public void sales_Today() 
        {

            connection.Close();
            //and Move_date=@Move_date and Move_type like @Move_type
            connection.Open();
            string show = " select sum(Final_Total) summ  from Move_table  where Move_date=@Move_date and Move_type like @Move_type";
            cmd = new SqlCommand(show, connection);

            cmd.Parameters.AddWithValue("@Move_type", "نقدي");
            cmd.Parameters.AddWithValue("@casher_id", cahser_id);
            cmd.Parameters.AddWithValue("@Move_date", Order_Date);
            reader = cmd.ExecuteReader();
            reader.Read();
            string s = reader["summ"].ToString();
            textBox2.Text = s;
        
        }
        public void get_casher_balance() 
        {
            connection.Close();
            connection.Open();
            cmd = new SqlCommand("select * from users where casher_id=" + cahser_id.ToString(), connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            textBox2.Text = reader["casher_Balance"].ToString();
        
        }
        public void insert_safe_bank()
        {

            connection.Close();
            connection.Open();
            cmd = new SqlCommand("update safe_bank set safe_balance =  @cash", connection);
            cmd.Parameters.AddWithValue("@cash", decimal.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("done");


        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(textBox1.Text) < decimal.Parse(textBox2.Text)) { MessageBox.Show("الرصيد الموجود اقل من  رصيد مبعات اليوم"); }
            else
            {
                Taslem_user();
                insert_safe_bank();
                Tsleam_History();

            }
            
             


            this.Close();
        }
        

        private void Taslem_Load(object sender, EventArgs e)
        {
            get_casher_balance();
           // sales_Today();
            MessageBox.Show(Order_Date.ToString());
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
