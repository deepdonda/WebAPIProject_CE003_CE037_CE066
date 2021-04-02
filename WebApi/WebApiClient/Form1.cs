using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApiClient
{
    public partial class Form1 : Form
    {
        static HttpClient httpClient = new HttpClient();
        public static int a ;
        public static int id = a;
        
        public partial class Blog
        {
            public int Id { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string writer_name { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllEmployee();
        }

        private async void GetAllEmployee()
        {
            var responce = await httpClient.GetAsync("https://localhost:44332/api/Blogs");
            if (responce.IsSuccessStatusCode)
            {
                String data = await responce.Content.ReadAsStringAsync();
                id = JsonConvert.DeserializeObject<Blog[]>(data).ToList().Count;
                
                dataGridView1.DataSource = JsonConvert.DeserializeObject<Blog[]>(data).ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Blog' table. You can move, or remove it, as needed.
            this.blogTableAdapter.Fill(this.database1DataSet.Blog);
            // TODO: This line of code loads data into the 'database1DataSet.Employee' table. You can move, or remove it, as needed.
            //  this.BlogTable.Fill(this.database1DataSet.Employee);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id++;
            id=id;
            a = id;
            using (AddBloge f = new AddBloge())
            {

                f.ShowDialog();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetAllEmployee();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (DeletBlog f = new DeletBlog())
            {

                f.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (UpdateBlog f = new UpdateBlog())
            {

                f.ShowDialog();
            }
        }
    }
}
