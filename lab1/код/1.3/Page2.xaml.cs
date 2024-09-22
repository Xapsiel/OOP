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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1._3
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        static Dictionary<string, int> types = new Dictionary<string, int>
            {
                {"Арабские цифры",0},
                { "Римские цифры",1},
        };
        private string from = "Арабские цифры";
        private string to = "Римскте цифры";
        private Dictionary<int, string> romanNumerals = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };
        private Dictionary<string, int> romanToArabic = new Dictionary<string, int>
            {
                { "CM", 900 },
                { "M", 1000 },
                { "CD", 400 },
                { "D", 500 },
                { "XC", 90 },
                { "C", 100 },
                { "XL", 40 },
                { "L", 50 },
                { "IX", 9 },
                { "X", 10 },
                { "IV", 4 },
                { "V", 5 },
                { "I", 1 }

            };
        private Frame _mainFrame;

        public Page2(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }
        private void GoToPage0_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new Page1(_mainFrame));
        }


        private void FromTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FromTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                from = selectedItem.Content.ToString();
            }
        }
        private void ToTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToTypeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                to = selectedItem.Content.ToString();
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
        private string convertFromArabic(int number)
        {
            StringBuilder result = new StringBuilder();
 
            foreach (var item in romanNumerals)
            {
                int k = item.Key;
                string v = item.Value;
                int count = number / k;
                number %= k;
                for (int i = 0; i < count; i++)
                {
                    result.Append(v);
                }
            }
            return result.ToString();
        }
        private string convertFromRoman(string number)
        {
            int result = 0;

            foreach (var item in romanToArabic)
            {
                int v = item.Value;
                string k = item.Key;
                number = number.Replace(k,"!");

                foreach (var substr in number)
                {

                    if (substr == '!')
                    {
                        if (number.Substring(0, 1) != "!")
                        {
                            return "";
                        }
                        result += (v);
                    }
                }
                number = number.Replace("!", "");

            }
            if (number.Length != 0)
            {
                return "";
            }
            return result.ToString();
        }

        private void convert(object sender, RoutedEventArgs e)
        {
            string strNum = inputTB.Text;

            if (types[from] == 0)
            {
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
                string result = convertFromArabic(number);
                OutputLabel.Content = result;
            }
            else
            {
                strNum = strNum.ToUpper();
                string result = convertFromRoman(strNum);
                if (result == "")
                {
                    MessageBox.Show("Invalid format");
                }
                OutputLabel.Content = convertFromRoman(strNum);
            }
            
            
        }
    }
}
