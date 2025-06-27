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
using BusinessLayer;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for EmployeeLogin.xaml
    /// </summary>
    public partial class EmployeeLogin : Window
    {
        EmployeeService employeeService = new EmployeeService();
        List<Employee> employees = new List<Employee>();
        public EmployeeLogin()
        {
            InitializeComponent();
            employeeService.GenerateSampleDataset();
            employees = employeeService.GetEmployees();
        }

        private void btnEmployeeLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            Employee emp = employees.FirstOrDefault(e => e.UserName.Equals(username) && e.Password.Equals(password));

            if (emp != null) {
                MainWindow mw = new MainWindow();
                mw.Show();
                Close();
            } else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Ban muon dang xuat?", "Xac nhan dang xuat", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbr == MessageBoxResult.No)
            {
                return;
            }

            Welcome w = new Welcome();
            w.Show();
            Close();
        }
    }
}
