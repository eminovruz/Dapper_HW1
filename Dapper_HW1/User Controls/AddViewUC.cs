using Dapper;
using Dapper_HW1.Enums;
using Dapper_HW1.Models;
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

namespace Dapper_HW1.User_Controls
{
    public partial class AddViewUC : UserControl
    {
        public Book? Book { get; set; }
        SqlConnection? connection = null;


        public AddViewUC(SqlConnection? connection, ActionMod mod, Book b = null)
        {
            InitializeComponent();
            if(mod == ActionMod.Update)
            {
                button1.Text = "Edit";
                label1.Text = "EDIT ELEMENT";

                textBox1.Text = b.Name;
                textBox2.Text = b.Page.ToString();
                textBox3.Text = b.Author.ToString();
                textBox4.Text = b.Price.ToString();
                textBox5.Text = b.Stock.ToString();
            }

            Book = b;
            this.connection = connection;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var command = @"
            INSERT INTO BOOK VALUES(@Name, @Page, @Author, @Price, @Stock)
";
            Book.Name = textBox1.Text;
            Book.Page = Int32.Parse(textBox2.Text);
            Book.Author = textBox3.Text;
            Book.Price = Int32.Parse(textBox4.Text);
            Book.Stock = Int32.Parse(textBox5.Text);

            if (button1.Text == "Add")
            {
                connection.Execute(command, new { Book.Name, Book.Page, Book.Author, Book.Price, Book.Stock });
            }
        }
    }
}
