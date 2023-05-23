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
    public partial class Form4 : Form
    {
        public static string SetValueForText2 = "";
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        CurrencyManager manger;
        SqlCommandBuilder builder;

        int ID = 0;
        string PRD_name = "";
        int SALE_price = 0 ;
        Double myTotal=0.0;
        public string glop = "";
        public string table = "";
        public string num = "";



        public Form4()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
             
         
            this.Hide();
            

        }

        
         

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
               
                 
                




            }

      
        

        




       
        private void Form4_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


     
    }
}
