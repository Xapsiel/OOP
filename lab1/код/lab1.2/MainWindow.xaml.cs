using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace lab1._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static decimal guess = 0;
        decimal innerGuess = guess;

        private static decimal decNumber = 0;
        decimal innerDecNumber = decNumber;
        private static double doubleNumber = 0;
        private static int iter = 0;  
        private static bool worked = false;

        public MainWindow()
        {

            InitializeComponent();

        }
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (worked)
            {
                manLabel.Content = "";
            }
            iter = 0;
            double squareRoot = Math.Sqrt(doubleNumber);
            frameWorkLabel.Content = string.Format("{0}",squareRoot);

            decimal NumberDecimal = find_sqrt(decNumber,guess,false);
            newtonLabel.Content= string.Format("{0}", NumberDecimal);
            iter = 0;
            worked = true;
        }
        private void nextIteration_Click(object sender, RoutedEventArgs e)
        {
            if (iter == 0)
            {
                manLabel.Content = "";
            }
            if (frameWorkLabel.Content == ""){
                double squareRoot = Math.Sqrt(doubleNumber);
                frameWorkLabel.Content = string.Format("{0}", squareRoot);
            }
            decimal NumberDecimal = find_sqrt(innerDecNumber, innerGuess, true);
            if (NumberDecimal != -1)
            {
                newtonLabel.Content = string.Format("{0}", innerGuess);
                iter = 0;
                innerDecNumber = decNumber;
                innerGuess = guess;
                worked = true;


            }

        }
        private decimal find_sqrt(decimal numberDecimal, decimal guess, bool is_iter)
        {

            decimal delta = Convert.ToDecimal(Math.Pow(10, -28));
            decimal result = ((numberDecimal / guess) + guess) / 2;
            while (Math.Abs(result - guess) > delta && Math.Abs(innerDecNumber - innerGuess) > delta)
            {
                manLabel.Content += string.Format("Итерация: {0}\nПогрешность: {1}\nЗначение корня: {2}\n\n", iter, Math.Abs(result - guess), result);
                if (is_iter) {
                    guess = result;
                    iter++;
                    innerGuess = guess;
                    return -1;
                }
                guess = result;
                result = ((numberDecimal / guess) + guess) / 2;

                iter++;


            }
            if (iter == 0)
            {
                manLabel.Content = manLabel.Content += string.Format("Итерация: {0}\nПогрешность: {1}\nЗначение корня: {2}\n\n", iter, Math.Abs(result - guess), result);

            }
            return result;


        }

        private void inputGuessTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            double guessDouble;

            string strNum = (inputGuessTextBox.Text.Replace(".", ","));
            bool flag = double.TryParse(strNum, out guessDouble);
            if (!flag)
            {
                MessageBox.Show("Please enter a decimal");
                return;
            }
            if (guessDouble <= 0)
            {
                MessageBox.Show("Please enter a positive number");
                return;
            }
            guess = (decimal)guessDouble;
            innerGuess = guess;
        }

        private void inputNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double numberDouble;
            decimal numberDecimal;
            string strNum = (inputNumberTextBox.Text.Replace(".", ","));
            if (strNum.Length == 0)
            {
                strNum = "1";
            }
            bool flag = double.TryParse(strNum, out numberDouble);
            if (!flag)
            {
                MessageBox.Show("Please enter a double");
                return;
            }
            if (numberDouble <= 0)
            {
                MessageBox.Show("Please enter a positive number");
                return;
            }
            doubleNumber = numberDouble;

            flag = decimal.TryParse(strNum, out numberDecimal);
            if (!flag)
            {
                MessageBox.Show("Please enter a decimal");
                return;
            }

            decNumber = numberDecimal;
            innerDecNumber = decNumber;
            

        }
    }
}
