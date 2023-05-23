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

namespace WindowsFormsApplication4
{
    public partial class Form9PAid : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter, adapter2, adapter3;
        SqlDataReader reader, rdr;
        SqlCommand cmd, cmd2, cmd3;
        DataSet data ;
        PrintSales rpt;
        
        public Double Final;
        public string Order_No;
        public DateTime Order_Date;
        public Double Order_total;
        public Double Order_taxValue;
        public Double Order_taxTotal;
        public int cahser_id =0;
         

        public Form9PAid()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text == "") { textBox9.Text = Order_No.ToString(); }
            //else
            //{
            //    Double f = Final - Double.Parse(textBox2.Text.ToString());
            //    textBox9.Text = f.ToString();

            //}
            
           

        }
        public void update_balance_paid() 
        {
            
            connection.Open();
            string update = "update users set casher_Balance=casher_Balance+@casher_Balance where casher_id=" + cahser_id.ToString();
            cmd = new SqlCommand(update, connection);
           
            cmd.Parameters.AddWithValue("@casher_Balance", decimal.Parse( textBox4.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
        
        }
        public void insert_casher_MOve()
        {
            
            connection.Open();
            string update = "insert into Move_table (casher_id,Order_No,Final_Total,Move_type,Move_date)values(@casher_id,@Order_No,@Final_Total,@Move_type,@Move_date)";
            cmd = new SqlCommand(update, connection);
             
            cmd.Parameters.AddWithValue("@casher_id",cahser_id);
            cmd.Parameters.AddWithValue("@Order_No", Order_No);
            cmd.Parameters.AddWithValue("@Final_Total", decimal.Parse( textBox4.Text));

            cmd.Parameters.AddWithValue("@Move_type", comboBox1.SelectedItem.ToString());

            cmd.Parameters.AddWithValue("@Move_date",Order_Date);
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        private void Form9PAid_Load(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox5.ReadOnly = true;
            

            Form1 f1 = new Form1();
            textBox9.Text = Final.ToString();
            textBox9.ReadOnly = true;
           
            
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") { textBox5.Text = ""; }
            else
            {
                Double left = Double.Parse(textBox9.Text.ToString()) - Double.Parse(textBox4.Text.ToString());
                textBox5.Text = left.ToString();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        { 
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.Enabled = true;
                textBox2.Text="0";
                textBox2.Focus();
            }
        }

        public void printInvoic1()
        {
            PrintSale ff = new PrintSale();
            data = new DataSet();
            connection.Close();
            connection.Open();
            ////////////////////
            cmd = new SqlCommand("select * from View_DV where Order_No=" + Order_No, connection);

            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data, "View_DV");
            ////////////////////////////
            cmd2 = new SqlCommand("select*from sales where Order_No=" + Order_No, connection);
            //cmd2.Parameters.AddWithValue("@Order_No", Order_No);
            adapter2 = new SqlDataAdapter(cmd2);
            adapter2.Fill(data, "sales");
            //////////////////////////////////////////

            cmd3 = new SqlCommand("select*from Company_data", connection);
            adapter3 = new SqlDataAdapter(cmd3);
            adapter3.Fill(data, "Company_data");
            //////////////////////////////////////////


            ff.Show();
            ff.WindowState = FormWindowState.Maximized;
            rpt = new PrintSales();
            rpt.SetDataSource(data);
            ff.crystalReportViewer1.ReportSource = rpt;
            ff.crystalReportViewer1.Refresh();
            connection.Close();



        }

        public void printInvoic()
        {
            data=new DataSet();
            connection.Close();
            connection.Open();
            ////////////////////
            cmd = new SqlCommand("select*from sales where Order_No=@Order_NO", connection);
            cmd.Parameters.AddWithValue("@Order_No",Order_No);
            adapter=new SqlDataAdapter(cmd);
            adapter.Fill(data,"sales");
            ////////////////////////////

            cmd2 = new SqlCommand("select* from Order_tbl where Order_No=@Order_NO", connection);
            cmd2.Parameters.AddWithValue("@Order_No",Order_No);
            adapter2=new SqlDataAdapter(cmd2);
            adapter.Fill(data, "Order_tbl");
            ////////////////////////////
            cmd3 = new SqlCommand("select*from Company_data", connection);
            adapter3 = new SqlDataAdapter(cmd3);
            adapter3.Fill(data, "Company_data");
            //////////////////////////////////////////
            
           // ff.Show();
           // ff.WindowState = FormWindowState.Maximized;
           // //rpt = new CrystalReport2();
           // //rpt.SetDataSource(data);
            
           //// ff.crystalReportViewer1.ReportSource = rpt;
           // ff.crystalReportViewer1.Refresh();
           // connection.Close();



        }

        public void insertSales() 
        {
            connection.Open();
            cmd = new SqlCommand("insert into sales(Order_No,Order_Date,Total,tax_value,tax_Total,discount,Final_Total,Paid_Type,username)values(@Order_No,@Order_Date,@Total,@tax_value,@tax_Total,@discount,@Final_Total,@Paid_Type,@username)", connection);
            cmd.Parameters.AddWithValue("@Order_No",Order_No);
            cmd.Parameters.AddWithValue("@Order_Date",Order_Date);
            cmd.Parameters.AddWithValue("@Total",Order_total);
            cmd.Parameters.AddWithValue("@tax_value",Order_taxValue);
            cmd.Parameters.AddWithValue("@tax_Total",Order_taxTotal);
            cmd.Parameters.AddWithValue("@discount",textBox2.Text);
            cmd.Parameters.AddWithValue("@Final_Total",Final);
            cmd.Parameters.AddWithValue("@Paid_Type",comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@username","Admin");
            cmd.ExecuteNonQuery();
            connection.Close();
            

        
        
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void insert_safe_bank() 
        {

            connection.Close();
            connection.Open();
            cmd = new SqlCommand("update safe_bank set safe_balance =  @cash", connection);
            cmd.Parameters.Add("@cash", decimal.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("done");

        
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (Double.Parse(textBox4.Text) < Double.Parse(textBox9.Text)) 
            {

                MessageBox.Show("القيمة المدفوعة اقل من قيمة الفاتورة");
            }
            if (Double.Parse(textBox4.Text) > Double.Parse(textBox9.Text))
            {

                MessageBox.Show("القيمة المدفوعة اكبر من قيمة الفاتورة");
            }
            if (comboBox1.SelectedItem.ToString() == "نقدي") 
            {
                MessageBox.Show(comboBox1.SelectedItem.ToString());
                
                update_balance_paid();
            
            }
            if (Double.Parse(textBox4.Text) == Double.Parse(textBox9.Text))
            {
                insert_casher_MOve();

                insertSales();
                insert_safe_bank();
                connection.Open();
                cmd = new SqlCommand("update Order_tbl set Status='close' where Order_No=@Order_No", connection);
                cmd.Parameters.AddWithValue("@Order_No", Order_No);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("تم دفع الفاتورة بنجاح");
               // MessageBoxOptions.RightAlign.ToSt("d");
                 
            }
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
             
            Form1 ff = new Form1();
            ff.dataGridView3.Rows.Clear();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printInvoic1();
        }
    }
}
