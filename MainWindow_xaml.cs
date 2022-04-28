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

namespace kofe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int price = 0;
        int sufar = 12;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void type_coffee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (type_coffee.SelectedIndex)
            {
                case 0:
                    price = 10;
                    ImageCoffee.Source = new BitmapImage(new Uri("https://www.kahveler.com/wp-content/uploads/2019/09/Epic-Expresso-5-of-56-1140x760.jpg"));
                    ObNull();
                    break;
                case 1:
                    price = 59;
                    ImageCoffee.Source = new BitmapImage(new Uri("https://coffeemachina.com/wp-content/uploads/2019/06/doppio.jpg"));
                    ObNull();
                    break;
                case 2:
                    price = 80;
                    ImageCoffee.Source = new BitmapImage(new Uri("https://about-tea.ru/wp-content/uploads/c/9/d/c9dcee7c496111a58851920e374b0eaf.jpg"));
                    ObNull();
                    break;
                case 3:
                    price = 53;
                    ImageCoffee.Source = new BitmapImage(new Uri("https://i.pinimg.com/originals/85/2b/d1/852bd14839ae95e6328875e93ef3944e.jpg"));
                    ObNull();
                    break;
                case 4:
                    price = 24;
                    ImageCoffee.Source = new BitmapImage(new Uri("https://mycoffe.ru/up/files/images/kofe-long-blek2.jpg"));
                    ObNull();
                    break;
                case 5:
                    price = 74;
                    ImageCoffee.Source = new BitmapImage(new Uri("https://coffeemachina.com/wp-content/uploads/2019/06/kapuchino.jpg"));
                    ObNull();
                    break;
                case 6:
                    price = 46;
                    ImageCoffee.Source = new BitmapImage(new Uri("https://coffeemachina.com/wp-content/uploads/2019/06/latte.jpg"));
                    ObNull();
                    break;
                default:
                    break;
            }
        }
        private void ObNull()
        {
            NoCB.IsChecked = false;
            YesCB.IsChecked = false;
            PreResult.Content = "0";
            Quantitycup.Text = "";
            summ.Content = "0";
            InputMoney.Text = "0";
            OutputMoney.Content = "0";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PreResult.Content.ToString() != "0")
            {
                summ.Content = (int.Parse(PreResult.Content.ToString()) * int.Parse(Quantitycup.Text.ToString())).ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (summ.Content.ToString() != "0")
            {
                if (InputMoney.Text.ToString() != "0")
                {
                    OutputMoney.Content = (int.Parse(InputMoney.Text.ToString()) - int.Parse(summ.Content.ToString())).ToString();
                    MessageBox.Show("Спасибо за использование нашей Кофейни", "Thanks", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Клиент не заплатил -_-", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);   
                }
            }
            else
            {
                MessageBox.Show("Клиента не зачем пока расчитывать","Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void YesCB_Checked(object sender, RoutedEventArgs e)
        {
            
            if (price == 0)
            {
                MessageBox.Show("Кофе не выбран", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                YesCB.IsChecked = false;
            }
            else
            {
                if (NoCB.IsChecked == true)
                {
                    NoCB.IsChecked = false;
                    rast();
                }
                else
                {
                    rast();
                }
            }
        }

        private void NoCB_Checked(object sender, RoutedEventArgs e)
        {
            
            if (price == 0)
            {
                MessageBox.Show("Кофе не выбран", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                NoCB.IsChecked = false;
            }
            else
            {
                if (YesCB.IsChecked == true)
                {
                    YesCB.IsChecked = false;
                    rast();
                }
                else
                {
                    rast();
                }
            }
        }
        private void rast()
        {
            if (YesCB.IsChecked == true)
            {
                PreResult.Content = (price + sufar).ToString();
            }
            else
            {
                PreResult.Content = price.ToString();
            }
        }

        private void TBKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.D1 || e.Key == Key.D2 || e.Key == Key.D3 || e.Key == Key.D4
                || e.Key == Key.D5 || e.Key == Key.D6 || e.Key == Key.D7 || e.Key == Key.D8
                || e.Key == Key.D9 || e.Key == Key.D0 || e.Key == Key.NumPad0
                || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3
                || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6
                || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9)&& e.Key != Key.Space)
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }
        }
    }
}
