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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace part2._2
{
    public partial class Form3 : Form
    {
        
        SqlConnection connection1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\mbdba\Desktop\New folder (4)\part2.2\harbor.mdf;Integrated Security = True");
        
        public Form3()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false; 
            dataGridView1.ReadOnly = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            filldvg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();  
            f4.Show();  
                this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(); 
            f5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Cid = int.Parse(txtarea.Text);
            String status = "";
            String Snotes=txtsnotes.Text;
            DateTime selectedDate = dateTimePicker1.Value;

            if (radioButton1.Checked)
            {
                status = "Checked";
            }
            if(radioButton2.Checked)
            {
                status = "Notchecked";
            }
            string Query = "INSERT INTO maintain(Container_ID,status,special_notes,Date_and_Time) VALUES (@Cid, @status,@Snotes,@selectedDate)";
            try
            {
             
                SqlCommand cmd = new SqlCommand(Query, connection1);

                cmd.Parameters.AddWithValue("@Cid", Cid);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@Snotes", Snotes);
                cmd.Parameters.AddWithValue("@selectedDate", selectedDate);

                connection1.Open();

              
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
              
                connection1.Close();
            }

            filldvg();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
                f6.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void filldvg()
        {
            connection1.Open();
            string query = "Select * From maintain";
            SqlDataAdapter da = new SqlDataAdapter(query, connection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection1.Close();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    
                    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                    int selectedId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Container_ID"].Value);

                
                    connection1.Open();

                   
                    string deleteQuery = "DELETE FROM maintain WHERE Container_ID = @Cid";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection1);
                    deleteCmd.Parameters.AddWithValue("@Cid", selectedId);

                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("Selected data deleted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                   
                    connection1.Close();
                }

                filldvg(); 
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

    }
}
    

