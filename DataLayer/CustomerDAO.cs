using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace DataLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        private bool isGenerated = false;
        public List<Customer> GenerateSampleDataset()
        {
            if(isGenerated) {
                return customers;
            }

            customers.Add(new Customer()
            {
                CustomerID = 1,
                CompanyName = "Cong ty ABC",
                ContactName = "Nguyen Van A",
                ContactTitle = "Giam doc",
                Address = "123 Duong A, Quan 1",
                Phone = "0912345678"
            });

            customers.Add(new Customer()
            {
                CustomerID = 2,
                CompanyName = "CTCP XYZ",
                ContactName = "Tran Thi B",
                ContactTitle = "Truong phong",
                Address = "45 Duong B, Quan 3",
                Phone = "0987654321"
            });

            customers.Add(new Customer()
            {
                CustomerID = 3,
                CompanyName = "DNTN Gia Bao",
                ContactName = "Le Van C",
                ContactTitle = "Nhan vien",
                Address = "12 Duong C, Quan 5",
                Phone = "0909090909"
            });

            customers.Add(new Customer()
            {
                CustomerID = 4,
                CompanyName = "Cong ty Minh Chau",
                ContactName = "Pham Minh D",
                ContactTitle = "Pho giam doc",
                Address = "78 Duong D, Quan 10",
                Phone = "0966332211"
            });

            customers.Add(new Customer()
            {
                CustomerID = 5,
                CompanyName = "CT TNHH Hoa Binh",
                ContactName = "Doan Thi E",
                ContactTitle = "Truong bo phan",
                Address = "89 Duong E, Quan Binh Thanh",
                Phone = "0944556677"
            });
            isGenerated = true;
            return customers;
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public bool AddCustomer(Customer customer)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (c != null)
            {
                return false;
            }

            customers.Add(customer);
            return true;
        }

        public bool RemoveCustomer(int customerId)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (c == null)
            {
                return false;
            }

            customers.Remove(c);
            return true;
        }

        public Customer SearchCustomer(int customerId)
        {
            return customers.FirstOrDefault(c => c.CustomerID == customerId);
        }

        public bool UpdateCustomer(Customer customer)
        {
            Customer c = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
            if (c == null)
            {
                return false;
            }

            c.CompanyName = customer.CompanyName;
            c.ContactName = customer.ContactName;
            c.ContactTitle = customer.ContactTitle;
            c.Address = customer.Address;
            c.Phone = customer.Phone;

            return true;
        }
    }
}
