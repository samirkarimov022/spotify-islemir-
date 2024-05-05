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
using System.Xml.Linq;

namespace spotify
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameVal = nameVal.Text;
            string surnameVal = surnameVal.Text;
            string genderVal = genderVal.Text.StartsWith("K") ? "Kişi" : "Qadın";
            string usernameVal = usernameVal.Text;
            string passwordVal = Sql.HashPassword(passwordVal.Text);


            var result = Sql.Execute($"INSERT INTO Users VALUES (N'{nameVal}',N'{surnameVal}',N'{genderVal}','{usernameVal}','{passwordVal}')");
            if (result == 0)
            {
                MessageBox.Show("alinmadi");
            }
            else
            {
                MessageBox.Show("alindi :)");
            }
        }
    }
}
