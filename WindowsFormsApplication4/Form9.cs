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
    public partial class products : Form
    {
        public products()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sales_screen_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible =true;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox9.Text = "...";
            textBox3.Text = "";

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button10.Visible = true;
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "...";
            textBox9.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }
    }
}
