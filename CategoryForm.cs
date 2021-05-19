using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuanTranStore
{
    public partial class CategoryForm : Form
    {
        DataTable dt = new DataTable();
        public CategoryForm()
        {
            InitializeComponent();
        }

        //Them nhom san pham
        public void createnewrow()
        {      
            if (dt.Rows.Count <= 0)
            {
                DataColumn dc1 = new DataColumn("ID", typeof(int));
                DataColumn dc2 = new DataColumn("NAME", typeof(string));
                DataColumn dc3 = new DataColumn("DESCRIPTION", typeof(string));
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Rows.Add(CatIdTb.Text, CatNameTb.Text, CatDescTb.Text);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dt.Rows.Add(CatIdTb.Text, CatNameTb.Text, CatDescTb.Text);
                dataGridView1.DataSource = dt;
            }
        }

        //Them nhom san pham
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Category Added Successfully");
                createnewrow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Chon nhom san pham de xoa sua
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //CatIdTb.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //CatNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            //CatDescTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        //Xoa nhom san pham
        public void deleterow()
        {
            CatIdTb.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            dt.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }

        //Xoa nhom san pham
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIdTb.Text == "")
                {
                    MessageBox.Show("Select the category to delete");
                }
                else
                {
                    MessageBox.Show("Category Deleted Successfully");
                    deleterow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
