using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace DataLayer
{
    public class OrderDAO
    {
        static List<Order> orders = new List<Order>();
        private bool isGenerated = false;
        public List<Order> GenerateSampleDataset()
        {
            if(isGenerated) return orders;

            orders.Add(new Order()
            {
                OrderID = 1,
                CustomerID = 1,
                EmployeeID = 1,
                OrderDate = new DateTime(2024, 12, 10)
            });

            orders.Add(new Order()
            {
                OrderID = 2,
                CustomerID = 2,
                EmployeeID = 2,
                OrderDate = new DateTime(2024, 12, 15)
            });

            orders.Add(new Order()
            {
                OrderID = 3,
                CustomerID = 3,
                EmployeeID = 3,
                OrderDate = new DateTime(2025, 1, 5)
            });

            orders.Add(new Order()
            {
                OrderID = 4,
                CustomerID = 4,
                EmployeeID = 4,
                OrderDate = new DateTime(2025, 1, 20)
            });

            orders.Add(new Order()
            {
                OrderID = 5,
                CustomerID = 5,
                EmployeeID = 5,
                OrderDate = new DateTime(2025, 2, 14)
            });
            isGenerated = true;
            return orders;
        }
        public List<Order> GetOrders()
        {
            return orders;
        }
        public bool AddOrder(Order order)
        {
            Order o = orders.FirstOrDefault(x => x.OrderID == order.OrderID);
            if (o != null)
            {
                return false;
            }

            orders.Add(order);
            return true;
        }

        public bool RemoveOrder(int orderId)
        {
            Order o = orders.FirstOrDefault(x => x.OrderID == orderId);
            if (o == null)
            {
                return false;
            }

            orders.Remove(o);
            return true;
        }
        public Order SearchOrder(int orderId)
        {
            return orders.FirstOrDefault(x => x.OrderID == orderId);
        }
        public bool UpdateOrder(Order order)
        {
            Order o = orders.FirstOrDefault(x => x.OrderID == order.OrderID);
            if (o == null)
            {
                return false;
            }

            o.CustomerID = order.CustomerID;
            o.EmployeeID = order.EmployeeID;
            o.OrderDate = order.OrderDate;

            return true;
        }
    }
}
