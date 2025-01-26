using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SoftwareEngineering
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static SharedViewModel SharedViewModel { get; } = new SharedViewModel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Setze initialen Status
            SharedViewModel.IsLoggedIn = false;
        }
    }
}
