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
    public partial class ProductForm : Form
    {
        public class PersonState
        {
            public string ID { get; set; }
            public string CATEGORY { get; set; }
            public string PRODUCT { get; set; }
            public string COMPANY { get; set; }
            public string MFG { get; set; }
            public string EXP { get; set; }
        }
        public List<PersonState> listOfPersonState;

        public ProductForm()
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
            Prodid.Text = "";
            CatCb.Text = "";
            Prodname.Text = "";
            Co.Text = "";
            Mfg.Text = "";
            Exp.Text = "";
        }

        public DataTable ConvertToDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("CATEGORY");
            dt.Columns.Add("PRODUCT");
            dt.Columns.Add("COMPANY");
            dt.Columns.Add("MFG");
            dt.Columns.Add("EXP");
            foreach (var item in listOfPersonState)
            {
                var row = dt.NewRow();
                row["ID"] = item.ID;
                row["CATEGORY"] = item.CATEGORY;
                row["PRODUCT"] = item.PRODUCT;
                row["COMPANY"] = item.COMPANY;
                row["MFG"] = item.MFG;
                row["EXP"] = item.EXP;
                dt.Rows.Add(row);
            }
            return dt;
        }
        private void AddToList(string text1, string text6, string text2, string text3, string text4, string text5)
        {
            listOfPersonState.Add(new PersonState {  ID = text1, CATEGORY = text6, PRODUCT = text2, COMPANY = text3, MFG = text4, EXP = text5 });
        }
        private void UpdateToList( string text1, string text6, string text2, string text3, string text4, string text5)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState[index] = new PersonState {  ID = text1, CATEGORY = text6, PRODUCT = text2, COMPANY = text3, MFG = text4, EXP = text5 };
        }
        private void DeleteToList()
        {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState.RemoveAt(index);
        }

        //Them product
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && Co.Text != "" && Exp.Text != "" && Exp.Text != "")
            {
                AddToList( Prodid.Text, CatCb.Text, Prodname.Text, Co.Text, Exp.Text, Exp.Text);
                //MessageBox.Show("Record Inserted Successfully");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Provide Details or type in 'MM/dd/yyyy' format for MFG and EXP!");
            }
        }

        //Chinh sua category
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && Co.Text != "" && Exp.Text != "" && Exp.Text != "")
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    UpdateToList(Prodid.Text, CatCb.Text, Prodname.Text, Co.Text, Exp.Text, Exp.Text);
                    //MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please Select Record to Update or type in 'MM/dd/yyyy' format for MFG and EXP!");
            }
        }

        //Xoa category
        private void button5_Click_1(object sender, EventArgs e)
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
                Prodid.Text = dataGridView1.Rows[Index].Cells[0].Value.ToString();
                CatCb.Text = dataGridView1.Rows[Index].Cells[1].Value.ToString();
                Prodname.Text = dataGridView1.Rows[Index].Cells[2].Value.ToString();
                Co.Text = dataGridView1.Rows[Index].Cells[3].Value.ToString();
                Exp.Text = dataGridView1.Rows[Index].Cells[4].Value.ToString();
                Exp.Text = dataGridView1.Rows[Index].Cells[5].Value.ToString();
            }
        }

        //Tim category
        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            bs.Filter = dataGridView1.Columns[1].HeaderText.ToString() + " LIKE '%" + CatSearch.Text + "%'";

            dataGridView1.DataSource = bs;
        }

        //Tim product
        private void button2_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            bs.Filter = dataGridView1.Columns[2].HeaderText.ToString() + " LIKE '%" + ProdSearch.Text + "%'";

            dataGridView1.DataSource = bs;
        }

        //Chuyen sang Category form
        private void button6_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CategoryForm prod = new CategoryForm();
            Hide();
            prod.ShowDialog();
            Show();
        }
    }
}