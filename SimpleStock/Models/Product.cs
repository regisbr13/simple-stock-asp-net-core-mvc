using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleStock.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome do produto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "valor obrigatório")]
        [Display(Name = "Preço de compra")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double CostPrice { get; set; }


        [Required(ErrorMessage = "valor obrigatório")]
        [Display(Name = "Preço de venda")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double SalePrice { get; set; }

        [Display(Name = "Categoria")]
        public Category Category { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "é necessária a criação de uma categoria")]
        public int CategoryId { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, double costPrice, double salePrice, Category category)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Category = category;
        }

    }
}
