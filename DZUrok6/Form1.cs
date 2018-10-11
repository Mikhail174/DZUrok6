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

namespace DZUrok6
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=МИХАИЛ-ПК\MSSQLSERVER1;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Orders";
        DataTable orders = new DataTable();
        DataView view;

        public Form1()
        {
            InitializeComponent();

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.Fill(orders);

            view = new DataView(orders);

            dataGridView1.DataSource = orders;
            dataGridView2.DataSource = view;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.None;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            orders.AcceptChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.Unchanged;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.Added;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.Deleted;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.ModifiedCurrent;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.ModifiedOriginal;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.OriginalRows;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            view.RowStateFilter = DataViewRowState.CurrentRows;
        }

    }
}
