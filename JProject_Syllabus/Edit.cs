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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var window = new Lesson_Intro();
            window.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var window = new WeeklySubjects();
            window.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var window = new EvaluationSystem();
            window.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var window = new ECTS();
            window.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var window = new CourseLearningOutcomes();
            window.Show();
        }
    }
}
