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
    public partial class sales : Form
    {
        SqlConnection connection;
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlDataReader reader;
         
        SqlCommand cmd, cmd2, cmd3;
        DataSet data;
       
        CurrencyManager manger;
        SqlCommandBuilder builder;
         
        CrystalReport2 rpt;
        public string OrderNum;
        public sales()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }

        private void sales_Load(object sender, EventArgs e)
        {

            connection.Close();
            connection.Open();

            cmd = new SqlCommand("select * from View_DV", connection);
            reader = cmd.ExecuteReader();

            

            while ( reader.Read()) {

                dataGridView3.Rows.Add(reader["Order_No"], reader["name_prodduct"], reader["Sale_price"], reader["Qty"], reader["Total"], reader["Order_date"]);
            
            
            }

            reader.Close();
            connection.Close();
            connection.Open();
            cmd = new SqlCommand("select sum(Final_Total)as summ from sales", connection);
            reader = cmd.ExecuteReader();

            reader.Read();
            textBox3.Text = reader["summ"].ToString();
            connection.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            printInvoic();
        }
        public void printInvoic()
            
        {
         
            salesTable ff = new salesTable();
            data = new DataSet();
            connection.Close();
            connection.Open();
            ////////////////////
            cmd = new SqlCommand("select * from View_DV", connection);
             
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data, "View_DV");
            
            ////////////////////////////

             
            //////////////////////////////////////////

            ff.Show();
            ff.WindowState = FormWindowState.Maximized;
            rpt = new CrystalReport2();
            rpt.SetDataSource(data);
            ff.crystalReportViewer2.ReportSource = rpt;
            ff.crystalReportViewer2.Refresh();
            connection.Close();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string mostRepeat = "select Top 1 name_prodduct,sum(Qty)as qtyy   from View_DV group by name_prodduct order by (qtyy) DESC ";
            cmd = new SqlCommand(mostRepeat, connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            MessageBox.Show(reader["name_prodduct"].ToString());
            connection.Close();
            reader.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            if (connection.State.Equals(1)) { connection.Close(); }
            connection.Open();
            cmd = new SqlCommand("select * from View_DV where name_prodduct Like'%" + textBox1.Text + "%'", connection);
             
            reader = cmd.ExecuteReader();



            while (reader.Read())
            {

                dataGridView3.Rows.Add(reader["Order_No"].ToString(), reader["name_prodduct"].ToString(), reader["Sale_price"].ToString(), reader["Qty"].ToString(), reader["Total"].ToString(), reader["Order_date"].ToString());

            
            }
            connection.Close();
                
                 
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
