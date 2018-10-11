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

namespace DZUrok6Zad2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=МИХАИЛ-ПК\MSSQLSERVER1;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Customers";
        DataTable customers = new DataTable();
        DataView view1;
        DataView view2;


        public Form1()
        {
            InitializeComponent();

            SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.Fill(customers);

            view1 = new DataView(customers, "", "City", DataViewRowState.CurrentRows);
            DataRowView[] findingRows = view1.FindRows("Киев");
            dataGridView1.DataSource = findingRows.ToList();
            view2 = new DataView(customers, "", "City", DataViewRowState.CurrentRows);
            view2.RowFilter = "City LIKE 'Чернигов' OR City LIKE 'Харьков'"; 

              dataGridView2.DataSource = view2;
        }
    }
}
