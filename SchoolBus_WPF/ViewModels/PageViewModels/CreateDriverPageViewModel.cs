using SchoolBus_Access.Repository.Concretes;
using SchoolBus_Model.Entities.Concretes;
using SchoolBus_WPF.Command;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class CreateDriverPageViewModel : NotificationServices
    {
        public DriverRepos? driverRepos;
        public BusRepos? busRepos;

        private Driver Driver1;
        private bool licence;
        private List<string> buslist;
        private string BusName1;

        public ICommand CreateDrivePage { get; set; }
        public ICommand ClosePage { get; set; }

        public bool SelectLicence
        {
            get => licence;
            set { licence = value; OnPropertyChanged(); }
        }

        public Driver Driver
        {
            get => Driver1;
            set { Driver1 = value; OnPropertyChanged(); }
        }

        public List<string> BusList
        {
            get => buslist;
            set { buslist = value; OnPropertyChanged(); }
        }

        public string BusName
        {
            get => BusName1;
            set { BusName1 = value; OnPropertyChanged(); }
        }

        public CreateDriverPageViewModel()
        {
            driverRepos = new DriverRepos();
            busRepos = new BusRepos();
            BusList = busRepos.GetAllBusName();
            CreateDrivePage = new RelayCommand(CreateDrive, CanCreateDrive);
            ClosePage = new RelayCommand(ReturnBackPage, CanReturnBackPage);


            Driver = new Driver();
            SelectLicence = false;
        }

        private bool CanReturnBackPage(object? obj) => true;

        private void ReturnBackPage(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.GoBack();
            }
        }

        private bool CanCreateDrive(object? obj)
        {
            return !string.IsNullOrEmpty(Driver.Username) && !string.IsNullOrEmpty(Driver.Name) &&
                   !string.IsNullOrEmpty(Driver.LastName) && !string.IsNullOrEmpty(Driver.Password);
        }

        private void CreateDrive(object? obj)
        {

            Driver.Licence = SelectLicence;

            Driver.BusId = busRepos!.FindId(BusName);

            driverRepos!.Add(Driver);
            MessageBox.Show("Driver was added!");

            driverRepos.Save();

            if (obj is Page page)
            {
                page.NavigationService.Navigate(new DriversPage());
            }
        }
    }

}
