using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository iorderRepository;

        public OrderService()
        {
            iorderRepository = new OrderRepository();
        }

        public bool AddOrder(Order order)
        {
            return iorderRepository.AddOrder(order);
        }

        public List<Order> GenerateSampleDataset()
        {
            return iorderRepository.GenerateSampleDataset();
        }

        public List<Order> GetOrders()
        {
            return iorderRepository.GetOrders();
        }

        public bool RemoveOrder(int orderId)
        {
            return iorderRepository.RemoveOrder(orderId);
        }

        public Order SearchOrder(int orderId)
        {
            return iorderRepository.SearchOrder(orderId);
        }

        public bool UpdateOrder(Order order)
        {
            return iorderRepository.UpdateOrder(order);
        }
    }
}
