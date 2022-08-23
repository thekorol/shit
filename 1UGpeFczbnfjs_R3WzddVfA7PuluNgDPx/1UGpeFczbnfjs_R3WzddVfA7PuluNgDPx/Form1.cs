using System;
using System.Linq;
using System.Windows.Forms;

namespace _1UGpeFczbnfjs_R3WzddVfA7PuluNgDPx
{
    public partial class auth : Form
    {
        string[] usrs = new string[] { "admin", "test"};
        string[] psswrd = new string[] { "admn", "pass" };

        public auth()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            foreach (string x in usrs)
            {
                if (lgn.Text.Contains(x))
                {
                    int index = Array.IndexOf(usrs, x);
                    if (pwd.Text == psswrd[index].ToString())
                    {
                        this.Hide();
                        new data().ShowDialog();
                    }
                    else { MessageBox.Show("invalid password"); }
                }
            }
        }
    }
}
