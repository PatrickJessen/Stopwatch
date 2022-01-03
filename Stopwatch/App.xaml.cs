using Stopwatch.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Stopwatch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Overrides startup and sets the datacontext to StopWatchViewModel wich will be the main page.
        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow = new MainWindow()
            {
                DataContext = new StopWatchViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
