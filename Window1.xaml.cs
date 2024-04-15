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

namespace практика
{
    public partial class Window1 : Window
    {
        private List<char> _spesialSymble = new List<char>()
        {
            '!','@','#','$','%','&','*','(',')','-','_','+','=','?','/','>','<',';',':','.'
        };
        public Window1()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Hide();
        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login_Reg.Text;
            var pass = Password_Reg.Text;
            var passrepit = Password_Reg_Repit.Text;
            var context = new AppDbContext();
            var user_exists = context.Users.FirstOrDefault(x => x.Login == login);
            var email = Email_Reg.Text;

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
            }

            if (pass.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов");
                Password_Reg.BorderBrush = Brushes.Red;
                Password_Reg.BorderThickness = new Thickness(3);
                Password_Reg_Repit.BorderBrush = Brushes.Red;
                Password_Reg_Repit.BorderThickness = new Thickness(3);
                return;
            }

            if (!pass.Any(x => _spesialSymble.Contains(x)))
            {
                MessageBox.Show("Пароль должен содержать специальные символы");
                Password_Reg.BorderBrush = Brushes.Red;
                Password_Reg.BorderThickness = new Thickness(3);
                Password_Reg_Repit.BorderBrush = Brushes.Red;
                Password_Reg_Repit.BorderThickness = new Thickness(3);
                return;
            }

            if (passrepit != pass)
            {
                MessageBox.Show("Пароли не совпадают");
                Password_Reg.BorderBrush = Brushes.Red;
                Password_Reg.BorderThickness = new Thickness(3);
                Password_Reg_Repit.BorderBrush = Brushes.Red;
                Password_Reg_Repit.BorderThickness = new Thickness(3);
                return;
            }

            if (user_exists is not null) 
            {
                MessageBox.Show("Такой пользователь уже есть");
                Login_Reg.BorderBrush = Brushes.Red;
                Login_Reg.BorderThickness = new Thickness(3);
                return;
            }

            var user = new User { Login = login, Password = pass, Email = Email_Reg.Text};
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы Зарегистрировались");

            MainWindow main = new();
            main.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
