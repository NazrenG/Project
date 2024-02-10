using SchoolBus_WPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolBus_WPF
{
 
    public partial class App : Application
    {
        private void mainwindow(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
