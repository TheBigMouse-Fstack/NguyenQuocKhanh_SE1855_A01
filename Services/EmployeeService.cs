﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Repositories;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository iemployeeRepository;
        private bool isGenerated = false;

        public EmployeeService()
        {
            iemployeeRepository = new EmployeeRepository();
        }

        public bool AddEmployee(Employee employee)
        {
            return iemployeeRepository.AddEmployee(employee);
        }

        public List<Employee> GenerateSampleDataset()
        {
            if (!isGenerated)
            {
                isGenerated = true;
                return iemployeeRepository.GenerateSampleDataset();
            }
            return GetEmployees();
        }

        public List<Employee> GetEmployees()
        {
            return iemployeeRepository.GetEmployees();
        }

        public bool RemoveEmployee(int employeeId)
        {
            return iemployeeRepository.RemoveEmployee(employeeId);
        }

        public Employee SearchEmployee(int employeeId)
        {
            return iemployeeRepository.SearchEmployee(employeeId);
        }

        public bool UpdateEmployee(Employee employee)
        {
            return iemployeeRepository.UpdateEmployee(employee);
        }
    }
}
