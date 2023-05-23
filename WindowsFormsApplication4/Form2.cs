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
    public partial class Form2 : Form
    {
        SqlConnection connection;
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        SqlDataReader rdr;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlCommand command;
        DataTable data;
        CurrencyManager manger;
        SqlCommandBuilder builder;

        int CountID = 0;
        public Form2()
        {
            InitializeComponent();

            
            connection = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
            conn = new SqlConnection("server=PP-PC;database=mangment;Integrated Security=true");
          

            




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void insertEasy() 
        {
            connection.Close();
            connection.Open();
 

            string register = " select  id_prodduct from products where id_prodduct= '" + textBox1.Text + "'"; 
            // كتابة الاستعلام المطلوب بشكل منفصل في متغير



            cmd = new SqlCommand(register, connection);

            reader = cmd.ExecuteReader();


            if (!reader.Read())
            {

                try
                {
                    //اغلاق كائن الفراءة لكي لايسبب مشكلة اثناء تحقق شرط اخر
                    reader.Close();
                    string selected = comboBox1.SelectedItem.ToString();


                    // هنا يتم كتابة الاستعلام الخاص بتسجيل مريض جديد في قاعدة البيانات



                    // String insertM = string.Format("insert into products (id_prodduct,name_prodduct,id_class,price_prodduct,status_prodduct) values ({0},'{1}',{2},'{3}','{4}')",
                    //     textBox1.Text, textBox2.Text, 10, textBox3.Text, textBox4.Text);

                    command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                    reader = command.ExecuteReader();
                    reader.Read();
                    CountID = int.Parse(reader[""].ToString()) + 1;

                    reader.Close();
                  
                    conn.Open();
                    cmd2 = new SqlCommand("select * from cat_tbl where name_cat Like '" + selected + "'", conn);
                    rdr = cmd2.ExecuteReader();
                    rdr.Read();


                    MessageBox.Show(rdr["id_cat"].ToString());
                    if (rdr.HasRows)
                    {


                        var image_Meal = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                        cmd.Parameters.AddWithValue("@image", image_Meal);


                        string insertProd1 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";
                        cmd = new SqlCommand(insertProd1, connection);
                        cmd.Parameters.AddWithValue("@idProd", textBox1.Text);
                        cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                        cmd.Parameters.AddWithValue("@inclass", int.Parse(rdr["id_cat"].ToString()));
                        cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                        cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                        cmd.Parameters.AddWithValue("@image", image_Meal);



                        cmd.ExecuteNonQuery();


                        MessageBox.Show("تم اضافة المنتج بنجاح");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        comboBox1.Text = "";
                         
                    }
                    else { MessageBox.Show("error"); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            else { MessageBox.Show("رقم المنتج موجود بالفعل"); }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            


            insertEasy();
            dataGridView3.Rows.Clear();            
            Load_products_in_dataGV();



        }
        public void insertBlock()
        {
            connection.Open();


            string register = " select  id_prodduct from products where id_prodduct= '" + textBox1.Text + "'";
            // كتابة الاستعلام المطلوب بشكل منفصل في متغير



            cmd = new SqlCommand(register, connection);

            reader = cmd.ExecuteReader();


            if (!reader.Read())
            {

                try
                {
                    //اغلاق كائن الفراءة لكي لايسبب مشكلة اثناء تحقق شرط اخر
                    reader.Close();
                    string selected = comboBox1.SelectedItem.ToString();


                    // هنا يتم كتابة الاستعلام الخاص بتسجيل مريض جديد في قاعدة البيانات





                    switch (selected)
                    {
                        case "الوجبات":

                            // String insertM = string.Format("insert into products (id_prodduct,name_prodduct,id_class,price_prodduct,status_prodduct) values ({0},'{1}',{2},'{3}','{4}')",
                            //     textBox1.Text, textBox2.Text, 10, textBox3.Text, textBox4.Text);

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;

                            reader.Close();

                            cmd2 = new SqlCommand("select id_cat from cat_tbl where name_cat=" + selected, connection);
                            rdr = cmd2.ExecuteReader();
                            rdr.Read();


                            var image_Meal = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", image_Meal);


                            string insertProd1 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";
                            cmd = new SqlCommand(insertProd1, connection);
                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", rdr["id_cat"]);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", image_Meal);



                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");

                            //string insertM = "insert into meals values(@id_meal,@name_meal,@price,@amount_meal,@id_classML,@image)";                           
                            //cmd = new SqlCommand(insertM, connection);
                            //cmd.Parameters.AddWithValue("@id_meal", CountID);
                            //cmd.Parameters.AddWithValue("@name_meal", textBox2.Text);
                            //cmd.Parameters.AddWithValue("@price", textBox3.Text);
                            //cmd.Parameters.AddWithValue("@amount_meal", textBox4.Text);
                            //cmd.Parameters.AddWithValue("@id_classML", 1);
                            //cmd.Parameters.AddWithValue("@image", image_Meal);


                            //if (cmd.ExecuteNonQuery() > 0)
                            //{

                            //    MessageBox.Show("added");

                            //}
                            //else { MessageBox.Show("Not added"); }



                            //MessageBox.Show("الوجبات");





                            break;


                        // String add = string.Format("insert into meals (id_meal,name_meal,price,amount_meal,id_classML) values ({0},'{1}',{2},'{3}',{4})",
                        // textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,10);



                        case "السندوتشات":

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;

                            reader.Close();

                            var image_S = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", image_S);


                            string insertProd2 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";
                            cmd = new SqlCommand(insertProd2, connection);
                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 2);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", image_S);



                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");



                            string addSandwish = "insert into sandwiches values(@id_sandwich,@name_sandwich,@price_sandwich,@amount_sandwich,@id_classSN,@image)";

                            cmd = new SqlCommand(addSandwish, connection);
                            cmd.Parameters.AddWithValue("@id_sandwich", CountID);
                            cmd.Parameters.AddWithValue("@name_sandwich", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_sandwich", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_sandwich", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classSN", 2);
                            cmd.Parameters.AddWithValue("@image", image_S);




                            if (cmd.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("added");

                            }
                            else { MessageBox.Show("Not added"); }



                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تمت الاضافة الى قائمة الساندوتشات");
                            break;

                        case "المعجنات":

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;

                            reader.Close();

                            var img_P = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", img_P);

                            string insertProd3 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";

                            cmd = new SqlCommand(insertProd3, connection);

                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 3);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", img_P);

                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");

                            string addPastries = "insert into pastries values(@id_pastries,@name_pastries,@price_pastries,@amount_pastries,@id_classPS,@image)";
                            cmd = new SqlCommand(addPastries, connection);
                            cmd.Parameters.AddWithValue("@id_pastries", CountID);
                            cmd.Parameters.AddWithValue("@name_pastries", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_pastries", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_pastries", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classPS", 3);
                            cmd.Parameters.AddWithValue("@image", img_P);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تمت الاضافة الى قائمة المعجنات");
                            break;

                        // String addPastries = string.Format("insert into pastries (id_pastries,name_pastries,price_pastries,amount_pastries,id_classPS) values ({0},'{1}',{2},{3},{4})",
                        //           textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,30);

                        //   command = new SqlCommand(addPastries, conn);
                        ///   command.ExecuteNonQuery();




                        case "المشروبات الساخنه":
                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;
                            reader.Close();
                            var img_Hot = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", img_Hot);

                            string insertProd4 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";

                            cmd = new SqlCommand(insertProd4, connection);

                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 4);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", img_Hot);

                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");


                            string addHotDrink = "insert into hotdrinks values(@id_hdrink,@name_hdrink,@price_hdrink,@amount_hdrink,@id_classHOT,@image)";
                            cmd = new SqlCommand(addHotDrink, connection);
                            cmd.Parameters.AddWithValue("@id_hdrink", CountID);
                            cmd.Parameters.AddWithValue("@name_hdrink", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_hdrink", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_hdrink", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classHOT", 4);
                            cmd.Parameters.AddWithValue("@image", img_Hot);



                            if (cmd.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("added");

                            }
                            else { MessageBox.Show("Not added"); }


                            MessageBox.Show("المشروبات الساخنه");
                            break;

                        case "المشروبات الباردة":

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;
                            reader.Close();

                            var img_Cold = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", img_Cold);

                            string insertProd5 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";

                            cmd = new SqlCommand(insertProd5, connection);

                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 5);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", img_Cold);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تم اضافة المنتج بنجاح");


                            string addColdDrink = "insert into colddrinks values(@id_cdrink,@name_cdrink,@price_cdrink,@amount_cdrink,@id_classCL,@image)";
                            cmd = new SqlCommand(addColdDrink, connection);
                            cmd.Parameters.AddWithValue("@id_cdrink", CountID);
                            cmd.Parameters.AddWithValue("@name_cdrink", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_cdrink", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_cdrink", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classCL", 5);
                            cmd.Parameters.AddWithValue("@image", img_Cold);

                            if (cmd.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("added");

                            }
                            else { MessageBox.Show("Not added"); }



                            MessageBox.Show("المشروبات الباردة");
                            break;


                        default:
                            MessageBox.Show("error Switch");
                            break;

                    }







                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                finally
                {
                    reader.Close();
                    connection.Close();
                }

            }

            else
            {
                MessageBox.Show("رقم المنتج موجود بالفعل");
                connection.Close();
                reader.Close();
            }







        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
             

            string register = " select  id_prodduct from products where id_prodduct= '" + textBox1.Text + "'"; 
            // كتابة الاستعلام المطلوب بشكل منفصل في متغير



            cmd = new SqlCommand(register, connection);

            reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                try
                {
                    //اغلاق كائن الفراءة لكي لايسبب مشكلة اثناء تحقق شرط اخر
                    reader.Close();

                        string dMeals = "delete from meals where id_meal in (select id_prodduct from products where id_prodduct ='" + textBox1.Text.ToString() + "')";
                        // Firstly delete the product from Meals table ^ 
                        command = new SqlCommand(dMeals, connection);
                        command.ExecuteNonQuery();

                        string dProducts = "delete from products where id_prodduct =" + textBox1.Text.ToString() ;
                        // finaly delete the product from products table ^
                        command = new SqlCommand(dProducts, connection);
                        command.ExecuteNonQuery();

                        MessageBox.Show("تم حذف المنتج نهائية");
                    
                }



                catch (Exception ex)
                {

                     MessageBox.Show("error");
                    

                }
            }
            
            
            else 
                {     
                    MessageBox.Show("رقم المنتج غير موجود");
            
                 }
            try { }



            finally { connection.Close(); }




        

    
        }
        public void loadLastProductID()
        {
            connection.Close();
            connection.Open();

            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
            reader = command.ExecuteReader();
            reader.Read();

            int CountID1 = int.Parse(reader[""].ToString()) + 1;

            textBox1.Text = CountID1.ToString();
            textBox2.Focus();

            connection.Close();
            reader.Close();
        }
        public void LoadComboBoxItems() 
        {

            connection.Open();
            string query = "select * from cat_tbl";
            cmd = new SqlCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(1));

            }
            connection.Close();
        
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadLastProductID();
            LoadComboBoxItems();
            Load_products_in_dataGV();
           
            Dictionary<int, string> dic = new Dictionary<int, string> { };

            dic.Add(1, "الوجبات");
            dic.Add(2, "السندوتشات");
            dic.Add(3, "المعجنات");
            dic.Add(4, "المشروبات الباردةة");
            dic.Add(5, "المشروبات الساخنه");

           // comboBox1.DataSource = new BindingSource(dic, null);
           // comboBox1.DisplayMember = "Value";
           // comboBox1.ValueMember = "Key";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.FileName = "";
            OP.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
            if (OP.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Load(OP.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
           
            SqlCommand comm = connection.CreateCommand();
            connection.Open();
             
            comm.CommandText = "select * from products where id_prodduct =@id";
            comm.Parameters.AddWithValue("@id", textBox1.Text);
            reader = comm.ExecuteReader();
             

            if (reader.Read())
            {
                string selectedItem = reader["id_class"].ToString();
                switch (selectedItem)
                {
                        case "1":
                        selectedItem = "الوجبات";            break;
                        case "2":
                        selectedItem = "السندوتشات";         break;
                        case "3":
                        selectedItem = "المعجنات";           break;
                        case "4":
                        selectedItem = "المشروبات الساخنة"; break;
                        case "5":
                        selectedItem = "المشروبات الباردة"; break;
                        default:
                        MessageBox.Show("error Switch");      break;
                } 



                MemoryStream str = new MemoryStream(reader.GetSqlBytes(5).Buffer);
                pictureBox1.Image = Image.FromStream(str);
                textBox2.Text = reader["name_prodduct"].ToString();
                comboBox1.Text = selectedItem;
                textBox3.Text = reader["price_prodduct"].ToString();
                textBox4.Text = reader["status_prodduct"].ToString();
                connection.Close();

            }
            else { MessageBox.Show("رقم المنتج غير موجود"); connection.Close(); }


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand comm = connection.CreateCommand();
            connection.Open();

            comm.CommandText = "select * from products where id_prodduct =@id";
            comm.Parameters.AddWithValue("@id", textBox1.Text);
            reader = comm.ExecuteReader();


            if (reader.Read())
            {


                try
                {
                    //اغلاق كائن الفراءة لكي لايسبب مشكلة اثناء تحقق شرط اخر
                    reader.Close();
                    string selected = comboBox1.SelectedItem.ToString();


                    // هنا يتم كتابة الاستعلام الخاص بتسجيل مريض جديد في قاعدة البيانات





                    switch (selected)
                    {
                        case "الوجبات":

                            // String insertM = string.Format("insert into products (id_prodduct,name_prodduct,id_class,price_prodduct,status_prodduct) values ({0},'{1}',{2},'{3}','{4}')",
                            //     textBox1.Text, textBox2.Text, 10, textBox3.Text, textBox4.Text);

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;

                            reader.Close();


                            var image_Meal = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", image_Meal);


                            string insertProd1 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";
                            cmd = new SqlCommand(insertProd1, connection);
                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 1);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", image_Meal);



                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");

                            string insertM = "insert into meals values(@id_meal,@name_meal,@price,@amount_meal,@id_classML,@image)";
                            cmd = new SqlCommand(insertM, connection);
                            cmd.Parameters.AddWithValue("@id_meal", CountID);
                            cmd.Parameters.AddWithValue("@name_meal", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_meal", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classML", 1);
                            cmd.Parameters.AddWithValue("@image", image_Meal);


                            if (cmd.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("added");

                            }
                            else { MessageBox.Show("Not added"); }



                            MessageBox.Show("الوجبات");





                            break;


                        // String add = string.Format("insert into meals (id_meal,name_meal,price,amount_meal,id_classML) values ({0},'{1}',{2},'{3}',{4})",
                        // textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,10);



                        case "السندوتشات":

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;

                            reader.Close();

                            var image_S = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", image_S);


                            string insertProd2 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";
                            cmd = new SqlCommand(insertProd2, connection);
                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 2);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", image_S);



                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");



                            string addSandwish = "insert into sandwiches values(@id_sandwich,@name_sandwich,@price_sandwich,@amount_sandwich,@id_classSN,@image)";

                            cmd = new SqlCommand(addSandwish, connection);
                            cmd.Parameters.AddWithValue("@id_sandwich", CountID);
                            cmd.Parameters.AddWithValue("@name_sandwich", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_sandwich", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_sandwich", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classSN", 2);
                            cmd.Parameters.AddWithValue("@image", image_S);




                            if (cmd.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("added");

                            }
                            else { MessageBox.Show("Not added"); }



                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تمت الاضافة الى قائمة الساندوتشات");
                            break;

                        case "المعجنات":

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;

                            reader.Close();

                            var img_P = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", img_P);

                            string insertProd3 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";

                            cmd = new SqlCommand(insertProd3, connection);

                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 3);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", img_P);

                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");

                            string addPastries = "insert into pastries values(@id_pastries,@name_pastries,@price_pastries,@amount_pastries,@id_classPS,@image)";
                            cmd = new SqlCommand(addPastries, connection);
                            cmd.Parameters.AddWithValue("@id_pastries", CountID);
                            cmd.Parameters.AddWithValue("@name_pastries", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_pastries", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_pastries", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classPS", 3);
                            cmd.Parameters.AddWithValue("@image", img_P);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تمت الاضافة الى قائمة المعجنات");
                            break;

                        // String addPastries = string.Format("insert into pastries (id_pastries,name_pastries,price_pastries,amount_pastries,id_classPS) values ({0},'{1}',{2},{3},{4})",
                        //           textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,30);

                        //   command = new SqlCommand(addPastries, conn);
                        ///   command.ExecuteNonQuery();




                        case "المشروبات الساخنه":
                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;
                            reader.Close();
                            var img_Hot = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", img_Hot);

                            string insertProd4 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";

                            cmd = new SqlCommand(insertProd4, connection);

                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 4);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", img_Hot);

                            cmd.ExecuteNonQuery();


                            MessageBox.Show("تم اضافة المنتج بنجاح");


                            string addHotDrink = "insert into hotdrinks values(@id_hdrink,@name_hdrink,@price_hdrink,@amount_hdrink,@id_classHOT,@image)";
                            cmd = new SqlCommand(addHotDrink, connection);
                            cmd.Parameters.AddWithValue("@id_hdrink", CountID);
                            cmd.Parameters.AddWithValue("@name_hdrink", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_hdrink", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_hdrink", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classHOT", 4);
                            cmd.Parameters.AddWithValue("@image", img_Hot);



                            if (cmd.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("added");

                            }
                            else { MessageBox.Show("Not added"); }


                            MessageBox.Show("المشروبات الساخنه");
                            break;

                        case "المشروبات الباردة":

                            command = new SqlCommand("SELECT COUNT(id_prodduct)FROM products", connection);
                            reader = command.ExecuteReader();
                            reader.Read();
                            CountID = int.Parse(reader[""].ToString()) + 1;
                            reader.Close();

                            var img_Cold = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));
                            cmd.Parameters.AddWithValue("@image", img_Cold);

                            string insertProd5 = "insert into products values(@idProd,@nameProd,@inclass,@priceProd,@statusProd,@image)";

                            cmd = new SqlCommand(insertProd5, connection);

                            cmd.Parameters.AddWithValue("@idProd", CountID);
                            cmd.Parameters.AddWithValue("@nameProd", textBox2.Text);
                            cmd.Parameters.AddWithValue("@inclass", 5);
                            cmd.Parameters.AddWithValue("@priceProd", textBox3.Text);
                            cmd.Parameters.AddWithValue("@statusProd", textBox4.Text);
                            cmd.Parameters.AddWithValue("@image", img_Cold);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تم اضافة المنتج بنجاح");


                            string addColdDrink = "insert into colddrinks values(@id_cdrink,@name_cdrink,@price_cdrink,@amount_cdrink,@id_classCL,@image)";
                            cmd = new SqlCommand(addColdDrink, connection);
                            cmd.Parameters.AddWithValue("@id_cdrink", CountID);
                            cmd.Parameters.AddWithValue("@name_cdrink", textBox2.Text);
                            cmd.Parameters.AddWithValue("@price_cdrink", textBox3.Text);
                            cmd.Parameters.AddWithValue("@amount_cdrink", textBox4.Text);
                            cmd.Parameters.AddWithValue("@id_classCL", 5);
                            cmd.Parameters.AddWithValue("@image", img_Cold);

                            if (cmd.ExecuteNonQuery() > 0)
                            {

                                MessageBox.Show("added");

                            }
                            else { MessageBox.Show("Not added"); }



                            MessageBox.Show("المشروبات الباردة");
                            break;


                        default:
                            MessageBox.Show("error Switch");
                            break;

                    }







                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                finally
                {
                    reader.Close();
                    connection.Close();
                }












            }
            else { MessageBox.Show("رقم المنتج غير موجود"); connection.Close(); }









        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void Load_products_in_dataGV()
        {
            connection.Close();
            connection.Open();
            cmd = new SqlCommand("select * from products", connection);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {


                dataGridView3.Rows.Add(reader["name_prodduct"], reader["id_class"], reader["price_prodduct"], reader["status_prodduct"], reader["image"]);



            }
            connection.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
           
          

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
