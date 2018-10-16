using Oracle.ManagedDataAccess.Client;
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

namespace KognitasShopApp
{
    public partial class Form1 : Form
    {
        string con = "user id=FFUKS;password=das8007kos;data source=" +
                         "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                         "(HOST=kogext04.kogitas.com)(PORT=1521))(CONNECT_DATA=" +
                         "(SERVICE_NAME=DEV01)))";

        string username = "";
        int userID = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void find()
        {
            using (OracleConnection objConn = new OracleConnection(con))
            {
                objConn.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = objConn;
                command.CommandText = "select USER_ID from shop_user where USERNAME like '" + username + "'";
                command.CommandType = CommandType.Text;
                OracleDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        userID = dr.GetInt32(0);
                    }
                }
                else
                {
                    MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                objConn.Close();

            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginStart();
        }

        private void LogIntoApp()
        {
            if (userID != 0)
            {
                var MainThing = new MdiParentForm(userID);
                MainThing.Show();
                this.Hide();
            }
        }
        private void loginStart()
        {
            username = userTextBox.Text;
            find();
            LogIntoApp();
        }

        private void userTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginStart();
            }
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
