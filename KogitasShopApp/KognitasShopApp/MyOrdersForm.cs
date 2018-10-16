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
    public partial class MyOrdersForm : Form
    {
        string con = "user id=FFUKS;password=das8007kos;data source=" +
                         "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                         "(HOST=kogext04.kogitas.com)(PORT=1521))(CONNECT_DATA=" +
                         "(SERVICE_NAME=DEV01)))";

        int userID = 0;
        string username = "";
        public MyOrdersForm(int UID)
        {
            InitializeComponent();
            userID = UID;
            this.ControlBox = false;
        }

        private void MyOrdersForm_Load(object sender, EventArgs e)
        {
            IDlabel.Text = userID.ToString();
            getName();
            getOrders();
        }

        private void getName()
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select USERNAME from shop_user where USER_ID ='" + userID + "'";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                dr.Read();
                username = dr.GetString(0);
                usernameLabel.Text = username;
                dr.Close();
                objConn.Close();

            }
        }
        private void getOrders()
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select uo.ORDER_ID, p.PRODUCT_NAME, p.NET_VALUE, op.QUANTITY from user_orders uo join order_products op on uo.ORDER_ID = op.ORDER_ID join product p on p.PRODUCT_ID = op.PRODUCT_ID where uo.USER_ID = '" + userID + "'";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                var dataTable = new DataTable();
                if (dr.HasRows)
                {
                    dataTable.Load(dr);

                }
                dataGridView1.DataSource = dataTable;
                objConn.Close();
                dataGridView1.Columns[0].HeaderText = "Order ID";
                dataGridView1.Columns[1].HeaderText = "Product Name";
                dataGridView1.Columns[2].HeaderText = "Value";
                dataGridView1.Columns[3].HeaderText = "Quantity";
                calculate();
            }
        }
        private void calculate()
        {
            int Q = 0;
            int V = 0;
            Double grossP = 0;
            double Result = 0;
            if (dataGridView1.Rows.Count >= 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    V = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    Q = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    Result += (V * Q);
                }
                TPriceLabel.Text = Result.ToString();
                grossP = (float)Result * 1.2;
                GPriceLabel.Text = grossP.ToString();
            }
        }
    }
}
