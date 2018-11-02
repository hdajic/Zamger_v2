using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Zadaca2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void help_linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("ooo");
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void log_in_button_Click(object sender, EventArgs e)
        {
            SqlConnection sq = new SqlConnection(@"C:\Users\haris\Desktop\Zadaca2\")
            this.Hide();
            Zamger forma = new Zamger();
            forma.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
