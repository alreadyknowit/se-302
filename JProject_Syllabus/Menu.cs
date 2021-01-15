using HtmlAgilityPack;
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
namespace JProject_Syllabus
{
    public partial class Menu : Form
    {
        Syllabus currentSyllabus;

        public Menu()
        {
            InitializeComponent();
        }

        private void OpenUrl_Click(object sender, EventArgs e)
        {
            currentSyllabus = new Syllabus(UrlBox.Text);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string path = @"d:\BELGELER\MyTest1.html";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                        Console.WriteLine(currentSyllabus.doc.Text);
                        sw.WriteLine(currentSyllabus.doc.Text);  

                }
            }
            else
            {

                File.Delete(path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    Console.WriteLine(currentSyllabus.doc.Text);
                    sw.WriteLine(currentSyllabus.doc.Text);

                }

            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "HTML|*.html" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    UrlBox.Text = ofd.FileName;
                    var doc = new HtmlAgilityPack.HtmlDocument();

                    doc.LoadHtml(ofd.FileName);
                    currentSyllabus = new Syllabus(doc);
                }
            }

        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "HTML|*.html" })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
        
                        UrlBox.Text = ofd.FileName;
                        var m = new Display();
                        Uri uri = new Uri(ofd.FileName);
                        m.showMeWhatYouGot(uri);
                        m.Show();
                  
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var m = new Edit();
            m.Show();
            
        }
    }
}
