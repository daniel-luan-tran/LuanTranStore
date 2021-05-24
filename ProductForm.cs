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
            public string PRODUCT { get; set; }
            public string ID { get; set; }
            public string COMPANY { get; set; }
            public string MFG { get; set; }
            public string EXP { get; set; }
            public string CATCB { get; set; }
        }
        public List<PersonState> listOfPersonState;

        public class PersonState2
        {
            public string CATEGORY2 { get; set; }
            public string CATID { get; set; }
        }
        public List<PersonState2> listOfPersonState2;

        public ProductForm()
        {
            InitializeComponent();
            listOfPersonState = new List<PersonState>();
            listOfPersonState2 = new List<PersonState2>();
        }

        //Hien thi Data trong DataGridView  
        private void DisplayData()
        {
            DataTable dt = new DataTable();
            dt = ConvertToDatatable();
            dataGridView1.DataSource = dt;
        }
        private void DisplayData2()
        {
            DataTable dt = new DataTable();
            dt = ConvertToDatatable2();
            dataGridView2.DataSource = dt;
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
            CatIDSearch.Text = "";
            ProdSearch.Text = "";
            CatId.Text = "";
        }

        private void ClearData2()
        {
            AddCat.Text = "";
            CatSearch2.Text = "";
            CatId.Text = "";
        }


        public DataTable ConvertToDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PRODUCT");
            dt.Columns.Add("PRODUCT ID");
            dt.Columns.Add("COMPANY");
            dt.Columns.Add("MFG");
            dt.Columns.Add("EXP");
            dt.Columns.Add("CATEGORY ID");
            foreach (var item in listOfPersonState)
            {
                var row = dt.NewRow();
                row["PRODUCT"] = item.PRODUCT;
                row["PRODUCT ID"] = item.ID;
                row["COMPANY"] = item.COMPANY;
                row["MFG"] = item.MFG;
                row["EXP"] = item.EXP;
                row["CATEGORY ID"] = item.CATCB;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable ConvertToDatatable2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CATEGORY");
            dt.Columns.Add("CATEGORY ID");
            foreach (var item in listOfPersonState2)
            {
                var row = dt.NewRow();
                row["CATEGORY"] = item.CATEGORY2;
                row["CATEGORY ID"] = item.CATID;
                dt.Rows.Add(row);
            }
            return dt;
        }


        //Add, Update, Delete List 1
        private void AddToList(string text1, string text2, string text3, string text4, string text5, string text6)
        {
            try
            {
                listOfPersonState.Add(new PersonState { ID = text1, PRODUCT = text2, COMPANY = text3, MFG = text4, EXP = text5, CATCB = text6 });
            }
            catch
            {
                MessageBox.Show("Please Select row with data!");
            }
        }
        private void UpdateToList( string text1, string text2, string text3, string text4, string text5, string text6)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                listOfPersonState[index] = new PersonState { ID = text1, PRODUCT = text2, COMPANY = text3, MFG = text4, EXP = text5, CATCB = text6 };
            }
            catch
            {
                MessageBox.Show("Please select row which has data!");
            }
        }
        private void DeleteToList()
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;
                listOfPersonState.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show("Please select row which has data!");
            }
        }

        //Add, Update, Delete List 2
        private void AddToList2(string text6, string text7)
        {
            try
            {
                listOfPersonState2.Add(new PersonState2 { CATID = text6, CATEGORY2 = text7 });
            }
            catch
            {
                MessageBox.Show("Please select row which has data!");
            }
        }
        //private void UpdateToList2(string text6, string text7)
        //{
        //    int index = dataGridView2.SelectedRows[0].Index;
        //    listOfPersonState2[index] = new PersonState2 { CATID = text6, CATEGORY2 = text7 };
        //}
        private void DeleteToList2()
        {
            try
            {
                int index = dataGridView2.SelectedRows[0].Index;
                listOfPersonState2.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show("Please select row which has data!");
            }
        }


        //Them product
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && Co.Text != "" && Mfg.Text != "" && Exp.Text != "" && CatCb.Text != "")
            {
                bool entryFound = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    object value1 = row.Cells[0].Value;
                    object value2 = row.Cells[1].Value;
                    if (value1 != null &&
                        value2 != null &&
                        value1.ToString() == Prodname.Text &&
                        value2.ToString() == Prodid.Text)
                    {
                        MessageBox.Show("Product and Product ID are already existed");
                        entryFound = true;
                        break;
                    }
                    if (value1 != null && 
                        value1.ToString() == Prodname.Text) 
                    {
                        MessageBox.Show("Product already existed");
                        entryFound = true;
                        break;
                    }
                    if (value2 != null &&
                        value2.ToString() == Prodid.Text)
                    {
                        MessageBox.Show("Product ID already existed");
                        entryFound = true;
                        break;
                    }
                }
                if (!entryFound)
                {
                    AddToList(Prodid.Text, Prodname.Text, Co.Text, Mfg.Text, Exp.Text, CatCb.Text);
                    //MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    ClearData();
                }
            }
            else
            {
                MessageBox.Show("Please Provide Details!");
            }
        }

        //Chinh sua product
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Prodid.Text != "" && CatCb.Text != "" && Prodname.Text != "" && Co.Text != "" && Mfg.Text != "" && Exp.Text != "")
                {
                    UpdateToList(Prodid.Text, Prodname.Text, Co.Text, Mfg.Text, Exp.Text, CatCb.Text);
                    //MessageBox.Show("Record Updated Successfully");
                    DisplayData();
                    ClearData();

                    //bool entryFound = false;
                    //foreach (DataGridViewRow row in dataGridView1.Rows)
                    //{
                    //    object value1 = row.Cells[0].Value;
                    //    object value2 = row.Cells[1].Value;
                    //    if (value1 != null &&
                    //        value2 != null &&
                    //        value1.ToString() == Prodname.Text &&
                    //        value2.ToString() == Prodid.Text)
                    //    {
                    //        MessageBox.Show("Product and Product ID are already existed");
                    //        entryFound = true;
                    //        break;
                    //    }
                    //    if (value1 != null &&
                    //        value1.ToString() == Prodname.Text)
                    //    {
                    //        MessageBox.Show("Product already existed");
                    //        entryFound = true;
                    //        break;
                    //    }
                    //    if (value2 != null &&
                    //        value2.ToString() == Prodid.Text)
                    //    {
                    //        MessageBox.Show("Product ID already existed");
                    //        entryFound = true;
                    //        break;
                    //    }
                    //}
                    //if (!entryFound)
                    //{
                    //}
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        //Xoa Product
        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DeleteToList();
                    //MessageBox.Show("Record Deleted Successfully!");
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please Provide Detail!");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        //Click chon dong data
        private void FillInputControls(int Index)
        {
            if (Index > -1)
            {
                Prodname.Text = dataGridView1.Rows[Index].Cells[0].Value.ToString();
                Prodid.Text = dataGridView1.Rows[Index].Cells[1].Value.ToString();
                Co.Text = dataGridView1.Rows[Index].Cells[2].Value.ToString();
                Mfg.Text = dataGridView1.Rows[Index].Cells[3].Value.ToString();
                Exp.Text = dataGridView1.Rows[Index].Cells[4].Value.ToString();
                CatCb.Text = dataGridView1.Rows[Index].Cells[5].Value.ToString();
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

        //Tim category ID
        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource dt = new BindingSource();
            dt.DataSource = dataGridView1.DataSource;

            dt.Filter = dataGridView1.Columns[5].HeaderText.ToString() + " LIKE '%" + CatIDSearch.Text + "%'";

            dataGridView1.DataSource = dt;
            ClearData();
        }

        //Tim product
        private void button2_Click(object sender, EventArgs e)
        {
            BindingSource dt = new BindingSource();
            dt.DataSource = dataGridView1.DataSource;

            dt.Filter = dataGridView1.Columns[0].HeaderText.ToString() + " LIKE '%" + ProdSearch.Text + "%'";

            dataGridView1.DataSource = dt;
            ClearData();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
        }

        //Them Category
        private void button6_Click(object sender, EventArgs e)
        {
            string namestr = CatId.Text;
            try
            {
                if (CatId.Text != "" && AddCat.Text != "")
                {
                    bool entryFound = false;
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        object value1 = row.Cells[0].Value;
                        object value2 = row.Cells[1].Value;
                        if (value1 != null &&
                            value2 != null &&
                            value1.ToString() == AddCat.Text &&
                            value2.ToString() == CatId.Text)
                        {
                            MessageBox.Show("Category and Category ID are already existed");
                            entryFound = true;
                            break;
                        }
                        if (value1 != null &&
                            value1.ToString() == AddCat.Text)
                        {
                            MessageBox.Show("Category already existed");
                            entryFound = true;
                            break;
                        }
                        if (value2 != null &&
                            value2.ToString() == CatId.Text)
                        {
                            MessageBox.Show("Category ID already existed");
                            entryFound = true;
                            break;
                        }
                    }
                    if (!entryFound)
                    {
                        CatCb.Items.Add(namestr);
                        AddToList2(CatId.Text, AddCat.Text);

                        DisplayData2();
                        ClearData2();
                    }
                }
                else
                {
                    MessageBox.Show("Please provide detail to add!");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        //Chinh sua Category 2
        //private void button10_Click(object sender, EventArgs e)
        //{
        //    string namestr = CatCb.Text;

        //    if (dataGridView2.SelectedRows != null && dataGridView2.SelectedRows.Count > 0)
        //    {
        //        UpdateToList2(CatId.Text, AddCat.Text);

        //        CatCb.Items.Remove(namestr);
        //        CatSearch.Items.Remove(namestr);


        //        DisplayData2();
        //        ClearData();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please provide detail to add!");
        //    }
        //}

        //Xoa Category 2
        private void button8_Click(object sender, EventArgs e)
        {
            string namestr = CatId.Text;
            try
            {
                if (dataGridView2.SelectedRows != null && dataGridView2.SelectedRows.Count > 0)
                {
                    DeleteToList2();
                    CatCb.Items.Remove(namestr);
                    DisplayData2();
                    ClearData2();
                }
                else
                {
                    MessageBox.Show("Please provide detail!");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearData();
            DisplayData();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel1.Show();
        }

        //Click chon dong data 2
        private void FillInputControls2(int Index2)
        {
            if (Index2 > -1)
            {
                AddCat.Text = dataGridView2.Rows[Index2].Cells[0].Value.ToString();
                CatId.Text = dataGridView2.Rows[Index2].Cells[1].Value.ToString();
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e2)
        {
            FillInputControls2(e2.RowIndex);
        }
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e2)
        {
            FillInputControls2(e2.RowIndex);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            BindingSource dt = new BindingSource();
            dt.DataSource = dataGridView2.DataSource;

            dt.Filter = dataGridView2.Columns[0].HeaderText.ToString() + " LIKE '%" + CatSearch2.Text + "%'";

            dataGridView2.DataSource = dt;
            ClearData2();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ClearData2();
            DisplayData2();
        }
    }
}