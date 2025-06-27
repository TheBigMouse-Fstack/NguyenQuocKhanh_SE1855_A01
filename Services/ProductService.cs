using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iproductRepository;

        public ProductService()
        {
            iproductRepository = new ProductRepository();
        }

        public bool AddProduct(Product product)
        {
            return iproductRepository.AddProduct(product);
        }

        public List<Product> GenerateSampleDataset()
        {

                return iproductRepository.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return iproductRepository.GetProducts();
        }

        public bool RemoveProduct(int productId)
        {
            return iproductRepository.RemoveProduct(productId);
        }

        public Product SearchProduct(int productId)
        {
            return iproductRepository.SearchProduct(productId);
        }

        public bool UpdateProduct(Product product)
        {
            return iproductRepository.UpdateProduct(product);
        }
    }
}
