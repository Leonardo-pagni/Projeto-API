namespace PrimeiraApi.Model
{
    public interface IEmployeeRepository
    {
        void add(Employee employee);
        List<Employee> Get(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
