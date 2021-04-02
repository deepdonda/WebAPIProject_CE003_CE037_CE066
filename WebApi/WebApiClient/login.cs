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

namespace WebApiClient
{
    public partial class login : Form
    {
        public static String username;
        public login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deep\source\repos\WebApi\WebApi\App_Data\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                SqlDataAdapter sda = new SqlDataAdapter("Select * from login Where username='" + textBox1.Text.ToString() + "'and password='" + textBox2.Text.ToString() + "' ", con);
                DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {

                    this.Hide();
                    username = dt.Rows[0][1].ToString();
                        Form1 f = new Form1();
                        f.ShowDialog();
                        
                    
                }
                else
                {
                    label3.Text = "Enter valid Username And Password!!";
                }
            }
            else
            {
                if (textBox1.Text.ToString() == "" && textBox2.Text.ToString()=="")
                {
                    label3.Text = "Enter username and password!!";
                }
                else if (textBox1.Text.ToString() == "" )
                {
                    label3.Text = "Enter username!!";
                }
                else if (textBox2.Text.ToString() == "")
                {
                    label3.Text = "Enter Password!!";
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           
            Register f = new Register();
            f.ShowDialog();
        }
    }
}
