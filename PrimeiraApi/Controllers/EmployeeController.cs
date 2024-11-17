using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Application.ViewModel;
using PrimeiraApi.Domain.Model;

namespace PrimeiraApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [Route("{id}/dowload")]
        public IActionResult DowloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(dataBytes, "image/png");
        }

       // [Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            //teste de logger(mensagem que aparece no console)
            //_logger.Log(LogLevel.Error, "Teve um Erro");

            var empoloyees = _employeeRepository.Get( pageNumber,  pageQuantity);

            //teste de logger(mensagem que aparece no console)
            //_logger.LogInformation("Teste");

            return Ok(empoloyees);
        }
    }
}
