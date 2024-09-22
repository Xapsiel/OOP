using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace _1._3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Загрузка первой страницы при запуске
            MainFrame.Navigate(new Page1(MainFrame));
        }
    }
}
