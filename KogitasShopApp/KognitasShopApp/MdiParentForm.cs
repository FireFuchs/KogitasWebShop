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
    public partial class MdiParentForm : Form
    {
        string con = "user id=FFUKS;password=das8007kos;data source=" +
                         "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                         "(HOST=kogext04.kogitas.com)(PORT=1521))(CONNECT_DATA=" +
                         "(SERVICE_NAME=DEV01)))";

        public List<ProductsCart> shoppingCart = new List<ProductsCart>();
        int userID = 0;
        public MdiParentForm(int UID)
        {
            
            InitializeComponent();
            userID = UID;
            openProducts();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openProducts();
        }

        private void myOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openMyOrders();
        }

        private void openProducts()
        {
            var productForm = new Products(userID,shoppingCart);
            productForm.MdiParent = this;
            productForm.WindowState = FormWindowState.Maximized;
            productForm.Show();

        }

        private void openMyOrders()
        {
            var MyOrders = new MyOrdersForm(userID);
            MyOrders.MdiParent = this;
            MyOrders.WindowState = FormWindowState.Maximized;
            MyOrders.Show();
        }

        private void openForm2()
        {
            var form2 = new Form2();
            form2.MdiParent = this;
            form2.WindowState = FormWindowState.Maximized;
            form2.Show();
        }

        private void asdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm2();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int available = 0;
            using (OracleConnection objConn = new OracleConnection(con))
            {
                foreach (var item in shoppingCart)
                {
                    objConn.Open();
                    OracleCommand command = new OracleCommand();
                    command.Connection = objConn;
                    command.CommandText = "select STOCK_AVAILABILITY from product where PRODUCT_ID = '" + item.idProduct + "'";
                    command.CommandType = CommandType.Text;
                    OracleDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            available = dr.GetInt32(0);
                        }
                    }
                    command.CommandText = "Update PRODUCT Set STOCK_AVAILABILITY = '" + (available + item.quantity) + "' where PRODUCT_ID = '" + item.idProduct + "'";
                    command.ExecuteNonQuery();
                    objConn.Close();
                }
               
            }    
            Application.Exit();
        }

        private void shoppingCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openCart();
        }

        private void openCart()
        {
            shopCart cart = new shopCart(userID, shoppingCart);
            cart.MdiParent = this;
            cart.WindowState = FormWindowState.Maximized;
            cart.Show();
            
        }
    }
}
