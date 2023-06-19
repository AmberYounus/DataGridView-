using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataGridView_Assignment
{
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection(@"server=localhost ;user id=root;password=Mysql@Password125 ;database=datagridview_db");
        public int id;
        public Form1()
        {
            InitializeComponent();
        }

        int index;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Isvalid())  //call function
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO table VALUES(@ID, @First Name, @Last Name, @Age, @Gender , @Father Name ,@Phone ,@Address", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductID", textBox1.Text);
                cmd.Parameters.AddWithValue(" @First Name", textBox2.Text);
                cmd.Parameters.AddWithValue(" @Last Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue(" @Gender", comboBox1.Text);
               
                cmd.Parameters.AddWithValue("@Father Name", textBox5.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox6.Text);
                cmd.Parameters.AddWithValue(" @Address", textBox7.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record successfully saved in database ", "SAVED", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                getRecords();  		 //call function
                reset(); 		 //call function
            


        }
        


                if (textBox1.Text.Length <= 0 ||
                textBox2.Text.Length <= 0 ||
                textBox3.Text.Length <= 0 ||
                textBox4.Text.Length <= 0 ||
                textBox5.Text.Length <= 0 ||
                textBox6.Text.Length <= 0 ||
                textBox7.Text.Length <= 0)
            {
                MessageBox.Show("All Textbox Must be Filled...");
            }
            else
            {
                dataGridView1.Rows.Add(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text, comboBox1.Text, textBox5.Text,textBox6.Text,textBox7.Text);

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;

            try
            {
                textBox1.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("No data to delete.");
            }
            else
            {
                dataGridView1.Rows.RemoveAt(index);
                MessageBox.Show("Row Deleted Successfully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                MySqlCommand cmd = new MySqlCommand("UPDATE product table VALUES(@ID, @First Name, @Last Name, @Age, @Gender , @Father Name ,@Phone ,@Address", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProductID", textBox1.Text);
                cmd.Parameters.AddWithValue(" @First Name", textBox2.Text);
                cmd.Parameters.AddWithValue(" @Last Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue(" @Gender", comboBox1.Text);

                cmd.Parameters.AddWithValue("@Father Name", textBox5.Text);
                cmd.Parameters.AddWithValue("@Phone", textBox6.Text);
                cmd.Parameters.AddWithValue(" @Address", textBox7.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record successfully updated in database ", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                getRecords();	   //call function
                reset();        //call function
            }
            else
            {
                MessageBox.Show("PLEASE! Select Row Record was not updated ", "SELECT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

            
            
            
            
            
            
            
            if (textBox1.Text.Length <= 0 ||
                textBox2.Text.Length <= 0 ||
                textBox3.Text.Length <= 0 ||
                textBox4.Text.Length <= 0 ||
                textBox5.Text.Length <= 0 ||
                textBox6.Text.Length <= 0 ||
                textBox7.Text.Length <= 0)
            {
                MessageBox.Show("All Textbox Must be Filled...");
            }
            else
            {
                dataGridView1.Rows[index].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[index].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[index].Cells[2].Value = textBox3.Text;
                dataGridView1.Rows[index].Cells[3].Value = textBox4.Text;
                dataGridView1.Rows[index].Cells[4].Value = comboBox1.Text;
                dataGridView1.Rows[index].Cells[5].Value = textBox5.Text;
                dataGridView1.Rows[index].Cells[6].Value = textBox6.Text;
                dataGridView1.Rows[index].Cells[7].Value = textBox7.Text;

                MessageBox.Show("Row Updated Successfully.");

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // GetRecord();
        }
        private bool Isvalid()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("ID is required", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

       // private void GetRecord()
      //  {
          //  string conString = "server=localhost;user id=root;database=datagridview_db ";
          //  string loginQuery = "SELECT * FROM table ";
          //  MySqlConnection con = new MySqlConnection(conString);
          // MySqlCommand cmd = new MySqlCommand(loginQuery, con);
          //  DataTable dt = new DataTable();

           // con.Open();
          //  MySqlDataReader sdr = cmd.ExecuteReader();
           // dt.Load(sdr);
           // con.Close();

          //  dataGridView1.DataSource = dt;

     //   }
        private void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Focus();
        }

        private void getRecords()
        {

            MySqlCommand cmd = new MySqlCommand("Select * from product", con);
            DataTable dataTable = new DataTable();
            con.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dataTable.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dataTable;
        }

    }
}

