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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\UserDLT\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into CategoryTbl values(" + CatIdTb.Text + ",'" + CatNameTb.Text + "','" + CatDescTb.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category Added Successfully");
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private BindingSource bindingSource1 = new BindingSource();
        private void populate()
        {
            Con.Open();
            string query = "select * from CategoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIdTb.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
