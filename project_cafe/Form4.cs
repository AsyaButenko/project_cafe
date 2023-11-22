using project_cafe.Data;
using System.Data;


namespace project_cafe
{
    public partial class Form4 : Form
    {
        public Form4(int Id)
        {
            InitializeComponent();

            Form2 form2 = new Form2();
            this.Location = new System.Drawing.Point(form2.Location.X + 1410, form2.Location.Y + 320);
           
                
            using DataContext dc = new DataContext();
            var actions = dc.Actions.Where(i => i.Id == Id);
            var action = dc.Actions.First(i => i.Id == Id);
            textBox1.Text = action.Description;
        }
    }
}
