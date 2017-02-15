using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 通讯录
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public bool IsAdd { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Tel { get; set; }
        public string Tel1 { get; set; }
        public string Address { get; set; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                Model.Contacts model = new Model.Contacts();
                model.UserName = textBox1.Text;
                model.Tel = textBox2.Text;
                model.Tel1 = textBox3.Text;
                model.Address = textBox4.Text;
                //添加
                if (new BLL.Contacts().Insert(model) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
            else
            {
                Model.Contacts model = new Model.Contacts();
                model.Id = Id;
                model.UserName = textBox1.Text;
                model.Tel = textBox2.Text;
                model.Tel1 = textBox3.Text;
                model.Address = textBox4.Text;
                //删除
                if (new BLL.Contacts().Update(model) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }

            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = UserName;
            textBox2.Text = Tel;
            textBox3.Text = Tel1;
            textBox4.Text = Address;

        }
    }
}
