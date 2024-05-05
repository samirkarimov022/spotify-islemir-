using Microsoft.Win32;
using spotify.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace spotify
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = Sql.ExecuteQuery($"Username='{username.Text}' and Password='{SqlHelper.HashPassword(password.Text)}'");
            if (data.Rows.Count > 0)
            {
                MessageBox.Show("Xoş gəldiniz");
            }
            else
            {
                MessageBox.Show("İstifadəçi adı və ya parolu yalnışdır.");
            }
        }

        private void registerHref_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Show();
        }
    }
}
