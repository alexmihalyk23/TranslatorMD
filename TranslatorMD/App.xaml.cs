using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TranslatorMD.ViewModels;

namespace TranslatorMD
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(); // Создали ViewModel
            
        }
    }
}
