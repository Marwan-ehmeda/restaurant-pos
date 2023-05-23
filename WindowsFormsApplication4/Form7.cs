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
    public partial class Form7 : Form
    {

        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        CurrencyManager manger;
        SqlCommandBuilder builder;
        
         

        int billNumber = 1;

        private Form activeForm = new Form();

        Button btAll;
        Label lblName;
        Label lblPrice;
        Panel PanelPic;
        Panel MainPanel;
        String filter = "";
        public string tblName;
        public string date;
        public DateTime Date;
        
         
        public Form7()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }

        public void load_tabls()
        {
            flowLayoutPanel1.AutoScroll = true;

            if (connection.State.Equals(1)) { connection.Close(); }
            connection.Open();

            cmd = new SqlCommand("select * from table_bill", connection);

            reader = cmd.ExecuteReader();
           

            while (reader.Read())
            {

                btAll = new Button();
                if (int.Parse(reader["Bill"].ToString()) > 0)
                {
                    btAll.Text = reader["Table_Name"].ToString() + '\n' + "قيمة الفاتورة : "+reader["Bill"].ToString()+" د"; 
                    btAll.BackColor = Color.Red;

                }
                else
                {
                    btAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                    btAll.Text = reader["Table_Name"].ToString();

                }
                btAll.Tag = reader["Table_Name"].ToString();
                //btAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                btAll.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
                btAll.FlatAppearance.BorderSize = 0;
                btAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                btAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
                btAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btAll.Font = new System.Drawing.Font("Traditional Arabic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));               
                btAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                btAll.Location = new System.Drawing.Point(4, 58);
                btAll.Size = new System.Drawing.Size(145, 70);
                
                 
                 
                btAll.Click += new System.EventHandler(this.button_Click);


                flowLayoutPanel1.Controls.Add(btAll);


            }
            connection.Close();
            reader.Close();

        }
        public void  button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            tblName = btn.Tag.ToString();


             
            Get_Order_table();
            Form1 f1 = new Form1();
            date = f1.getOrder(tblName);
            f1.read();

            Date = f1.getDate(tblName);

           
            Close();

         
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            load_tabls();
        }

        public String Get_Order_table() { return tblName; }
        public String Get_Order_no() 


        {
            
                 
                String Order_Date = DateTime.Today.ToString("yyyMMdd");

                if (connection.State.Equals(1)) {connection.Close(); }
                 
                connection.Open();

                cmd = new SqlCommand("select * from Order_tbl order by Order_id  desc ", connection);

                reader= cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows) {
                    
                    long b = long.Parse(reader["Order_no"].ToString())+1 ;
                    date = b.ToString();
                    reader.Close();
                    connection.Close();
                    return date;
                    
                
                }
                else
                {
                    date= Order_Date+"001";
                    reader.Close();
                    connection.Close();
                    return date;
                  
                }
          
               


          
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
