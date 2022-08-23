using System;
using System.IO;
using System.Windows.Forms;

namespace _1UGpeFczbnfjs_R3WzddVfA7PuluNgDPx
{
    public partial class data : Form
    {
        public data()
        {
            InitializeComponent();
        }

        private void data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        void load()
        {
            string[] values;
            string[] lines = File.ReadAllLines("Книги.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('|');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                database.Rows.Add(row);
            }
        }

        void save()
        {
            TextWriter write = new StreamWriter("Книги.txt");
            for (int i = 0; i < database.Rows.Count - 1; i++) // rows
            {
                for (int j = 0; j < database.Columns.Count; j++) // columns
                {
                    if (j == database.Columns.Count - 1) // if last column
                    {
                        write.Write("\t" + database.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                        write.Write("\t" + database.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                write.WriteLine("");
            }
            write.Close();
        }

        private void data_Load(object sender, EventArgs e)
        {
            load();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            database.Rows.Add((database.RowCount - 1).ToString(), nme.Text,ag.Text,gen.Text,au.Text);
            nme.Text = "";
            ag.Text = "";
            gen.SelectedIndex = 0;
            au.Text = "";
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = database.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    database.Rows.RemoveAt(database.SelectedRows[0].Index);
                }
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
