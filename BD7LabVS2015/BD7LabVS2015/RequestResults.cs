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
    public partial class RequestResults : Form
    {
        public RequestResults(OleDbDataReader reader)
        {
            InitializeComponent();
            string temp ="";
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    temp += reader[i].ToString() + " || ";
                listBox1.Items.Add(temp);
                temp = "";
            }
        }
    }
}
