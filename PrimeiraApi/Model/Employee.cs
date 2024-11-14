using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraApi.Model
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Photo { get; set; }
        public int Idade { get; private set; }

        public Employee(string nome, int idade, string Photo)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Photo = Photo;
        }

    }
}
