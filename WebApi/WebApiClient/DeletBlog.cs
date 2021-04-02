using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApiClient
{
    public partial class DeletBlog : Form
    {
        static HttpClient httpClient = new HttpClient();
        public DeletBlog()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "")
            {
                label2.Text = "Error!! Enter ID";
            }
            else
            {
                label2.Text = "";
                
            }
            RemoveBlogeAsync();

        }

        private async Task RemoveBlogeAsync()
        {
            var result = await httpClient.DeleteAsync("https://localhost:44332/api/Blogs/" + Int32.Parse(textBox1.Text));
            label3.Text = "Story/Poem Deleted!!";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() != "")
            {
                label2.Text = "";
            }
        }
    }
}
