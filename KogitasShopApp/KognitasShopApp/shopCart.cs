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
    public partial class shopCart : Form
    {
        string con = "user id=FFUKS;password=das8007kos;data source=" +
                         "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                         "(HOST=kogext04.kogitas.com)(PORT=1521))(CONNECT_DATA=" +
                         "(SERVICE_NAME=DEV01)))";
        List<ProductsCart> cart;
        int Result = 0;
        int userID = 0;
        public shopCart(int UID, List<ProductsCart> ShoppingCart)
        {
            this.ControlBox = false;
            InitializeComponent();
            cart = ShoppingCart;
            userID = UID;
            
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            DGVpopulate();
        }
        private void Calculate()
        {
            int Q = 0;
            int V = 0;
            Double grossP = 0;
            if (dataGridView1.Rows.Count >= 0)
            {
                for(int i =0; i < dataGridView1.Rows.Count; i++)
                {
                    V = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    Q = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    Result += (V * Q);
                }
                PriceLabel.Text = Result.ToString();
                grossP = (float)Result * 1.2;
                GPriceLabel.Text = grossP.ToString();
            }
        }

        private void OrderNow_Click(object sender, EventArgs e)
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select max(ORDER_ID) from order_products";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                dr.Read();
                int high = dr.GetInt32(0);
                high += 1;
                foreach (var item in cart)
                {
                    command.CommandText = "INSERT INTO order_products (Order_id, Product_id, quantity) VALUES ('"+high+"', '"+item.idProduct+ "', '"+item.quantity+"')";
                    command.ExecuteNonQuery();
                }
                command.CommandText = "Insert into user_orders (USER_ID, ORDER_ID) values ('"+userID+ "','"+high+"')";
                command.ExecuteNonQuery();
                objConn.Close();
                cart.Clear();
                MessageBox.Show("Order placed!", "Success", MessageBoxButtons.OK);
               
                DGVpopulate();
            }
        }
        private void DGVpopulate()
        {
            dataGridView1.DataSource = null;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Product ID", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Product Name", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Net value", typeof(int)));
            dataTable.Columns.Add(new DataColumn("Ammount", typeof(int)));
            foreach (var element in cart)
            {
                using (OracleConnection objConn = new OracleConnection(con))
                {
                    string first = "";
                    int second = 0;
                    objConn.Open();
                    OracleCommand command = new OracleCommand();
                    command.Connection = objConn;
                    command.CommandText = "select PRODUCT_NAME from product where PRODUCT_ID = '" + element.idProduct + "'";
                    command.CommandType = CommandType.Text;
                    OracleDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            first = dr.GetString(0);
                        }
                    }

                    command.CommandText = "select NET_VALUE from product where PRODUCT_ID = '" + element.idProduct + "'";
                    command.CommandType = CommandType.Text;
                    dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            second = dr.GetInt32(0);
                        }
                    }

                    if (dr.HasRows)
                    {
                        dataTable.Rows.Add(element.idProduct ,first, second, element.quantity);
                    }
                    objConn.Close();
                }
                dataGridView1.DataSource = dataTable;
            }
            Calculate();
        }

        private void RemoveOrder_Click(object sender, EventArgs e)
        {
            int selected = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            int ammount = int.Parse(dataGridView1.Rows[0].Cells[3].Value.ToString());
            int available = 0;
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select STOCK_AVAILABILITY from product where PRODUCT_ID = '" + selected + "'";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        available = dr.GetInt32(0);
                    }
                }
                command.CommandText = "Update PRODUCT Set STOCK_AVAILABILITY = '" + (available + ammount) + "' where PRODUCT_ID = '" + selected + "'";
                command.ExecuteNonQuery();
                objConn.Close();


            }
            for (int i = 0; i < cart.Count; i++)
            {
                if (selected == cart[i].idProduct)
                {
                    cart.RemoveAt(i);
                }
            }
            DGVpopulate();
        }
    }
}
