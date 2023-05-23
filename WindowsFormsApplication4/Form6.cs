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
    public partial class Form6 : Form

    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader, rdr;
        SqlCommand cmd, command;
        DataTable data, data1;
        CurrencyManager manger;
        SqlCommandBuilder builder;
        public string name_current_cahser ;
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
        public Boolean status ;
        public string access = "";



        private Form activeForm = new Form();
        public Form6()
        {
            InitializeComponent();
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        public void FormLoad(Form childForm)
        {

            activeForm.Close(); 
            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(activeForm);
            activeForm.Show();


        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             
        }
        public void FormLoad2(Form2 childForm)
        {


            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(activeForm);
            activeForm.Show();


        }
        public void FormLoad_sales(sales childForm)
        {


            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(activeForm);
            activeForm.Show();


        }


        public void check() 
        {
            connection.Open();
             string n = "select * from users where casher_id=" + casher_id;
            cmd = new SqlCommand(n, connection);


            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader["access"].ToString() == "ادمن")
            {
                button18.Enabled = true;

            }
            else
            {

                button18.Enabled = false;
            }
            
            name_current_cahser = reader["casher_user_name"].ToString();
            MessageBox.Show(name_current_cahser);
            connection.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            check();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
 
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
             
            Form1 f = new Form1();
            f.casher_id = casher_id;
            if (status != true) 
            {
                f.button1.Enabled = false;
                f.button2.Enabled = false;
                f.button3.Enabled = false;
                f.button10.Enabled = false;
                f.button27.Enabled = true;
                f.pictureBox4.Enabled = false;
                f.pictureBox5.Enabled = false;
                f.pictureBox6.Enabled = false;
                f.pictureBox7.Enabled = false;
                f.pictureBox8.Enabled = true;
                f.name_current_cahser = name_current_cahser;
                f.ShowDialog(); 
                
            }
            else 
            {
                f.name_current_cahser = name_current_cahser;

                f.ShowDialog(); 
            
            }


            

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form2 f8 = new Form2();


            FormLoad(f8);

             
        }

        private void button15_Click(object sender, EventArgs e)
        {
            sales s = new sales();
           
            FormLoad(s);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            CatMangment cm = new CatMangment();
            cm.Show();
            //FormLoad(cm);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Systemdata s = new Systemdata();
            s.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {

            Profile p = new Profile();
            p.casher_id = casher_id;
            
            FormLoad(p);

        }

        private void Form6_Activated(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
         
    }
}
