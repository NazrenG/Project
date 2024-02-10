using SchoolBus_Access.Repository.Concretes;
using SchoolBus_Model.Entities.Concretes;
using SchoolBus_WPF.Command;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class CreateStudentPageViewModel : NotificationServices
    {
        public BaseRepos<Student>? studentRepos;
        public BusRepos? busRepos;
        public ParentRepos? parentRepos;    

        private Student student;
        private List<string> busList;
        private List<string> parentList;
        private string parentName;
        private string busName;


        public ICommand CreateClass { get; set; }
        public ICommand ClosePage { get; set; }

        public Student Student
        {
            get => student;
            set { student = value; OnPropertyChanged(); }
        }
        public List<string> BusList { get => busList; set { busList = value; OnPropertyChanged(); } }
        public List<string> ParentList { get => parentList; set {parentList = value; OnPropertyChanged(); } }
        public string ParentName { get => parentName; set { parentName = value; OnPropertyChanged(); } }
        public string BusName { get => busName; set{ busName = value; OnPropertyChanged(); } }

        public CreateStudentPageViewModel()
        {

            CreateClass = new RelayCommand(CreateStudent, CanCreateStudent);
            ClosePage = new RelayCommand(ReturnBackPage, CanReturnBackPage);

            studentRepos = new BaseRepos<Student>();
            Student = new Student();
            busRepos = new BusRepos();
            parentRepos = new ParentRepos();

            BusList = busRepos.GetAllBusName();
            ParentList=parentRepos.GetAllFullname();
        }

        private bool CanReturnBackPage(object? obj) => true;

        private void ReturnBackPage(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.GoBack();
            }
        }

        private bool CanCreateStudent(object? obj)
        {
            return !string.IsNullOrEmpty(Student.Name);
        }

        private void CreateStudent(object? obj)
        {
            Student.BusId = busRepos!.FindId(BusName);
            Student.ParentId= busRepos!.FindId(ParentName);

            studentRepos!.Add(Student);
            MessageBox.Show("Students was added!");

            studentRepos.Save();

            if (obj is Page page)
            {
                page.NavigationService.Navigate(new StudentsPage());
            }
        }
    }

}
