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
    public partial class Register : Form
    {
        int id = 2;
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deep\source\repos\WebApi\WebApi\App_Data\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from login Where username='" + textBox1.Text.ToString() + "' ", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count == 1)
            {

                label3.Text = "Username already exist!!";
             //   this.Hide();
                
               // login f = new login();
               // f.ShowDialog();


            }
            else
            {
               
                    id++;
                    label3.Text = "You are Register successfully!!";
               
            }
           
            



        }
    }
}
