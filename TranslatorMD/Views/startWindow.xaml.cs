using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TranslatorMD.ViewModels;

namespace TranslatorMD.Views
{
    /// <summary>
    /// Логика взаимодействия для startWindow.xaml
    /// </summary>
    public partial class startWindow : Window
    {
        public startWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.appiKey=api.Text;
            startWindow startw = new startWindow();
            this.Close();
             
        }
    }
}
