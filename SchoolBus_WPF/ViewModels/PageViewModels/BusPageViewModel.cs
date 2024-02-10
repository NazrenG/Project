using SchoolBus_WPF.Command;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.Views.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class BusPageViewModel : NotificationServices
    {
        //button for switch pages
        public ICommand Class { get; set; }
        public ICommand Routes { get; set; }
        public ICommand Parent { get; set; }
        public ICommand Drivers { get; set; }
        public ICommand CreateRide { get; set; }
        public ICommand Student { get; set; }
        public ICommand LogOut { get; set; }


        public BusPageViewModel()
        {
            //pages
            Class = new RelayCommand(SwitchClassPage, CanSwitchPage);
            Routes = new RelayCommand(SwitchRoutesPage, CanSwitchPage);
            Parent = new RelayCommand(SwitchParentPage, CanSwitchPage);
            Drivers = new RelayCommand(SwitchDriversPage, CanSwitchPage);
            CreateRide = new RelayCommand(SwitchCreateRidePage, CanSwitchPage);
            Student = new RelayCommand(SwitchStudentPage, CanSwitchPage);
            LogOut = new RelayCommand(SwitchLogOutPage, CanSwitchPage);

        }
        //logout
        private void SwitchLogOutPage(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.Navigate(new LoginPage());
            }
        }

        //Switch Class
        private void SwitchClassPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var classPage = new ClassPage();
                classPage.DataContext = new ClassPageViewModel();
                page.NavigationService.Navigate(classPage);
            }
        }


        //Switch Parent
        private void SwitchParentPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var Parent = new ParentPage();
                Parent.DataContext = new ParentPageViewModel();
                page.NavigationService.Navigate(Parent);
            }
        }
        //Switch Routes
        private void SwitchRoutesPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var routes = new RoutesPage();
                routes.DataContext = new RoutesPageViewModel();
                page.NavigationService.Navigate(routes);
            }
        }

        //Switch CreateRide
        private void SwitchCreateRidePage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var CreateRide = new CreateRide();
                CreateRide.DataContext = new CreateRidePageViewModel();
                page.NavigationService.Navigate(CreateRide);
            }
        }

        //Switch Drivers
        private void SwitchDriversPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var Drivers = new DriversPage();
                Drivers.DataContext = new DriverPageViewModel();
                page.NavigationService.Navigate(Drivers);
            }
        }


        //Switch Student
        private void SwitchStudentPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var student = new StudentsPage();
                student.DataContext = new StudentPageViewModel();
                page.NavigationService.Navigate(student);
            }
        }

        private bool CanSwitchPage(object? obj) => true;
    }
}


