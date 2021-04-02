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
    public partial class AddBloge : Form
    {
        static HttpClient httpClient = new HttpClient();

        public partial class Blog
        {
            public int Id { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string writer_name { get; set; }
        }
        public AddBloge()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (textBox1.Text.ToString() == "")
            {
                a++;
                label5.Text = "Enter Title!!";
            }
            if (textBox2.Text.ToString() == "")
            {
                a++;
                label6.Text = "Enter Content!!";
            }
            
            if (a != 0)
            {
                label4.Text = "Error Occurred!!";

            }
            else
            {
                label5.Text = ""; label6.Text = ""; ;
                AddBlogeAsync();
            }
            
        }
        private async Task AddBlogeAsync()
        {
            Blog e = new Blog();
            Form1 form = new Form1();
            login login = new login();
            e.Id = Form1.id;
            e.title = textBox1.Text.ToString();
            e.content = textBox2.Text.ToString();
            e.writer_name = login.username;
           
            var serializedEmployee = JsonConvert.SerializeObject(e);
            var constex = new StringContent(serializedEmployee, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync("https://localhost:44332/api/Blogs", constex);
            label4.Text = "Story/Poem Added!!";

        }

        private void AddBloge_Load(object sender, EventArgs e)
        {
            label5.Text = ""; label6.Text = ""; ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
