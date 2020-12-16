using System;
using System.IO;
using System.Net;
using System.Text;

namespace SE_302_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // This part is just to see that this code is wworking or not
            Syllabus s = new Syllabus("http://dm.ieu.edu.tr/tr/syllabus/type/read/id/CE+223");
            s.writenode();
        }
    }
}
