using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BusinessLayer;
using Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductManagement.xaml
    /// </summary>
    public partial class ProductManagement : Window
    {
        private ProductService ps = new ProductService();
        private InputValidator iv = new InputValidator();
        public ProductManagement()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void DisplayProducts()
        {
            ps.GenerateSampleDataset();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = ps.GetProducts();
        }

        

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {

            AddProductDialog addProductDialog = new AddProductDialog();
            if(addProductDialog.ShowDialog() == true)
            {
                DisplayProducts();
            }
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem is Product product) {
                UpdateProductDialog updateProductDialog = new UpdateProductDialog(product);

                if (updateProductDialog.ShowDialog() == true)
                {
                    DisplayProducts();
                }
            }
        }

        private void btnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Ban muon xoa san pham?", "Xac nhan xoa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbr == MessageBoxResult.No)
            {
                return;
            }
            if (lvProduct.SelectedItem is Product selectedProduct)
            {
                if (selectedProduct == null)
                {
                    MessageBox.Show("Hay chon mot san pham de xoa");
                    return;
                }

                bool isSuccess = ps.RemoveProduct(selectedProduct.ProductID);

                if (isSuccess)
                {
                    DisplayProducts();
                }
                else
                {
                    MessageBox.Show("Khong the xoa san pham");
                }
            }
        }

        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtSearchProductID.Text, out int id))
            {
                MessageBox.Show("ID không hợp lệ.");
                return;
            }

            Product product = ps.SearchProduct(id);

            if (product != null)
            {
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = new List<Product> { product };
            }
            else
            {
                MessageBox.Show($"Không tìm thấy sản phẩm với ID = {id}");
            }
        }
    }
}
