using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
// 下载于www.51aspx.com
namespace 通讯录
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData()
        {
            var list = new BLL.Contacts().GetAllList();
            dgv.DataSource = list;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
            this.Text = "通讯录Demo";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 fmForm2 = new Form2();
            //fmForm2.Owner = this;
            fmForm2.IsAdd = true;
            fmForm2.ShowDialog();
            if ( fmForm2.DialogResult == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var list = dgv.SelectedRows[0].DataBoundItem as Model.Contacts;
            Form2 fmForm2 = new Form2();
            fmForm2.UserName = list.UserName;
            fmForm2.Id = list.Id;
            fmForm2.Tel = list.Tel;
            fmForm2.Tel1 = list.Tel1;
            fmForm2.Address = list.Address;
           
            fmForm2.IsAdd = false;
            
            fmForm2.ShowDialog();

            if (fmForm2.DialogResult == DialogResult.OK)
            {
                LoadData();
            }

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            string str = txtSearch.Text;
            var slist = new BLL.Contacts().QueryList("where Tel like'%"+str+"%' or UserName like '%"+str+"%'");
            dgv.DataSource = slist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dgv.SelectedRows.Count>0)
            {
                var list = dgv.SelectedRows[0].DataBoundItem as Model.Contacts;
                if (new BLL.Contacts().Delete(list.Id) > 0)
                {
                    LoadData();
                }

            }

        }

    }
}
