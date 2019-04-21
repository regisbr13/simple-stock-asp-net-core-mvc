using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStock.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome da categoria")]
        public string Name { get; set; }

        [Display(Name = "Produtos")]
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Category()
        {
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
