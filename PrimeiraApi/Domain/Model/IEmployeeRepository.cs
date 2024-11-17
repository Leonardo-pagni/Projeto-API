using PrimeiraApi.Domain.DTOs;

namespace PrimeiraApi.Domain.Model
{
    public interface IEmployeeRepository
    {
        void add(Employee employee);
        List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
