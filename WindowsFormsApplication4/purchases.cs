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
    public partial class purchases : Form
    {
        public purchases()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            suppliers s = new suppliers();
           
            s.Location = new System.Drawing.Point(1, 88);
            s.Show();
            setting st = new setting();
             
           
             
             
             
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            products p = new products();
            p.Location = new System.Drawing.Point(1, 88);
            p.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void purchases_Load(object sender, EventArgs e)
        {
            panel6.Hide();
            panel6.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }
    }
}
