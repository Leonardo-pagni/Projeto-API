using PrimeiraApi.Domain.Model;
using PrimeiraApi.Domain.DTOs;

namespace PrimeiraApi.Infraestrutura.Repositores
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ConnectionContext _context = new ConnectionContext();


        public void add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select( b => 
                new EmployeeDTO()
                {
                    Id = b.Id,
                    EmployeeName = b.Nome,
                    Photo = b.Photo,
                })
                .ToList();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
