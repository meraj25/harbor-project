using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part2._2
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String admin = "admin";
           String Username = txtuname.Text;
           String Pass = txtpass.Text;

            if (Username == admin && Pass == admin)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
         
                MessageBox.Show("Access granted! ");
            }
            if(Username !=admin)
            {
                MessageBox.Show("Entered username is incorrect please try again!");

            }

            if (Pass != admin)
            {
                MessageBox.Show("Entered password is incorrect please try again!");
            }
           
            
          
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

 

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.CheckState == CheckState.Checked)
            {
                txtpass.UseSystemPasswordChar = false;

            }
            else 
            {
                txtpass.UseSystemPasswordChar= true;
            
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
