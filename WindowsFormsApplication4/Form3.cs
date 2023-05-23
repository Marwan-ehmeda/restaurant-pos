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
     
    public partial class Form3 : Form
    {
        SqlConnection connection;
         
        SqlDataReader reader;
        SqlDataAdapter adapter;

        public Form3()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");


        }

        private void button3_Click(object sender, EventArgs e)
        {
         

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
                    
        }

       
    }

