using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace part2._2
{
    public partial class Form4 : Form
    {

        SqlConnection connection1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\mbdba\Desktop\New folder (4)\part2.2\harbor.mdf;Integrated Security = True");

        public Form4()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false; 
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            int CID= int.Parse(txtcid.Text);
            string ShipName = txtshipname.Text;
            string SpecialNotes = txtsnotes.Text;
            string Status = "";

            if(radioButton1.Checked)
            {
                Status = "Arrived";
            }
            if (radioButton2.Checked)
            {
                Status = "NotArrived";

            }

                  
                    string Query = " INSERT INTO imports(Container_ID, status, shipname, special_notes) VALUES(@CID, @Status, @ShipName, @SpecialNotes )";
            try
            {
              
                SqlCommand cmd = new SqlCommand(Query, connection1);

                
                cmd.Parameters.AddWithValue("@CID", CID );
                cmd.Parameters.AddWithValue("@ShipName", ShipName);
                cmd.Parameters.AddWithValue("@SpecialNotes", SpecialNotes);
                cmd.Parameters.AddWithValue("@Status", Status);

                
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

        private void panel5_Paint(object sender, PaintEventArgs e)
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
            string query = "Select * From imports";
            SqlDataAdapter da = new SqlDataAdapter(query, connection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection1.Close();


        }

        private void Form4_Load(object sender, EventArgs e)
        {
            filldvg();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

                    
                    string deleteQuery = "DELETE FROM imports WHERE Container_ID = @CID";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection1);
                    deleteCmd.Parameters.AddWithValue("@CID", selectedId);

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

        private void txtshipname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

