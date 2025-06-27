using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        OrderService os = new OrderService();
        OrderDetailService ods = new OrderDetailService();
        CustomerService cs = new CustomerService();
        List<Order> orders = new List<Order>();
        List<OrderDetail> orderDetails = new List<OrderDetail>();
        List<Customer> customers = new List<Customer>();
        public ReportsWindow()
        {
            InitializeComponent();
            orders = os.GetOrders();
            orderDetails = ods.GetOrderDetails();
            customers = cs.GetCustomers();

            DisplayReports();
            SortComboBox.ItemsSource = new List<string>
            {
                "Date Descending",
                "Date Ascending",
                "Amount Descending",
                "Amount Ascending"
            };
            SortComboBox.SelectedIndex = 0;

            FromDatePicker.SelectedDate = DateTime.Today.AddMonths(-1);
            ToDatePicker.SelectedDate = DateTime.Today;
        }

        private void DisplayReports()
        {
            DateTime fromDate = FromDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime toDate = ToDatePicker.SelectedDate ?? DateTime.MaxValue;

            var report = orders
                .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                .Select(o => new
                {
                    o.OrderID,
                    CustomerName = customers.FirstOrDefault(c => c.CustomerID == o.CustomerID)?.CompanyName ?? "Unknown",
                    o.OrderDate,
                    TotalAmount = orderDetails
                        .Where(d => d.OrderID == o.OrderID)
                        .Sum(d => (int) d.UnitPrice * d.Quantity * (1 - (decimal)d.Discount))
                })
                .OrderByDescending(r => r.TotalAmount)
                .ToList();

            lvReport.ItemsSource = report;
        }

        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayReports();
        }
    }
}
