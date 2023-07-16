using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesktopUI.Models;
using DesktopUI.Views;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DesktopUI.ViewModels
{

    public partial class MainWindowViewModele:ObservableObject
    {

        [ObservableProperty]
        public ObservableCollection<Student> studentsList;

        [ObservableProperty]
        public Student? selectStudent = null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }


        [RelayCommand]
        public void AddStudent()
        {
            var addstudentvm = new AddStudentViewModele
            {
                title = "ADD STUDENT"
            };
            AddStudentView window = new AddStudentView(addstudentvm);
            window.ShowDialog();
            if (addstudentvm.currentStudent != null)
            {
                studentsList.Add(addstudentvm.currentStudent);

            }
            else
                return;
            
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectStudent != null)
            {
                string name = selectStudent.FirstName;
                studentsList.Remove(selectStudent);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");
            }
        }

        [RelayCommand]
        public void EditStudent()
        {
            if (SelectStudent != null)
            {
                var vm = new AddStudentViewModele(selectStudent);
                vm.title = "EDIT USER";
                var window = new AddStudentView(vm);

                window.ShowDialog();

                int index = studentsList.IndexOf(selectStudent);
                studentsList.RemoveAt(index);
                studentsList.Insert(index, vm.currentStudent);

            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }

        public MainWindowViewModele()
        {
            studentsList = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Models/Images/1.png", UriKind.Relative));
            StudentsList.Add(new Student("Jone", "Black",3.5,"12/02/2000", image1));
            BitmapImage image2 = new BitmapImage(new Uri("/Models/Images/2.png", UriKind.Relative));
            StudentsList.Add(new Student("Jery", "Brow", 3.0, "02/03/2000", image2));
            BitmapImage image3 = new BitmapImage(new Uri("/Models/Images/3.png", UriKind.Relative));
            StudentsList.Add(new Student("Tom", "Green", 2.8, "10/06/2000", image3));
        }

    }
}
