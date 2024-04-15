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
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private string _login;
        public Window2(string login)
        {
         InitializeComponent();
            _login = login;
            Output.Text = "Здравствуйте, " + " " + _login;
        }

        private void Kabinet_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new();
            window3.Show();
            this.Hide();
        }
    }
}
