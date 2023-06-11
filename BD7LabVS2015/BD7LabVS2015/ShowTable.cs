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
    public partial class ShowTable : Form
    {
        string tableName = "";
        OleDbConnection cn = null;

        public ShowTable(OleDbConnection cn, string tableName)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.cn = cn;
            cn.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText =
            "SELECT * FROM " + tableName;

            OleDbDataReader reader = cmd.ExecuteReader();

            // очищаем listBox1
            listBox1.Items.Clear();
            string temp = "";
            var cmd2 = new OleDbCommand("select * from " + tableName, cn);
            var reader2 = cmd2.ExecuteReader(CommandBehavior.SchemaOnly);

                var table = reader2.GetSchemaTable();
                foreach (DataRow row in table.Rows)
                {
                    temp += (string)row["ColumnName"] + " || ";
                }

            listBox1.Items.Add(temp);
            temp = "";
            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    temp += reader[i].ToString() + " || ";
                listBox1.Items.Add(temp);
                temp = "";
            }
            this.listBox1.ColumnWidth = 200;
            // закрываем OleDbDataReader
            reader.Close();
            cn.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                cn.Open();
                string temp = "";
                var cmd2 = new OleDbCommand("select * from " + tableName, cn);
                var reader2 = cmd2.ExecuteReader(CommandBehavior.SchemaOnly);

                var table = reader2.GetSchemaTable();
                temp = table.Rows[0][0].ToString();
                ChangeOrDeleteForm changeForm = new ChangeOrDeleteForm(cn, tableName, listBox1.SelectedIndex, temp);
                changeForm.ShowDialog();
                reloadList();
                cn.Close();
            }
        }
        private void reloadList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cn;
            cmd.CommandText =
            "SELECT * FROM " + tableName;

            OleDbDataReader reader = cmd.ExecuteReader();

            listBox1.Items.Clear();
            string temp = "";
            string[] columns = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null)
                                        .AsEnumerable()
                                        .Where(r => r.Field<string>("TABLE_NAME") == tableName)
                                        .Select(r => r.Field<string>("COLUMN_NAME"))
                                        .ToArray();

            for (int i = columns.Length - 1; i >= 0; i--)
                temp += columns[i].ToString() + " || ";
            listBox1.Items.Add(temp);
            temp = "";
            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    temp += reader[i].ToString() + " || ";
                listBox1.Items.Add(temp);
                temp = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            string[] data_arr = data.Split(',');
            data = "";

            for (int i = 0; i < data_arr.Length; i++)
                data += "'" + data_arr[i] + "'" + ",";
            data = data.Remove(data.Length - 1);
            cn.Open();
            try
            {
                string query = "INSERT INTO " + tableName + " VALUES (" + data + ")" ;
                OleDbCommand command = new OleDbCommand(query, cn);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            reloadList();
            cn.Close();
        }

    }
}
