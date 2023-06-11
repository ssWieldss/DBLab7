using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD7LabVS2015
{
    public partial class ChangeOrDeleteForm : Form
    {
        string tableName = "";
        OleDbConnection cn = null;
        int number = 0;
        string name_col = "";
        public ChangeOrDeleteForm(OleDbConnection cn, string tableName, int number, string name_col)
        {
            this.tableName = tableName;
            this.cn = cn;
            this.number = number;
            this.name_col = name_col;
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE " + tableName + " SET " + "[" + textBox2.Text + "]" + " = " + textBox1.Text + 
                    " WHERE " + "[" + name_col + "]" + " = " + number;
                OleDbCommand command = new OleDbCommand(query, cn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM " + tableName + " WHERE " + "[" + name_col + "]" + " = " + number;
                OleDbCommand command = new OleDbCommand(query, cn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
    }
}
