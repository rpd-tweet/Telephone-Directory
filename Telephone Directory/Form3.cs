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

namespace Telephone_Directory
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\telephone.mdf;Integrated Security=True;Connect Timeout=30");

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (textBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Enter all fields");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Table] SET Location= '" + textBox5.Text + "',email='" + textBox4.Text + "' WHERE ContactNumber='" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contact updated");
                    Form2 obj = new Form2();
                    obj.Show();
                    this.Hide();
                }
                con.Close();
            }
            catch(Exception exceptionE)
            {
                MessageBox.Show("Server busy, try again later");
                this.Hide();
            }

        }
    }
}
