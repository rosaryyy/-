using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using практика;

namespace практика
{

    public partial class Window3 : Window
    {
        private List<char> _spesialSymble = new List<char>()
        {
            '!','@','#','$','%','&','*','(',')','-','_','+','=','?','/','>','<',';',':','.'
        };

        public Window3()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Hide();
        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            int Errors = 0;
            var login = Login_Reg.Text;
            var pass = Password_Reg.Text;
            var passrepit = Password_Reg_Repit.Text;
            var context = new AppDbContext();
            var email = Email_Reg.Text;
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);

            do
            {
                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Логин и пароль обязательные для заполнения");
                    Login_Reg.BorderBrush = Brushes.Red;
                    Login_Reg.BorderThickness = new Thickness(3);
                    Password_Reg.BorderBrush = Brushes.Red;
                    Password_Reg.BorderThickness = new Thickness(3);
                    Password_Reg_Repit.BorderBrush = Brushes.Red;
                    Password_Reg_Repit.BorderThickness = new Thickness(3);
                    return;
                    Errors++;
                }

                if (pass.Length < 6)
                {
                    MessageBox.Show("Пароль должен содержать минимум 6 символов");
                    Password_Reg.BorderBrush = Brushes.Red;
                    Password_Reg.BorderThickness = new Thickness(3);
                    Password_Reg_Repit.BorderBrush = Brushes.Red;
                    Password_Reg_Repit.BorderThickness = new Thickness(3);
                    return;
                    Errors++;
                }

                if (!pass.Any(x => _spesialSymble.Contains(x)))
                {
                    MessageBox.Show("Пароль должен содержать специальные символы");
                    Password_Reg.BorderBrush = Brushes.Red;
                    Password_Reg.BorderThickness = new Thickness(3);
                    Password_Reg_Repit.BorderBrush = Brushes.Red;
                    Password_Reg_Repit.BorderThickness = new Thickness(3);
                    return;
                    Errors++;

                }

                if (passrepit != pass)
                {
                    MessageBox.Show("Пароли не совпадают");
                    Password_Reg.BorderBrush = Brushes.Red;
                    Password_Reg.BorderThickness = new Thickness(3);
                    Password_Reg_Repit.BorderBrush = Brushes.Red;
                    Password_Reg_Repit.BorderThickness = new Thickness(3);
                    return;
                    Errors++;

                }

                if (user_exists is not null)
                {
                    MessageBox.Show("Такой пользователь уже есть");
                    Login_Reg.BorderBrush = Brushes.Red;
                    Login_Reg.BorderThickness = new Thickness(3);
                    return;
                    Errors++;

                }
                break;
            }
            while (Errors != 0);

            if (Errors == 0)
            {
                var user = new User { Login = login, Email = email, Password = pass };
                var users = context.Users.FirstOrDefault(x => x.Login == login);
                if (users is not null)
                {
                    context.Users.Remove(users);
                    context.SaveChanges();
                }

                context.Users.Add(user);

                context.SaveChanges();

                MessageBox.Show("Успешно изменено!");
            }

        }


    }
}