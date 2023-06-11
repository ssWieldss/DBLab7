using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace BD7LabVS2015
{
    public partial class Main_menu : Form
    {
        OleDbConnection cn = new OleDbConnection(
             @"Provider=Microsoft.ACE.OLEDB.12.0;" +
             @"Data Source=""H:\Database11.accdb"""
        );
        public Main_menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTable tablePage = new ShowTable(cn, "Автовокзал");
            tablePage.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowTable tablePage = new ShowTable(cn, "Автобус");
            tablePage.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowTable tablePage = new ShowTable(cn, "Рейс");
            tablePage.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowTable tablePage = new ShowTable(cn, "Остановки");
            tablePage.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowTable tablePage = new ShowTable(cn, "Водитель");
            tablePage.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowTable tablePage = new ShowTable(cn, "Билет");
            tablePage.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RequestForm requestPage = new RequestForm(cn);
            requestPage.ShowDialog();
        }
    }
}
