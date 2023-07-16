using CommunityToolkit.Mvvm.ComponentModel;
using System;
using DesktopUI.Views;
using DesktopUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace DesktopUI.ViewModels
{
    public partial class AddStudentViewModele:ObservableObject
    {
        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string dateOfBirthday;

        [ObservableProperty]
        public BitmapImage selectedImage;

        [ObservableProperty]
        public string title;

        public Student currentStudent { get ; private set; }

        public Action CloseAction { get; internal set; }

        public AddStudentViewModele(Student s)
        {
           currentStudent = s;
           firstName=currentStudent.FirstName;
           lastName = currentStudent.LastName;
           gpa = currentStudent.GPA;
           dateOfBirthday = currentStudent.DateOfBirthday;
           selectedImage = currentStudent.Image;

        }

        public AddStudentViewModele()
        {

        }

        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }

        [RelayCommand]
        public void Save()
        {
            if(currentStudent == null)
            {
                currentStudent = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    GPA = gpa,
                    DateOfBirthday = dateOfBirthday,
                    Image = selectedImage
                };
            }

            else
            {
                currentStudent.FirstName = firstName;
                currentStudent.LastName = lastName;
                currentStudent. GPA = gpa;
                currentStudent.DateOfBirthday = dateOfBirthday;
                currentStudent.Image = selectedImage;
            }
            if (currentStudent.FirstName != null)
            {
                CloseAction();
            }
            Application.Current.MainWindow.Show();
        }
    }
}
