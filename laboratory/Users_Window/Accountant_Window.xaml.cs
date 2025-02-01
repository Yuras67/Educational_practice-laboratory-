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

namespace laboratory.Users_Window
{
    public partial class Accountant_Window : Window
    {
        public Accountant_Window(string user_name)
        {
            InitializeComponent();
            Accountant_name.Content = user_name;
        }

        private void MonitorUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization_window = new Authorization();
            this.Close();
            authorization_window.ShowDialog();
        }
    }
}
