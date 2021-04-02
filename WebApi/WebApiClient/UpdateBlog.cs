using Newtonsoft.Json;
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
    public partial class UpdateBlog : Form
    {
        static HttpClient httpClient = new HttpClient();

        public partial class Blog
        {
            public int Id { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string writer_name { get; set; }
        }
        public UpdateBlog()
        {
            InitializeComponent();
        }

        private void UpdateBlog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Blog' table. You can move, or remove it, as needed.
            this.blogTableAdapter.Fill(this.database1DataSet1.Blog);
            label9.Text = ""; label10.Text = ""; label11.Text = ""; label12.Text = "";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            
            if (textBox1.Text.ToString() == "")
            {
                a++;
                label9.Text = "Enter ID!!";
            }
            if (textBox2.Text.ToString() == "")
            {
                a++;
                label10.Text = "Enter Title!!";
            }
            if (textBox3.Text.ToString() == "")
            {
                a++;
                label11.Text = "Enter Content!!";
            }
            if (textBox4.Text.ToString() == "")
            {
                a++;
                label12.Text = "Enter Writer Name!!";
            }
            
            if (a == 0)
            {
                label9.Text = ""; label10.Text = ""; label11.Text = ""; label12.Text = "";
                UpdateBlogeAsync();
            }
            else
            {
                label8.Text = "Error occurred!!";
            }
        }

        private async Task UpdateBlogeAsync()
        {
            Blog e = new Blog();
           // Form1 form = new Form1();
            e.Id = Int32.Parse( textBox1.Text);
            e.title = textBox2.Text.ToString();
            e.content = textBox3.Text.ToString();
            e.writer_name = textBox4.Text.ToString();

            var serializedEmployee = JsonConvert.SerializeObject(e);
            var constex = new StringContent(serializedEmployee, Encoding.UTF8, "application/json");
            var result = await httpClient.PutAsync("https://localhost:44332/api/Blogs/"+Int32.Parse(textBox1.Text), constex);
            label8.Text = "Story/Poem Updated!!";
        }
    }
}
