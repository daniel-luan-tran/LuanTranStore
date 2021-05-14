using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LuanTranStore
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserDLT\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillcombo()
        {
            //This method will bind the Combobox with the Database
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(rdr);

            CatCb.ValueMember = "CatName";
            CatCb.DisplayMember = "CatName";
            CatCb.DataSource = dt;
            Con.Close();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            fillcombo();
            populate();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        //Data Grid View
        private void populate()
        {
            Con.Open();
            string query = "select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        //Add Product
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into ProductTbl values(" + Prodid.Text + " , '" + Prodname.Text + "' , '" + ProdQty.Text + "', '" + ProdPrice.Text + "', '" + CatCb.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Delete Product
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Prodid.Text == "")
                {
                    MessageBox.Show("Select the product to delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from ProductTbl where Prodid = " + Prodid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Edit Product
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Prodid.Text == "" || Prodname.Text == "" || ProdQty.Text == "" || ProdPrice.Text == "" || CatCb.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "update ProductTbl set Prodname= '" + Prodname.Text + "' , ProdQty = '" + ProdQty.Text + "', ProdPrice = '" + ProdPrice.Text + "', ProdCat = '" + CatCb.Text + "' where Prodid= " + Prodid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Successfully Updated");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Select Data
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Prodid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Prodname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ProdQty.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ProdPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            CatCb.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
