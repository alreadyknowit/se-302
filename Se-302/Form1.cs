using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Se_302
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        Syllabus s = new Syllabus("http://dm.ieu.edu.tr/tr/syllabus/type/read/id/CE+223");
        private void openButton_Click(object sender, EventArgs e)
        {
            
            string path = @"c:\CE-223\CE-223.txt";
            if (!File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        tw.WriteLine("");
                    }
                }
                TextWriter txt = new StreamWriter(path);
                txt.WriteLine(s);
                txt.Close();
            }
            DataTable table = new DataTable();
            table.Columns.Add(" ", typeof(string));
            dataGridView1.DataSource = table;
            string[] lines = File.ReadAllLines(path);
            string[] values;


            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split('|');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                table.Rows.Add(row);
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.Name, column.ValueType);
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
                {
                    if (row.Cells[column.Name].Value != null)
                    {
                        dr[column.Name] = row.Cells[column.Name].Value.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            string filePath = @"C:\CE-223\CE-223.txt";
            DataTableToTextFile(dt, filePath);
        }
        private void DataTableToTextFile(DataTable dt, string outputFilePath)
        {
            int[] maxLengths = new int[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                maxLengths[i] = dt.Columns[i].ColumnName.Length;
                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;
                        if (length > maxLengths[i])
                        {
                            maxLengths[i] = length;
                        }
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outputFilePath, false))
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                }

                sw.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (!row.IsNull(i))
                        {
                            sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                        }
                        else
                        {
                            sw.Write(new string(' ', maxLengths[i] + 2));
                        }
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }

    }
}
