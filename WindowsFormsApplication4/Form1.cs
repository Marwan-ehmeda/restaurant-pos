using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
     
    public partial class Form1 : Form
    {

        SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataReader reader,rdr;
        SqlCommand cmd,command; 
        DataTable data,data1;
        public string admin="";
        public static string n ="";
        public string tag = "";
        public string billNumber="";
        public string admin_user_name="";
        public string admin_password = "";
        public string name_current_cahser = "";
        public int bank = 0;

        public Double tex_value = 0;
         
        public DateTime datebox ;
        
        private Form activeForm = new Form();
        
        Button btAll;
        Label lblName;
        Label lblPrice;
        Panel PanelPic;
        Panel MainPanel;
        String filter = "";
        string num = "";
        public string tbl_name;
        public int casher_id=0;

        int ID = 0;
        string PRD_name = "";
        int SALE_price = 0;
        Double myTotal = 0.0;
        public string glop = "";
        public string table = "";


        /// <summary>
        /// متغيرات شاشة الدفع
        /// </summary>

         public Double order_total = 0.0;
         public string final_total ="";
          
         public Double tax_total =0.0;
         public string order_no="";
         




        public Form1()
        {

            InitializeComponent();
            //connection = new SqlConnection("server=PP-PC;database=ؤم;Integrated Security=true");
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");

             
             tbl_name = textBox2.Text;
             datebox = dateTimePicker1.Value;
             order_total = Double.Parse(textBox7.Text.ToString());
             final_total = (textBox3.Text.ToString());

             tax_total = order_total * 5 / 100;
             order_no = textBox1.Text.ToString();

           
             

             
           

            
        }
        Double total1 = 0.0;
      
             
    
        
        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
           

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

             
            connection.Open();
            
            cmd = new SqlCommand("select * from cat_tbl where name_cat Like'%"+textBox4.Text+"%'", connection);
            reader = cmd.ExecuteReader();
            flowLayoutPanel3.Controls.Clear();
             
            while (reader.Read())
            {

                btAll = new Button();


                btAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                btAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btAll.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btAll.ForeColor = System.Drawing.Color.White;
                btAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                btAll.Location = new System.Drawing.Point(5, 58);
                btAll.Name = "button12";
                btAll.Size = new System.Drawing.Size(140, 35);
                btAll.TabIndex = 1;
                btAll.Text = reader["name_cat"].ToString();
                btAll.Tag = reader["id_cat"].ToString();
                btAll.UseVisualStyleBackColor = false;
                btAll.Click += new System.EventHandler(this.BySearch_Click);

                flowLayoutPanel3.Controls.Add(btAll);




            }
            connection.Close();
            reader.Close();

        }

        public void BySearch_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string tag = btn.Tag.ToString();
            load_products(tag);

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
             
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

       

             

            

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

 

        }

        private void flowLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click()
        {
             
        }
         

        public void FormLoad(Form childForm)
        {
           

            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            flowLayoutPanel5.Controls.Add(activeForm);

          
            
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }
        

        private void pictureBox38_Click(object sender, EventArgs e)
        {

        }
        public void load_Cats()
        {
            flowLayoutPanel5.AutoScroll = true;

            if (connection.State.Equals(1)) { connection.Close(); }
            connection.Open();

            cmd = new SqlCommand("select * from cat_tbl", connection);
          
            reader = cmd.ExecuteReader();
            

            while (reader.Read())
            {

                btAll = new Button();


                btAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
                btAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btAll.Font = new System.Drawing.Font("Traditional Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btAll.ForeColor = System.Drawing.Color.White;
                btAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                btAll.Location = new System.Drawing.Point(4, 58);          
                btAll.Size = new System.Drawing.Size(145, 35);
                btAll.Text = reader["name_cat"].ToString();
                btAll.Tag = reader["id_cat"].ToString();
             
                btAll.Click += new System.EventHandler(this.button_Click);
              

                flowLayoutPanel3.Controls.Add(btAll);
                

            }
            connection.Close();
            reader.Close();
        
        }
        public void button_Click(object sender, EventArgs e) 
        {
            Button btn = sender as Button;
            string tag = btn.Tag.ToString();
            load_products(tag);

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form9PAid f1 = new Form9PAid();
            f1.cahser_id = casher_id;


            if (int.Parse(textBox7.Text) == 0)
            {
                MessageBox.Show("الرجاء تعبئة الفاتورة اولا");
            
            }
            else
            {
                Form9PAid f9 = new Form9PAid();
                f9.Final = Double.Parse(textBox3.Text);
                f9.Order_No =  textBox1.Text;
                f9.Order_Date = dateTimePicker1.Value;
                f9.Order_total = Double.Parse(textBox7.Text);
                f9.Order_taxValue = Double.Parse(textBox9.Text);
                f9.Order_taxTotal = f9.Order_total * f9.Order_taxValue / 100;
                f9.cahser_id = casher_id;
                f9.ShowDialog();
                 
                 
            }
                
          

        }

             
             
        

        public void load_products(string tag) 
        
        {
           
            flowLayoutPanel5.AutoScroll = true;
            flowLayoutPanel5.Controls.Clear();
            if (connection.State.Equals(1)) { connection.Close(); }
            connection.Close();
            connection.Open();
             
            cmd = new SqlCommand("select * from products where id_class =" + tag, connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                MainPanel = new Panel();

                MainPanel.Width = 145;
                MainPanel.Height = 150;
                MainPanel.BorderStyle = BorderStyle.FixedSingle;

                ////////////////////////////////////////////////////////////////////////////////////////

                lblName = new Label();

                lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                lblName.Dock = System.Windows.Forms.DockStyle.Top;

                lblName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                lblName.Size = new System.Drawing.Size(199, 30);

                lblName.Text = reader["name_prodduct"].ToString();
                lblName.Tag = reader["id_prodduct"].ToString();
                lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                lblName.BorderStyle = BorderStyle.FixedSingle;
                lblName.Click += new System.EventHandler(this.select_Click);
                ////////////////////////////////////////////////////////////////////////////////////////

                lblPrice = new Label();

                lblPrice.BackColor = System.Drawing.SystemColors.ControlLight;
                lblPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
                lblPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                lblPrice.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                ;
                lblPrice.Size = new System.Drawing.Size(199, 30);

                lblPrice.Text = "السعر: " + reader["price_prodduct"] + "د".ToString();
                lblPrice.Tag = reader["id_prodduct"].ToString();
                lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblPrice.BorderStyle = BorderStyle.FixedSingle;
                lblPrice.Click += new System.EventHandler(this.select_Click);

                ///////////////////////////////////////////////////////////////////////

                PanelPic = new Panel();

                //Byte dataImg = new byte();

                //DirectedCast(reader["image"], Byte());

                MemoryStream str = new MemoryStream(reader.GetSqlBytes(5).Buffer);


                //PanelPic.Controls.Add(this.pictureBox1);
                PanelPic.Dock = System.Windows.Forms.DockStyle.Fill;

                PanelPic.Name = "panel1";
                PanelPic.Tag = reader["id_prodduct"].ToString(); 
                PanelPic.Size = new System.Drawing.Size(199, 149);
                PanelPic.BackgroundImage = Image.FromStream(str);
                PanelPic.BackgroundImageLayout = ImageLayout.Stretch;
                PanelPic.Click += new System.EventHandler(this.select_Click);

                ///////////////////////////////////////////////////////////////////////////////
                MainPanel.Tag = reader["id_prodduct"].ToString();
                MainPanel.Controls.Add(lblName);
                MainPanel.Controls.Add(PanelPic);
                MainPanel.Controls.Add(lblPrice);
                MainPanel.Click += new System.EventHandler(this.select_Click);

                flowLayoutPanel5.Controls.Add(MainPanel);






            }

            reader.Close();
            connection.Close();
        
        }

     
        public void load_productsForm1()
        {

            flowLayoutPanel5.AutoScroll = true;

            if (connection.State.Equals(1)) { connection.Close(); }
            connection.Open();

            cmd = new SqlCommand("select * from products", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                MainPanel = new Panel();

                MainPanel.Width = 145;
                MainPanel.Height = 150;
                MainPanel.BorderStyle = BorderStyle.FixedSingle;

                ////////////////////////////////////////////////////////////////////////////////////////

                lblName = new Label();

                lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                lblName.Dock = System.Windows.Forms.DockStyle.Top;

                lblName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                lblName.Size = new System.Drawing.Size(199, 30);

                lblName.Text = reader["name_prodduct"].ToString();
                lblName.Tag = reader["id_prodduct"].ToString();
                lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                lblName.BorderStyle = BorderStyle.FixedSingle;
                ////////////////////////////////////////////////////////////////////////////////////////

                lblPrice = new Label();

                lblPrice.BackColor = System.Drawing.SystemColors.ControlLight;
                lblPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
                lblPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                lblPrice.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                ;
                lblPrice.Size = new System.Drawing.Size(199, 30);

                lblPrice.Text = "السعر :" + reader["price_prodduct"].ToString();
                lblPrice.Tag = reader["id_prodduct"].ToString();
                lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblPrice.BorderStyle = BorderStyle.FixedSingle;
                ///////////////////////////////////////////////////////////////////////

                PanelPic = new Panel();

                //Byte dataImg = new byte();

                //DirectedCast(reader["image"], Byte());

                MemoryStream str = new MemoryStream(reader.GetSqlBytes(5).Buffer);


                //PanelPic.Controls.Add(this.pictureBox1);
                PanelPic.Dock = System.Windows.Forms.DockStyle.Fill;

                PanelPic.Name = "panel1";
                PanelPic.Size = new System.Drawing.Size(199, 149);
                PanelPic.BackgroundImage = Image.FromStream(str);
                PanelPic.BackgroundImageLayout = ImageLayout.Stretch;

                ///////////////////////////////////////////////////////////////////////////////

                MainPanel.Controls.Add(lblName);
                MainPanel.Controls.Add(PanelPic);
                MainPanel.Controls.Add(lblPrice);

                flowLayoutPanel5.Controls.Add(MainPanel);






            }

            reader.Close();
            connection.Close();

        }
        public void actv()
        {

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button10.Enabled = true;
            button27.Enabled = false;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = false;
        
        
        
        
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(name_current_cahser);
            dateTimePicker1.Enabled = false;
            Form8 f8 = new Form8();

          
           
         
            
            FormLoad(f8);
             
            
             
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            
            Form4 f4 = new Form4();
            f4.Show();
            

             

             
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {  
             
        }
        public void read() { textBox9.ReadOnly = false; }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form7 f7 = new Form7();
                f7.ShowDialog();
                textBox2.Text = f7.tblName;
                textBox1.Text = f7.date;
                load_Bill();
                Order_Total();

                dateTimePicker1.Value = f7.Date;

            }
            catch (Exception ec) { }
          
             
           
            
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string amountt = Form4.SetValueForText2;

            if (amountt != "")
            {

                connection.Open();


                //String fetch = "select*from products where id =" + id;


                String search = "select id_prodduct,name_cdrink from products inner join colddrinks on  id_prodduct=  '" + 1010 + "'";

                command = new SqlCommand(search, connection);



                reader = command.ExecuteReader();
                reader.Read();

                int amount = int.Parse(amountt);

                int qty = int.Parse(reader["id_prodduct"].ToString()) * amount;

               // dataGridView1.Rows.Add(textBox1.Text, qty, reader["name_cdrink"].ToString());




                reader.Close();
                connection.Close();



            }
            else
            {


              


            }
        }

        

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            sales sl = new sales();
            sl.OrderNum = textBox1.Text;
            sl.ShowDialog();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            
            flowLayoutPanel5.AutoScroll = true;

            //if (connection.State.Equals(1)) { connection.Close(); }
            connection.Close();
            connection.Open();
            
            cmd = new SqlCommand("select * from products where name_prodduct Like'%" + textBox5.Text + "%'", connection);
             
            reader = cmd.ExecuteReader();
            flowLayoutPanel5.Controls.Clear();
            

            while (reader.Read())
            {
                
                 
                 
                MainPanel = new Panel();
                MainPanel.Width = 145;
                MainPanel.Height = 150;
                MainPanel.BorderStyle = BorderStyle.FixedSingle;

            
                

                ////////////////////////////////////////////////////////////////////////////////////////

                lblName = new Label();

                lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                lblName.Dock = System.Windows.Forms.DockStyle.Top;

                lblName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                lblName.Size = new System.Drawing.Size(199, 30);

                lblName.Text = reader["name_prodduct"].ToString();
                lblName.Tag = reader["id_prodduct"].ToString();
                lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                lblName.BorderStyle = BorderStyle.FixedSingle;
                //lblName.Click += new System.EventHandler(this.select_Click);
                ////////////////////////////////////////////////////////////////////////////////////////

                lblPrice = new Label();

                lblPrice.BackColor = System.Drawing.SystemColors.ControlLight;
                lblPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
                lblPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                lblPrice.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                ;
                lblPrice.Size = new System.Drawing.Size(199, 30);

                lblPrice.Text = "السعر: " + reader["price_prodduct"] + "د".ToString();
                lblPrice.Tag = reader["id_prodduct"].ToString();
                lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblPrice.BorderStyle = BorderStyle.FixedSingle;
                //lblPrice.Click += new System.EventHandler(this.select_Click);

                ///////////////////////////////////////////////////////////////////////

                PanelPic = new Panel();

                //Byte dataImg = new byte();

                //DirectedCast(reader["image"], Byte());

                MemoryStream str = new MemoryStream(reader.GetSqlBytes(5).Buffer);


                //PanelPic.Controls.Add(this.pictureBox1);
                PanelPic.Dock = System.Windows.Forms.DockStyle.Fill;

                PanelPic.Name = "panel1";
                PanelPic.Tag = reader["id_prodduct"].ToString();
                PanelPic.Size = new System.Drawing.Size(199, 149);
                PanelPic.BackgroundImage = Image.FromStream(str);
                PanelPic.BackgroundImageLayout = ImageLayout.Stretch;
                //PanelPic.Click += new System.EventHandler(this.select_Click);

                ///////////////////////////////////////////////////////////////////////////////
                MainPanel.Tag = reader["id_prodduct"].ToString();
                MainPanel.Controls.Add(lblName);
                MainPanel.Controls.Add(PanelPic);
                MainPanel.Controls.Add(lblPrice);
                MainPanel.Click += new System.EventHandler(this.select_Click);

                flowLayoutPanel5.Controls.Add(MainPanel);
                if (textBox5.Text == "") { flowLayoutPanel5.Controls.Clear(); }
               

                 






            }

            reader.Close();
            connection.Close();


        }
        public string getOrder(string s)
        {
            Form7 f7=new Form7();
            Boolean found;
            string tno;
            connection.Close();
            connection.Open();
            cmd = new SqlCommand("select * from Order_tbl where Table_Name Like'" + s+"' and Status='open'", connection);
            reader = cmd.ExecuteReader();
            reader.Read();
             
            if (reader.HasRows)
            {
                found = true;
                tno = reader["Order_No"].ToString();
    
            }
            else 
            {
                found = false;
                tno = f7.Get_Order_no();
 
                
            }
          
            if (found == true) 
            {
         
                return tno;
           
              
             
            }
     
           // f1.dateTimePicker1.Value = DateTime.Parse(reader["Order_No"].ToString());
      
            return tno;
            
            
            
        }
        public DateTime getDate(string s)
        {
             
            Form7 f7 = new Form7();
            Boolean found;
            DateTime Date;
            connection.Close();
            connection.Open();
            cmd = new SqlCommand("select * from Order_tbl where Table_Name Like'" + s + "'", connection);
            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                found = true;
                Date = dateTimePicker1.Value;
                return Date;

            }


            else { Date = dateTimePicker1.Value; }
            return Date  ;
         
            Form1 f1 = new Form1();
            f1.dateTimePicker1.Value =Date;
            // f1.dateTimePicker1.Value = DateTime.Parse(reader["Order_No"].ToString());
            
          



        }
        public void load_Bill() 
        {
            connection.Close();
            connection.Open();
            dataGridView3.Rows.Clear();
            cmd = new SqlCommand("select * from View_DV where Order_No Like'" + textBox1.Text + "'And Status ='open' ", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dataGridView3.Rows.Add(reader["Order_id"].ToString(), reader["name_prodduct"].ToString(), reader["Sale_price"].ToString(), reader["Qty"].ToString(), reader["Total"].ToString());
                textBox9.Text = reader["tax_value"].ToString();
            }
            if (dataGridView3.Rows.Count <= 0)
            {
                textBox9.ReadOnly = false;
            }
            else
            { textBox9.ReadOnly = true; }
           
            reader.Close();
            connection.Close();
        
        
        }
        public void load_order()

        { 
            connection.Close();
            connection.Open();

            cmd = new SqlCommand("select * from View_DV where Order_No Like'" + textBox1.Text + "'And id_prodduct = "+ID, connection);
            reader = cmd.ExecuteReader();
          
             while (reader.Read())
                {
                   dataGridView3.Rows.Add(reader["Order_id"].ToString(),reader["name_prodduct"].ToString(), reader["Sale_price"].ToString(), reader["Qty"].ToString(), reader["Total"].ToString());                   
                }
              
            reader.Close();
            connection.Close();
          
    }


        
        public void select_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    Panel pbtn = sender as Panel;
                     
                    string tag = pbtn.Tag.ToString();

                    Form4 f4 = new Form4();

                    table = textBox2.Text;

                    textBox6.Focus();


                    glop = tag;
                }
                catch (Exception ex){ }
            }
            else { MessageBox.Show(" فتح فاتورة جديده أولاً"); }
            


        }
        
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                int qty = int.Parse(dataGridView3.CurrentRow.Cells[3].Value.ToString());
                if (qty >= 1)
                {
                    connection.Close();
                    connection.Open();
                    reader.Close();
                    cmd = new SqlCommand("Update Order_tbl set Qty=Qty+@Qty where Order_id=@Order_id ", connection);
                    cmd.Parameters.Add("@Qty", 1);
                    cmd.Parameters.Add("@Order_id", dataGridView3.CurrentRow.Cells[0].Value);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    reader.Close();
                    /////////////////////
                    connection.Open();
                    cmd = new SqlCommand("Update Order_tbl set Total=Qty* Sale_price where  Order_id=@Order_id", connection);


                    cmd.Parameters.Add("@Order_id", dataGridView3.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();

                    reader.Close();
                    dataGridView3.Rows.RemoveAt(e.RowIndex);
                    dataGridView3.Rows.Clear();

                    cmd = new SqlCommand("select * from View_DV where Order_No =" + textBox1.Text, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {


                        dataGridView3.Rows.Add(reader["Order_id"].ToString(), reader["name_prodduct"].ToString(), reader["Sale_price"].ToString(), reader["Qty"].ToString(), reader["Total"].ToString());

                    }
                    connection.Close();
                    Order_Total();
                }}

            if (e.ColumnIndex == 6)
            {
                int qtyy = int.Parse(dataGridView3.CurrentRow.Cells[3].Value.ToString());
                if (qtyy > 1)
                {


                    connection.Open();
                    reader.Close();
                    cmd = new SqlCommand("Update Order_tbl set Qty=Qty-@Qty where Order_id=@Order_id ", connection);
                    cmd.Parameters.Add("@Qty", 1);
                    cmd.Parameters.Add("@Order_id", dataGridView3.CurrentRow.Cells[0].Value);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    reader.Close();
                    /////////////////////
                    connection.Open();
                    cmd = new SqlCommand("Update Order_tbl set Total=Qty* Sale_price where  Order_id=@Order_id", connection);


                    cmd.Parameters.Add("@Order_id", dataGridView3.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();

                    reader.Close();
                    dataGridView3.Rows.RemoveAt(e.RowIndex);
                    dataGridView3.Rows.Clear();

                    cmd = new SqlCommand("select * from View_DV where Order_No =" + textBox1.Text, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {


                        dataGridView3.Rows.Add(reader["Order_id"].ToString(), reader["name_prodduct"].ToString(), reader["Sale_price"].ToString(), reader["Qty"].ToString(), reader["Total"].ToString());

                    }
                    connection.Close();
                    Order_Total();






                 }

                     
                else
                    {
                        Delete_product(dataGridView3.CurrentRow.Cells[0].Value);
                        Order_Total();
                    }
            }
                if (e.ColumnIndex == 7)
                {
                    try
                    {
                        Delete_product(dataGridView3.CurrentRow.Cells[0].Value);
                        Order_Total();
                        if (dataGridView3.Rows.Count == 0) { textBox9.ReadOnly = false; textBox9.Enabled = true; }

                    }
                    catch (Exception x) { }

                }
                 

                 
            
            
            
            
        }
        public void Delete_product(object val)
        {
            connection.Open();
            reader.Close();
            try
            {
               
                cmd = new SqlCommand("delete from  Order_tbl where Order_id=@Order_id", connection);
                cmd.Parameters.Add("@Order_id", val);

                cmd.ExecuteNonQuery();

                reader.Close();

                /////////////////////

                dataGridView3.Rows.Clear();

                cmd = new SqlCommand("select * from View_DV where Order_No =" + textBox1.Text, connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {


                    dataGridView3.Rows.Add(reader["Order_id"].ToString(), reader["name_prodduct"].ToString(), reader["Sale_price"].ToString(), reader["Qty"].ToString(), reader["Total"].ToString());

                }
                connection.Close();
            }
            catch (Exception ex) { }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)

            {
                if (dataGridView3.Rows.Count <= 0)
                {
                    textBox9.ReadOnly = false;
                     
                }
                else
                {
                    textBox9.ReadOnly = true;
                    textBox9.Enabled = false;
                }
                if (textBox6.Text != "" && glop != "")
                {
                    if (connection.State.Equals(1)) { connection.Close(); }

                    connection.Open();



                    cmd = new SqlCommand("select * from products where id_prodduct = " + glop, connection);
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader.HasRows)
                    {
                        ID = int.Parse(reader["id_prodduct"].ToString());

                        PRD_name = reader["name_prodduct"].ToString();
                        SALE_price = int.Parse(reader["price_prodduct"].ToString());
                    }
                    reader.Close();
                    connection.Close();


                     


                    if (connection.State.Equals(1)) { connection.Close(); }

                    connection.Open();


                    cmd = new SqlCommand("select * from View_DV where Order_No Like'" + textBox1.Text + "'And id_prodduct = " + ID, connection);

                    reader = cmd.ExecuteReader();
                    reader.Read();
                    //this.Refresh();
                    //try
                    //{
                    //    for (int i = 0; i <= dataGridView3.Rows.Count; i++)
                    //    {

                    //        if (dataGridView3.Rows[i].Cells[1].Value.ToString() == reader["name_prodduct"].ToString()) { MessageBox.Show(reader["name_prodduct"].ToString()); dataGridView3.Rows.RemoveAt(i); }
                    //        else { }

                    //    }
                    //}

                    //catch (Exception ex) { }
                    if (reader.HasRows)
                    {
                        try
                        {
                            for (int i = 0; i <= dataGridView3.Rows.Count; i++)
                            {

                                if (dataGridView3.Rows[i].Cells[1].Value.ToString() == reader["name_prodduct"].ToString()) { MessageBox.Show(reader["name_prodduct"].ToString()); dataGridView3.Rows.RemoveAt(i); }
                                else { }

                            }
                        }

                        catch (Exception ex) { }
                        reader.Close();
                        cmd = new SqlCommand("Update Order_tbl set Qty=@Qty where Order_No=@Order_No and id_prodduct=@id_prodduct", connection);
                        cmd.Parameters.Add("@Qty", textBox6.Text);
                        cmd.Parameters.Add("@Order_No", textBox1.Text);
                        cmd.Parameters.Add("@id_prodduct", ID);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        reader.Close();
                        /////////////////////
                        connection.Open();
                        cmd = new SqlCommand("Update Order_tbl set Total=Qty* Sale_price where Order_No=@Order_No and id_prodduct=@id_prodduct", connection);

                        cmd.Parameters.Add("@Order_No", textBox1.Text);
                        cmd.Parameters.Add("@id_prodduct", ID);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        reader.Close();

                    }
                    else
                    {


                        reader.Close();
                        //long minc = long.Parse(f9.Get_Order_no()) - 1;

                        cmd = new SqlCommand("insert into Order_tbl(Order_No,Order_date,id_prodduct,Sale_price,Qty,Total,tax_total,tax_value,Table_Name,Status,username)values(@Order_No,@Order_date,@id_prodduct,@Sale_price,@Qty,@Total,@tax_total,@tax_value,@Table_Name,@Status,@username)", connection);
                        // int bill_No = int.Parse(f7.billNumber);
                        cmd.Parameters.AddWithValue("@Order_No", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Order_date", datebox);
                        cmd.Parameters.AddWithValue("@id_prodduct", ID);
                        cmd.Parameters.AddWithValue("@Sale_price", SALE_price);
                        int qty = int.Parse(textBox6.Text);
                        cmd.Parameters.AddWithValue("@Qty", qty);
                        double myTotal = qty * SALE_price;
                        //ممكن خطأ
                        double tax_total = myTotal * (double.Parse(textBox9.Text) / 100);
                        cmd.Parameters.AddWithValue("@Total", myTotal);
                        cmd.Parameters.AddWithValue("@tax_total", tax_total);
                        cmd.Parameters.AddWithValue("@tax_value", double.Parse(textBox9.Text));
                        cmd.Parameters.AddWithValue("@Table_Name", table);
                        cmd.Parameters.AddWithValue("@Status", "open");
                        cmd.Parameters.AddWithValue("@username", "admin");

                        cmd.ExecuteNonQuery();
                        connection.Close();
                        reader.Close();


                    }

                    connection.Open();
                    cmd = new SqlCommand("select * from View_DV where Order_No Like'" + textBox1.Text + "'And id_prodduct = " + ID, connection);

                    reader = cmd.ExecuteReader();
                    reader.Read();


                    textBox6.Text = "";

                    load_order();
                    Order_Total();



                }

                else
                {
                    if (textBox6.Text == "")
                    {
                        MessageBox.Show("الرجاء ادخال الكمية"); textBox6.Focus();
                    }
                    else { MessageBox.Show("الرجاء اختيار الصنف اولا"); textBox6.Focus(); }
                }


                
            }
        }
        Double tax_effect = 0.0;
        public void Order_Total()
        {
             

        int number_of_items = dataGridView3.Rows.Count;
        total1 = 0.0;
           
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                total1 += Double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString());

            }
            try
            {
               
           
                textBox7.Text = total1.ToString();
                

                tex_value = Double.Parse(textBox9.Text);
                textBox9.Text = tex_value.ToString() ;
                textBox8.Text = number_of_items.ToString();
                textBox3.Text = (total1 + (total1 * tex_value / 100)).ToString();
                textBox10.Text = ((total1 * tex_value / 100)).ToString() + " د ";
            }
            catch (Exception ex) { }
            
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text+"1";
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "2";
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "3";
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "4";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "5";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "6";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "7";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "8";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "9";
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "0";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text + "00";
        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (connection.State.Equals(1)) { connection.Close(); }

                connection.Open();
                Form1 f1 = new Form1();
              

                cmd = new SqlCommand("select * from products where id_prodduct = " + glop, connection);
                reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    ID = int.Parse(reader["id_prodduct"].ToString());
                    PRD_name = reader["name_prodduct"].ToString();
                    SALE_price = int.Parse(reader["price_prodduct"].ToString());
                }
                reader.Close();
                connection.Close();





                if (connection.State.Equals(1)) { connection.Close(); }

                connection.Open();
                Form1 f7 = new Form1();
                Form7 f8 = new Form7();
                


                cmd = new SqlCommand("select * from View_DV where Order_No Like'" + textBox1.Text + "'And id_prodduct = " + ID, connection);
                 
                reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    reader.Close();
                    cmd = new SqlCommand("Update Order_tbl set Qty=Qty+@Qty where Order_No=@Order_No and id_prodduct=@id_prodduct", connection);
                    cmd.Parameters.Add("@Qty", textBox6.Text);
                    cmd.Parameters.Add("@Order_No", textBox1.Text);
                    cmd.Parameters.Add("@id_prodduct", ID);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    reader.Close();
                

                   


                }
                else
                {




                    reader.Close();
                    //long minc = long.Parse(f9.Get_Order_no()) - 1;

                    cmd = new SqlCommand("insert into Order_tbl(Order_No,Order_date,id_prodduct,Sale_price,Qty,Total,Table_Name,Status,username)values(@Order_No,@Order_date,@id_prodduct,@Sale_price,@Qty,@Total,@Table_Name,@Status,@username)", connection);
                    // int bill_No = int.Parse(f7.billNumber);
                    cmd.Parameters.AddWithValue("@Order_No", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Order_date", f7.datebox);
                    cmd.Parameters.AddWithValue("@id_prodduct", ID);
                    cmd.Parameters.AddWithValue("@Sale_price", SALE_price);
                    int qty = int.Parse(textBox6.Text);
                    cmd.Parameters.AddWithValue("@Qty", qty);
                    int myTotal = qty * SALE_price;//ممكن خطأ
                    cmd.Parameters.AddWithValue("@Total", myTotal);
                    cmd.Parameters.AddWithValue("@Table_Name", table);
                    cmd.Parameters.AddWithValue("@Status", "open");
                    cmd.Parameters.AddWithValue("@username", "admin");

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    reader.Close();
                    MessageBox.Show("reached");
                     

                    




                }
                connection.Open();
                cmd = new SqlCommand("select * from View_DV where Order_No Like'" + textBox1.Text + "'And id_prodduct = " + ID, connection);

                reader = cmd.ExecuteReader();
                reader.Read();

                load_order();
                
                 

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (admin == "admin")
            {

                Form5 f5 = new Form5();
                f5.ShowDialog();
            }
            else { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Systemdata s = new Systemdata();
            s.ShowDialog();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
            
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
          
            
           
             
             

        }
        
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
             

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox7.Text) == 0)
            {
                MessageBox.Show("الرجاء تعبئة الفاتورة اولا");

            }
            else
            {
                connection.Close();
                connection.Open();
                cmd = new SqlCommand("delete from Order_tbl where Order_No=@Order_No", connection);
                cmd.Parameters.AddWithValue("@Order_No", textBox1.Text);
                cmd.ExecuteNonQuery();
                connection.Close();
                dataGridView3.Rows.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox7.Text="0";
                textBox8.Text="0";
                textBox3.Text="00.00";
                textBox9.Text = "0";
                textBox10.Text = "0";

                MessageBox.Show("تم الغاء الفاتورة بنجاح");
            }

                // MessageBoxOptions.RightAlign.ToSt("d");

            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CatMangment cm = new CatMangment();
            cm.ShowDialog();

           

        }
        public void one (string s)
        {
            CatMangment cm = new CatMangment();
            connection.Open();
            string delete = "delete from cat_tbl where name_cat = @name_cat";
            cmd = new SqlCommand(delete, connection);
            cmd.Parameters.AddWithValue("@name_cat", s);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Done");
            //Form1 ff = new Form1();

            //ff.Show();
        
        }

        private void button26_Click(object sender, EventArgs e)
        {
            MessageBox.Show(admin);
           
            
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = true;
            if (dataGridView3.Rows.Count <= 0) { read(); }
         
  

            flowLayoutPanel3.Controls.Clear();
            
            load_Cats();

            
            connection.Open();
            cmd = new SqlCommand("select * from users where casher_id=" + casher_id.ToString(), connection);
            reader = cmd.ExecuteReader();
            reader.Read();
            if (  Boolean.Parse( reader["status"].ToString()) ==true )
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button10.Enabled = true;
                button27.Enabled = false;
                pictureBox4.Enabled = true;
                pictureBox5.Enabled = true;
                pictureBox6.Enabled = true;
                pictureBox7.Enabled = true;
                pictureBox8.Enabled = false;
                reader.Close();
                connection.Close();
            }
             
           else
            {

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button10.Enabled = false;
                button27.Enabled = true;
                pictureBox4.Enabled = false;
                pictureBox5.Enabled = false;
                pictureBox6.Enabled = false;
                pictureBox7.Enabled = false;
                pictureBox8.Enabled = true;
                reader.Close();
                connection.Close();
            
            
            } 
        }


        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
             istlam ist= new istlam();
             ist.cahser_id = casher_id;
             ist.Order_Date = dateTimePicker1.Text;
             ist.name_current_cahser = name_current_cahser;
             ist.ShowDialog();
             bank =ist. bank;
        }

        private void button10_Click(object sender, EventArgs e)
        {
             
            Taslem f9 = new Taslem();
            f9.cahser_id = casher_id;
            bank = f9.bank;
            f9.name_current_cahser = name_current_cahser;
            f9.Final = Double.Parse(textBox3.Text);
            f9.Order_No = textBox1.Text;
            f9.Order_Date = dateTimePicker1.Text;
            f9.Order_total = Double.Parse(textBox7.Text);
            f9.Order_taxValue = Double.Parse(textBox9.Text);
            f9.Order_taxTotal = f9.Order_total * f9.Order_taxValue / 100;
            f9.cahser_id = casher_id;
            f9.ShowDialog();
            

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
