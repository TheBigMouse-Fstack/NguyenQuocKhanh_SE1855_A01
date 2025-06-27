using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository iorderDetailRepository;

        public OrderDetailService()
        {
            iorderDetailRepository = new OrderDetailRepository();
        }

        public bool AddOrderDetail(OrderDetail detail)
        {
            return iorderDetailRepository.AddOrderDetail(detail);
        }

        public List<OrderDetail> GenerateSampleDataset()
        {
            return iorderDetailRepository.GenerateSampleDataset();
        }

        public List<OrderDetail> GetOrderDetails()
        {
            return iorderDetailRepository.GetOrderDetails();
        }

        public bool RemoveOrderDetail(int orderId, int productId)
        {
            return iorderDetailRepository.RemoveOrderDetail(orderId, productId);
        }

        public OrderDetail SearchOrderDetail(int orderId, int productId)
        {
            return iorderDetailRepository.SearchOrderDetail(orderId, productId);
        }

        public bool UpdateOrderDetail(OrderDetail detail)
        {
            return iorderDetailRepository.UpdateOrderDetail(detail);
        }
    }
}
