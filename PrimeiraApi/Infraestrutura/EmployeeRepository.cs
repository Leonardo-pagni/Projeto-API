﻿using PrimeiraApi.Model;

namespace PrimeiraApi.Infraestrutura
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();


        public void add(Employee employee)
        {
           _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
