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
            public string NAME { get; set; }
            public string QUANTITY { get; set; }
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
            ProdQty.Text = "";
            Mfg.Text = "";
            Exp.Text = "";
        }
        public DataTable ConvertToDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("CATEGORY");
            dt.Columns.Add("NAME");
            dt.Columns.Add("QUANTITY");
            dt.Columns.Add("MFG");
            dt.Columns.Add("EXP");
            foreach (var item in listOfPersonState)
            {
                var row = dt.NewRow();
                row["ID"] = item.ID;
                row["CATEGORY"] = item.CATEGORY;
                row["NAME"] = item.NAME;
                row["QUANTITY"] = item.QUANTITY;
                row["MFG"] = item.MFG;
                row["EXP"] = item.EXP;
                dt.Rows.Add(row);
            }
            return dt;
        }
        private void AddToList(string text1, string text6, string text2, string text3, string text4, string text5)
        {
            listOfPersonState.Add(new PersonState {  ID = text1, CATEGORY = text6, NAME = text2, QUANTITY = text3, MFG = text4, EXP = text5 });
        }
        private void UpdateToList( string text1, string text6, string text2, string text3, string text4, string text5)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState[index] = new PersonState {  ID = text1, CATEGORY = text6, NAME = text2, QUANTITY = text3, MFG = text4, EXP = text5 };
        }
        private void DeleteToList()
        {
            int index = dataGridView1.SelectedRows[0].Index;
            listOfPersonState.RemoveAt(index);
        }

        //Them product
        private void button3_Click_1(object sender, EventArgs e)
        {
            if ( Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && ProdQty.Text != "" && Mfg.Text != "" && Exp.Text != "")
            {
                AddToList( Prodid.Text, CatCb.Text, Prodname.Text, ProdQty.Text, Mfg.Text, Exp.Text);
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
            if (Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && ProdQty.Text != "" && Mfg.Text != "" && Exp.Text != "")
            {
                if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count > 0)
                {
                    UpdateToList(Prodid.Text, CatCb.Text, Prodname.Text, ProdQty.Text, Mfg.Text, Exp.Text);
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
                ProdQty.Text = dataGridView1.Rows[Index].Cells[3].Value.ToString();
                Mfg.Text = dataGridView1.Rows[Index].Cells[4].Value.ToString();
                Exp.Text = dataGridView1.Rows[Index].Cells[5].Value.ToString();
            }
        }

        //Sellect category form
        private void button6_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }
    }
}