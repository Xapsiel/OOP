using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace _1._3
{
    public partial class Page1 : Page
    {
        private Frame _mainFrame;

        public Page1(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
         
        static Dictionary<int, char> hexDigits = new Dictionary<int, char>
            {
                { 0, '0' },
                { 1, '1' },
                { 2, '2' },
                { 3, '3' },
                { 4, '4' },
                { 5, '5' },
                { 6, '6' },
                { 7, '7' },
                { 8, '8' },
                { 9, '9' },
                { 10, 'A' },
                { 11, 'B' },
                { 12, 'C' },
                { 13, 'D' },
                { 14, 'E' },
                { 15, 'F' }
            };
        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            //проверка введенного числа
            string strNum = inputTB.Text;
            int number;
            bool flag = int.TryParse(strNum, out number);
            if (!flag)
            {
                MessageBox.Show("TextBox does not contain an integer");
                return;
            }
            if (number < 0)
            {
                MessageBox.Show("Please enter a positive number or zero");
                return;
            }
            //проверка исходной системы счисления 

            //проверка выходной системы счисления 
            string strto = toTB.Text;
            int to;
            flag = int.TryParse(strto, out to);
            if (!flag)
            {
                MessageBox.Show("TextBox не содержит целого числа");
                return;
            }
            if (to <= 0 || to > 16)
            {
                MessageBox.Show("Введите положительное число до 16");
                return;
            }



            StringBuilder result = convert(number, to);
            OutputLabel.Content = result.ToString();
        }
        private static StringBuilder convert(int number, int to)
        {
            int remainder = 0;
            StringBuilder result = new StringBuilder();
            do
            {
                remainder = number % to;
                number /= to;
                result.Insert(0, hexDigits[remainder]);
            }
            while (number > 0);

            return result;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GoToPage1_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Page2(_mainFrame));
        }
        public void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }
    }
}
