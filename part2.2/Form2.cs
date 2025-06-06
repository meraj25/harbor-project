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
using static System.Windows.Forms.MonthCalendar;

namespace part2._2
{
    public partial class Form2 : Form
    {
        
        SqlConnection connection1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\mbdba\Desktop\New folder (4)\part2.2\harbor.mdf;Integrated Security = True");
        public Form2()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false; 
            dataGridView1.ReadOnly = true; 

        }

        private void Form2_Load(object sender, EventArgs e)
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
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
           
                int Cid1 = int.Parse(txtCid.Text);
                String secstatus = "";
            String snotes = txtSnotes.Text;
            DateTime selectedDate = dateTimePicker1.Value;

            if (radioButton1.Checked) 
            {
                secstatus = "checked";
            }
            if(radioButton2.Checked)
            {
                secstatus = "Notchecked";
            }

            string Query = "INSERT INTO Security(container_ID, status, special_notes,Date_and_time) VALUES (@Cid1, @secstatus, @snotes,@selectedDate)";

                try
                {
                    SqlCommand cmd = new SqlCommand(Query, connection1);

                    cmd.Parameters.AddWithValue("@Cid1", Cid1);
                cmd.Parameters.AddWithValue("@secstatus", secstatus);
                    cmd.Parameters.AddWithValue("@snotes", snotes);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void filldvg()
        {
            connection1.Open();
            string query = "Select * From Security";
            SqlDataAdapter da = new SqlDataAdapter(query,connection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection1.Close();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    try
                    {
                        int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                        int selectedId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Container_ID"].Value);
                        connection1.Open();
                        string deleteQuery = "DELETE FROM Security WHERE container_ID = @Cid1";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection1);
                        deleteCmd.Parameters.AddWithValue("@Cid1", selectedId);
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

