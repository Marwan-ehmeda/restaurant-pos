using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class suppliers : Form
    {
        public suppliers()
        {
            InitializeComponent();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
           
        }

        private void suppliers_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = "";
            textBox9.Text = "...";
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            textBox9.Text = "";
            textBox7.Text = "...";
        }
    }
}
