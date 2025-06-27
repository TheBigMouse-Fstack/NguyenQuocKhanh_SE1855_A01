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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerMainForm.xaml
    /// </summary>
    public partial class CustomerMainForm : Window
    {
        Customer currentCustomer = new Customer();
        public CustomerMainForm(Customer existingCustomer)
        {
            InitializeComponent();
            currentCustomer = existingCustomer;
        }

        private void btnOrderProcessing_Click(object sender, RoutedEventArgs e)
        {
            CustomerOrderWindow cow = new CustomerOrderWindow(currentCustomer);
            cow.Show();
            Close();
        }

        private void btnProfileEditing_Click(object sender, RoutedEventArgs e)
        {
            ProfileManagement pm = new ProfileManagement(currentCustomer);
            pm.Show();
            Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            CustomerLogin cl = new CustomerLogin();
            cl.Show();
            Close();
        }
    }
}
