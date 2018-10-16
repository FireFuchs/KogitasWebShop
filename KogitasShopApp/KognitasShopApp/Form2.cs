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
    

    public partial class Form2 : Form
    {
        string con = "user id=FFUKS;password=das8007kos;data source=" +
                         "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                         "(HOST=kogext04.kogitas.com)(PORT=1521))(CONNECT_DATA=" +
                         "(SERVICE_NAME=DEV01)))";
        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            openShopUsers();
        }

        private void ShopUsers_Click(object sender, EventArgs e)
        {
            openShopUsers();
        }

        private void Product_Click(object sender, EventArgs e)
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

            }
        }

        private void user_orders_Click(object sender, EventArgs e)
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select * from user_orders";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                var dataTable = new DataTable();
                if (dr.HasRows)
                {
                    dataTable.Load(dr);
                }
                dataGridView1.DataSource = dataTable;
                objConn.Close();

            }
        }

        private void order_products_Click(object sender, EventArgs e)
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select * from order_products";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                var dataTable = new DataTable();
                if (dr.HasRows)
                {
                    dataTable.Load(dr);
                }
                dataGridView1.DataSource = dataTable;
                objConn.Close();

            }
        }

        private void openShopUsers()
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select * from shop_user";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                var dataTable = new DataTable();
                if (dr.HasRows)
                {
                    dataTable.Load(dr);
                }
                dataGridView1.DataSource = dataTable;
                objConn.Close();

            }
        }
    }
}
