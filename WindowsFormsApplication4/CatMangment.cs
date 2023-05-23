using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class CatMangment : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter, adapter2, adapter3;
        SqlDataReader reader, rdr;
        SqlCommand cmd, cmd2, cmd3;
        public CatMangment()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");

        }
        
        public void Load_cat() 
        {
            connection.Close();
            connection.Open();

            cmd = new SqlCommand("select * from cat_tbl ", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dataGridView3.Rows.Add(reader["id_cat"].ToString(), reader["name_cat"].ToString());
            }

            reader.Close();
            connection.Close();
            
        
        }
        private void CatMangment_Load(object sender, EventArgs e)
        {
            Load_cat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             connection.Open();
            string insert = "insert into cat_tbl values (@name_cat)";
             cmd = new SqlCommand(insert, connection);
             cmd.Parameters.AddWithValue("@name_cat", textBox1.Text);
             cmd.ExecuteNonQuery();
             connection.Close();
             MessageBox.Show("Done");
             Form1 ff = new Form1();
             this.Close();
             ff.flowLayoutPanel3.Refresh(); 
             

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connection.Open();
            //string delete = "delete from cat_tbl where name_cat = @name_cat";
            //cmd = new SqlCommand(delete, connection);
            //cmd.Parameters.AddWithValue("@name_cat", textBox1.Text);
            //cmd.ExecuteNonQuery();
            //connection.Close();
            //MessageBox.Show("Done");
            //Form1 ff = new Form1();
             
            //ff.Show();
            Form1 ff = new Form1();
            ff.one(textBox1.Text);
            this.Close();
            ff.Refresh();
            
            
       

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
    }
}
