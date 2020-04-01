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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\telephone.mdf;Integrated Security=True;Connect Timeout=30");
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("Enter atleast one field");
            }
            else
            {
                try
                {
                    SqlDataReader r;
                    if (textBox2.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand(" SELECT * FROM [dbo].[Table] WHERE ContactNumber='" + textBox2.Text + "'", con);
                        r = cmd.ExecuteReader();
                    }
                    else if (textBox3.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand(" SELECT * FROM [dbo].[Table] WHERE email='" + textBox4.Text + "'", con);
                        r = cmd.ExecuteReader();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(" SELECT * FROM [dbo].[Table] WHERE Location='" + textBox3.Text + "'", con);
                        r = cmd.ExecuteReader();
                    }
                    textBox1.Text = "";
                    string newLine = Environment.NewLine;
                    while (r.Read() == true)
                    {
                        textBox1.Text += "Name : " + r.GetString(0) + " " + r.GetString(1) + newLine + "Phone Number : " + r.GetString(2) + newLine + "email : " + r.GetString(3) + newLine + "Location : " + r.GetString(4);
                    }


                    con.Close();
                }
                catch (Exception exceptionE)
                {
                    MessageBox.Show("Server busy, try again later");
                    this.Hide();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }
  
    }
}
