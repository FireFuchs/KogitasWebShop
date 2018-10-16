using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KognitasShopApp
{
    public partial class Products : Form
    {
        string con = "user id=FFUKS;password=das8007kos;data source=" +
                         "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                         "(HOST=kogext04.kogitas.com)(PORT=1521))(CONNECT_DATA=" +
                         "(SERVICE_NAME=DEV01)))";
        int userID = 0;
        int available = 0;
        int ammount = 0;
        int prodID = 0;
        List<ProductsCart> cart;

        public Products(int UID, List<ProductsCart> shoppingCart)
        {
            InitializeComponent();
            userID = UID;
            this.ControlBox = false;
            cart = shoppingCart;
        }

        private void Products_Load(object sender, EventArgs e)
        {
            loadDGV();
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
            ammount = 1;
            ammount = int.Parse(quantity.Text);
            available = int.Parse(dataGridView1.SelectedRows[0].Cells["STOCK_AVAILABILITY"].Value.ToString());
            if (ammount > 0)
            {
                if (ammount <= available)
                {
                    ProductsCart temp = new ProductsCart();
                    temp.quantity = ammount;
                    prodID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    temp.idProduct = prodID;
                    int chng = 0;
                    foreach (ProductsCart item in cart)
                    {
                        if (item.idProduct == prodID)
                        {
                            item.quantity += ammount;
                            chng = 1;
                        }

                    }
                    if (chng == 0)
                    {
                        cart.Add(temp);
                    }

                    available -= ammount;
                    databaseChanges();
                    loadDGV();
                }
                else
                {
                    MessageBox.Show("There is not enough items available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ammount cant be lower than 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void databaseChanges()
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "Update PRODUCT Set STOCK_AVAILABILITY = '" + available  + "' where PRODUCT_ID = '"+ prodID +"'" ;
                command.ExecuteNonQuery();
                objConn.Close();

                
            }
        }
        private void loadDGV()
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select * from product";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                var dataTable = new DataTable();
                if (dr.HasRows)
                {
                    dataTable.Load(dr);
                }
                dataGridView1.DataSource = dataTable;
                objConn.Close();
                dataGridView1.Columns[0].HeaderText = "Product ID";
                dataGridView1.Columns[1].HeaderText = "Product Name";
                dataGridView1.Columns[2].HeaderText = "Value";
                dataGridView1.Columns[3].HeaderText = "Available";

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if(int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) == 0)
                    {
                        dataGridView1.Rows[i].Visible = false;
                    }
                }

            }
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
