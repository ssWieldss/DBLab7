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
    public partial class RequestForm : Form
    {
        OleDbConnection cn = null;
        public RequestForm(OleDbConnection cn)
        {
            this.cn = cn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT * FROM Водитель WHERE(((Водитель.Стаж) > " + textBox1.Text + "));";
                OleDbDataReader reader = cmd.ExecuteReader();
                RequestResults reqres = new RequestResults(reader);
                reqres.ShowDialog();
                cn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT * FROM Остановки WHERE(((Остановки.[Номер рейса]) = " + textBox2.Text + "));";
                OleDbDataReader reader = cmd.ExecuteReader();
                RequestResults reqres = new RequestResults(reader);
                reqres.ShowDialog();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT * FROM Автобус WHERE(Автобус.[Срок эскплуатации] > " + textBox3.Text + ");";
                OleDbDataReader reader = cmd.ExecuteReader();
                RequestResults reqres = new RequestResults(reader);
                reqres.ShowDialog();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT * FROM Водитель WHERE Водитель.[Имя] LIKE \"Егор\"";
                OleDbDataReader reader = cmd.ExecuteReader();
                RequestResults reqres = new RequestResults(reader);
                reqres.ShowDialog();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT Автовокзал.Телефон FROM Автовокзал WHERE Автовокзал.[Город] LIKE \"Тверь\"";
                OleDbDataReader reader = cmd.ExecuteReader();
                RequestResults reqres = new RequestResults(reader);
                reqres.ShowDialog();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                "SELECT Остановки.[Номер рейса] FROM Остановки WHERE Остановки.[Название остановки] LIKE \"Смердящая\"";
                OleDbDataReader reader = cmd.ExecuteReader();
                RequestResults reqres = new RequestResults(reader);
                reqres.ShowDialog();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cn.Close();
            }
        }
    }
}
