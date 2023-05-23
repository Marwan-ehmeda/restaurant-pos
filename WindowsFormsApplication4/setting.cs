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
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }
        private Form activeForm = new Form();
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
        private void setting_Load(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
             
           repositry r = new repositry();
           FormLoad(r);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            purchases ps = new purchases();
            FormLoad(ps);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            products s = new products();
            FormLoad(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            suppliers sp = new suppliers();
            FormLoad(sp);
        }
    }
}
