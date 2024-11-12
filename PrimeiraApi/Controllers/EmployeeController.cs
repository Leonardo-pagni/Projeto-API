using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Model;
using PrimeiraApi.ViewModel;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Nome, employeeView.Idade);


            _employeeRepository.add(employee);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var empoloyees = _employeeRepository.Get();

            return Ok(empoloyees);
        }
    }
}
