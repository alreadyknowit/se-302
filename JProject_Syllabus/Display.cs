using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JProject_Syllabus
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        public void showMeWhatYouGot(Uri uri)
        {
            webBrowser1.Navigate(uri);
        }
    }
}
