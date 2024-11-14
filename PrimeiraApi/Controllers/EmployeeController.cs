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
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {
            //caminho do arquivo
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);
            //gerando a imagem
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Nome, employeeView.Idade, filePath);

            _employeeRepository.add(employee);

            return Ok();
        }

        [HttpPost]
        [Route("{id}/dowload")]
        public IActionResult DowloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(dataBytes, "image/png");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var empoloyees = _employeeRepository.Get();

            return Ok(empoloyees);
        }
    }
}
