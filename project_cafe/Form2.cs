using project_cafe.Data;
using Newtonsoft.Json;

namespace project_cafe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            UpdateMonths();

            using DataContext dc = new DataContext();
            var monthlyactions = dc.MonthlyActions.ToList();

            foreach (var monthlyaction in monthlyactions)
            {
                comboBox1.Items.Add(monthlyaction);
            }
        }

        public void UpdateMonths()
        {
            listView1.Items.Clear();
            using DataContext dc = new DataContext();
            var list = dc.MonthlyActions.ToList();
            foreach (var monthlyaction in list)
            {
                listView1.Items.Add(monthlyaction.Month);
            }

        }

        public void ShowActions(int Id)
        {
            listView2.Items.Clear();
            using DataContext dc = new DataContext();
            var actions = dc.Actions.Where(i => i.MonthlyActionId == Id).ToList();
            foreach (var action in actions)
            {
                listView2.Items.Add(action.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using DataContext dc = new DataContext();
            string MonthMonthlyAction = textBox1.Text;
            MonthlyAction ma = new MonthlyAction() { Month = MonthMonthlyAction };
            dc.MonthlyActions.Add(ma);
            dc.SaveChanges();

            UpdateMonths();
            textBox1.Clear();
            MessageBox.Show("Месяц добавлен");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using DataContext dc = new DataContext();
            var ListAction = dc.Actions.Select(a => new { a.Id, a.Name, a.Description, a.Period }).ToList();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();

            string path = sfd.FileName;
            string json = JsonConvert.SerializeObject(ListAction, Formatting.Indented);

            using StreamWriter sw = new StreamWriter(path);
            sw.Write(json);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.Action a = new Data.Action();
            a.Name = textBox2.Text;
            a.Description = textBox3.Text;
            a.Period = textBox4.Text;
            a.MonthlyAction = comboBox1.SelectedItem as MonthlyAction;

            using DataContext dc = new DataContext();
            dc.Attach(a.MonthlyAction);
            dc.Add(a);
            dc.SaveChanges();

            ShowActions(a.MonthlyActionId);
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = " ";
            MessageBox.Show("Акция добавлена");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in listView1.SelectedItems)
            {
                var temp = item as ListViewItem;
                var text = temp.Text;
                using DataContext dc = new DataContext();
                var monthlyaction = dc.MonthlyActions.First(i => i.Month == text);
                ShowActions(monthlyaction.Id);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in listView2.SelectedItems)
            {
                var temp = item as ListViewItem;
                var text = temp.Text;
                using DataContext dc = new DataContext();
                var action = dc.Actions.First(i => i.Name + " | "  + i.Period == text);
                Form4 form4 = new Form4(action.Id);
                form4.Show();

            }
        }
    }



}
