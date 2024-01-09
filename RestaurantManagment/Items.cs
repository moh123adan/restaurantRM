using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagment
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();
            GetCategories();
        }
        Functions Con;

        private void ShowItems()
        {
            try
            {
                string Query = "select * from itemTable";
                itemList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void GetCategories()
        {
            string Query = "select * from category";
            CatCb.ValueMember = Con.GetData(Query).Columns["categoryCode"].ToString();
            CatCb.DisplayMember = Con.GetData(Query).Columns["categoryName"].ToString();
            CatCb.DataSource = Con.GetData(Query);

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || priceTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    int Category = Convert.ToInt32(CatCb.SelectedValue.ToString());
                    int Price = Convert.ToInt32(priceTb.Text);
                    string Query = "insert into itemTable values('{0}',{1},{2})";
                    Query = string.Format(Query, Name, Category, Price);
                    Con.SetData(Query);

                    ShowItems();
                    MessageBox.Show("Item Added!!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


    }

    private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void itemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(itemList.RowCount != 0)
            {
                NameTb.Text = itemList.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("Add Items please");
            }
        }
    }
}
