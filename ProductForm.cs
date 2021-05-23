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
            AddCat.Text = "";
            CatSearch.Text = "";
            ProdSearch.Text = "";
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
            listOfPersonState.Add(new PersonState {  ID = text1, CATEGORY = text6, PRODUCT = text2, COMPANY = text3, MFG = text4, EXP = text5});
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
            if (Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && Co.Text != "" && Mfg.Text != "" && Exp.Text != "")
            {
                AddToList( Prodid.Text, CatCb.Text, Prodname.Text, Co.Text, Mfg.Text, Exp.Text);
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
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && Co.Text != "" && Mfg.Text != "" && Exp.Text != "")
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    UpdateToList(Prodid.Text, CatCb.Text, Prodname.Text, Co.Text, Mfg.Text, Exp.Text);
                    //MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please Select Record to Update!");
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
                Mfg.Text = dataGridView1.Rows[Index].Cells[4].Value.ToString();
                Exp.Text = dataGridView1.Rows[Index].Cells[5].Value.ToString();
            }
        }

        //Tim category
        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource dt = new BindingSource();
            dt.DataSource = dataGridView1.DataSource;

            dt.Filter = dataGridView1.Columns[1].HeaderText.ToString() + " LIKE '%" + CatSearch.Text + "%'";

            dataGridView1.DataSource = dt;
            ClearData();
        }

        //Tim product
        private void button2_Click(object sender, EventArgs e)
        {
            BindingSource dt = new BindingSource();
            dt.DataSource = dataGridView1.DataSource;

            dt.Filter = dataGridView1.Columns[2].HeaderText.ToString() + " LIKE '%" + ProdSearch.Text + "%'";

            dataGridView1.DataSource = dt;
            ClearData();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string namestr = AddCat.Text;
            if (AddCat.Text != "")
            {
                CatCb.Items.Add(namestr);
                CatSearch.Items.Add(namestr);
                ClearData();
            }
            else
            {
                MessageBox.Show("Please provide category to add!");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string namestr = CatCb.Text;
            if (CatCb.Text != "")
            {
                CatCb.Items.Remove(namestr);
                ClearData();
            }
            else
            {
                MessageBox.Show("Please provide category to remove!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

    }
}