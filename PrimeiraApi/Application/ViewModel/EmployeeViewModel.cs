﻿using System.Collections.Specialized;

namespace PrimeiraApi.Application.ViewModel
{
    public class EmployeeViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public IFormFile Photo { get; set; }
    }
}