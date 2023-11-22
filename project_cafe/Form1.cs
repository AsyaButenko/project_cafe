using project_cafe.Data;
using Newtonsoft.Json;

namespace project_cafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateCategories();

            using DataContext dc = new DataContext();
            var categories = dc.Categories.ToList();

            foreach (var category in categories)
            {
                comboBox2.Items.Add(category);
            }
        }

        public void UpdateCategories()
        {
            listView1.Items.Clear();
            using DataContext dc = new DataContext();
            var list = dc.Categories.ToList();
            foreach (var category in list)
            {
                listView1.Items.Add(category.Name);
            }

        }

        public void ShowGoods(int Id)
        {
            listView2.Items.Clear();
            using DataContext dc = new DataContext();
            var goods = dc.Goods.Where(i => i.CategoryId == Id).ToList();
            foreach (var good in goods)
            {
                listView2.Items.Add(good.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using DataContext dc = new DataContext();
            string NameCategory = textBox1.Text;
            Category c = new Category() { Name = NameCategory };
            dc.Categories.Add(c);
            dc.SaveChanges();

            UpdateCategories();
            textBox1.Clear();
            MessageBox.Show("Категория добавлена");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using DataContext dc = new DataContext();
            var ListGood = dc.Goods.Select(g => new { g.Id, g.Name, g.Description, g.Category }).ToList();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            string path = sfd.FileName;
            string json = JsonConvert.SerializeObject(ListGood, Formatting.Indented);

            using StreamWriter sw = new StreamWriter(path);
            sw.Write(json);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Good g = new Good();
            g.Name = textBox2.Text;
            g.Description = textBox3.Text;
            g.Quantity = int.Parse(textBox4.Text);
            g.Price = int.Parse(textBox5.Text);
            g.Measure = comboBox1.Text;
            g.Category = comboBox2.SelectedItem as Category;

            using DataContext dc = new DataContext();
            dc.Attach(g.Category);
            dc.Add(g);
            dc.SaveChanges();

            ShowGoods(g.CategoryId);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            MessageBox.Show("Товар добавлен");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in listView1.SelectedItems)
            {
                var temp = item as ListViewItem;
                var text = temp.Text;
                using DataContext dc = new DataContext();
                var category = dc.Categories.First(i => i.Name == text);
                ShowGoods(category.Id);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
