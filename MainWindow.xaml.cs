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

namespace практика
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int schet1 = 0;

        private async void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var password = Password_Box.Password;
            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => x.Login == login || x.Email == login && x.Password == password);

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Логин и пароль обязательные для заполнения");
                Login.BorderBrush = Brushes.Red;
                Login.BorderThickness = new Thickness(3);
                Password_Box.BorderBrush = Brushes.Red;
                Password_Box.BorderThickness = new Thickness(3);
                return;
            }


            if (user is null)
            {
                Error.Text = ("Неправильный логин или пароль");
                Error.Visibility = Visibility.Visible;
                schet1++;
                Login.BorderBrush = Brushes.Red;
                Login.BorderThickness = new Thickness(3);
                Password_Box.BorderBrush = Brushes.Red;
                Password_Box.BorderThickness = new Thickness(3);

                if (schet1 == 3)
                {
                    AuthBtn.IsEnabled = false;
                    ToRegBtn.IsEnabled = false;
                    EyeBtn.IsEnabled = false;
                    Login.IsEnabled = false;
                    Password_Box.IsEnabled = false;
                    PasswordActeveBox.IsEnabled = false;
                    MessageBox.Show("Вход заблокирован на 15 секунд");
                    await Task.Delay(15000);
                    AuthBtn.IsEnabled = true;
                    ToRegBtn.IsEnabled = true;
                    EyeBtn.IsEnabled = true;
                    Login.IsEnabled = true;
                    Password_Box.IsEnabled = true;
                    PasswordActeveBox.IsEnabled = true;
                    schet1 = 0;

                }
                return;
            }

            if (user.Password != password) 
            {
                MessageBox.Show("Пароль не правильный");
                Password_Box.BorderBrush = Brushes.Red;
                Password_Box.BorderThickness = new Thickness(3);
            }

            MessageBox.Show("Вы успешно вошли");

            Window2 window2 = new(login);
            window2.Show();
            this.Hide();
        }

        private void ToRegBtn_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new();
            window1.Show();
            this.Hide();
        }

        private void EyeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordActeveBox.Visibility == Visibility.Visible)
            {
                Password_Box.Password = PasswordActeveBox.Text;
                Password_Box.Visibility = Visibility.Visible;
                PasswordActeveBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                PasswordActeveBox.Text = Password_Box.Password;
                Password_Box.Visibility = Visibility.Collapsed;
                PasswordActeveBox.Visibility = Visibility.Visible;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
