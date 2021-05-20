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
        public class PersonState
        {
            public string ID { get; set; }
            public string NAME { get; set; }
            public string DESCRIPTION { get; set; }
        }
        public List<PersonState> listOfPersonState;
        public CategoryForm()
        {
            InitializeComponent();
            listOfPersonState = new List<PersonState>();
        }

        //Hien thi Data trong DataGridView  
        private void DisplayData()
        {
            DataTable dt = new DataTable();
            dt = ConvertToDatatable();
            dataGridView1.DataSource = dt;
        }

        //Clear Data  
        private void ClearData()
        {
            CatIdTb.Text = "";
            CatNameTb.Text = "";
            CatDescTb.Text = "";
        }
        public DataTable ConvertToDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");
            dt.Columns.Add("DESCRIPTION");
            foreach (var item in listOfPersonState)
            {
                var row = dt.NewRow();
                row["ID"] = item.ID;
                row["NAME"] = item.NAME;
                row["DESCRIPTION"] = item.DESCRIPTION;
                dt.Rows.Add(row);
            }
            return dt;
        }
        private void AddToList(string text1, string text2, string text3)
        {
            listOfPersonState.Add(new PersonState { ID = text1, NAME = text2, DESCRIPTION = text3 });
        }
        private void UpdateToList(string text1, string text2, string text3)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState[index] = new PersonState { ID = text1, NAME = text2, DESCRIPTION = text3 };
        }
        private void DeleteToList()
        {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState.RemoveAt(index);
        }

        //Them category
        private void button3_Click(object sender, EventArgs e)
        {
            if (CatIdTb.Text != "" && CatNameTb.Text != "" && CatDescTb.Text != "")
            {
                AddToList(CatIdTb.Text, CatNameTb.Text, CatDescTb.Text);
                //MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        //Chinh sua category
        private void button4_Click(object sender, EventArgs e)
        {
            if (CatIdTb.Text != "" && CatNameTb.Text != "" && CatDescTb.Text != "")
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    UpdateToList(CatIdTb.Text, CatNameTb.Text, CatDescTb.Text);
                    //MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        //Xoa category
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
            {
                DeleteToList();
                //MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillInputControls(e.RowIndex);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FillInputControls(e.RowIndex);
        }
        private void FillInputControls(int Index)
        {
            if (Index > -1)
            {
                CatIdTb.Text = dataGridView1.Rows[Index].Cells[0].Value.ToString();
                CatNameTb.Text = dataGridView1.Rows[Index].Cells[1].Value.ToString();
                CatDescTb.Text = dataGridView1.Rows[Index].Cells[2].Value.ToString();
            }
        }

        //Sellect product form
        private void button6_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }
    }
}
