using Dapper;
using Dapper_HW1.DataBaseGenerator;
using Dapper_HW1.Enums;
using Dapper_HW1.Models;
using Dapper_HW1.User_Controls;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Z.Dapper.Plus;

namespace Dapper_HW1
{
    public partial class Form1 : Form
    {
        SqlConnection? connection = null;
        IConfigurationRoot? root = null;
        string command = String.Empty;
        DataTable? dataTable = null;

        public Form1()
        {
            InitializeComponent();

            var connectionString = "Data Source=DESKTOP-8V8B7U4\\MSSQLSERVER01;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Generator.CreateDataBase(connection);

            root = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            connection.ConnectionString = root.GetConnectionString("db1");

            FillData();
        }

        private void FillData()
        {
            command = "SELECT * FROM BOOK";
            var reader = connection.ExecuteReader(command);
            dataTable = new DataTable();
            dataTable.Load(reader);

            foreach (DataRow item in dataTable.Rows)
            {
                listBox1.Items.Add(item[0] + " " + item[1] + " " + item[2] + " " + item[3] + " " + item[4] + " " + item[5]);
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(listBox1.SelectedItem.ToString()[0].ToString());
            Book? b = new();
            foreach (DataRow item in dataTable.Rows)
            {
                if (item[0].ToString() == index.ToString())
                {

                    b.Name = item[1].ToString();
                    b.Page = Int32.Parse(item[2].ToString());
                    b.Author = item[3].ToString();
                    b.Price = Int32.Parse(item[4].ToString());
                    b.Stock = Int32.Parse(item[5].ToString());
                }
            }

            AddViewUC addView = new AddViewUC(connection,ActionMod.Update, b);
            this.Controls.Add(addView);
            addView.BringToFront();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddViewUC addView = new AddViewUC(connection, ActionMod.Add);
            this.Controls.Add(addView);
            addView.BringToFront();
        }
    }
}