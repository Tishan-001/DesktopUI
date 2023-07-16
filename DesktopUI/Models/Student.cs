using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesktopUI.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double GPA { get; set; }
        public string DateOfBirthday { get; set; }
        public BitmapImage Image { get; set; }

        public Student(string firstName, string lastName, double gPA, string dateOfBirthday, BitmapImage image)
        {

            FirstName = firstName;
            LastName = lastName;
            GPA = gPA;
            DateOfBirthday = dateOfBirthday;
            Image = image;
        }

        public Student()
        {

        }
    }
}
