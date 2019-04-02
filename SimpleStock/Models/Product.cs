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

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Quantidade")]
        public int Quantity { get; set; }


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

        public Product()
        {
        }

        public Product(string name, int quantity, double costPrice, double salePrice)
        {
            Name = name;
            Quantity = quantity;
            CostPrice = costPrice;
            SalePrice = salePrice;
        }

        public double CostSubtotal()
        {
            return Quantity * CostPrice;
        }

        public double SaleSubtotal()
        {
            return Quantity * SalePrice;
        }

        public double Profit()
        {
            return SaleSubtotal() - CostSubtotal();
        }

        public double QttTotal(IEnumerable<Product> products)
        {
            int sum = 0;
            foreach (Product p in products)
            {
                sum += p.Quantity;
            }
            return sum;
        }

        public double CostTotal(IEnumerable<Product> products)
        {
            double sum = 0.0;
            foreach (Product p in products)
            {
                sum += p.CostSubtotal();
            }
            return sum;
        }

        public double SaleTotal(IEnumerable<Product> products)
        {
            double sum = 0.0;
            foreach (Product p in products)
            {
                sum += p.SaleSubtotal();
            }
            return sum;
        }

        public double ProfitTotal(IEnumerable<Product> products)
        {
            double sum = 0.0;
            foreach (Product p in products)
            {
                sum += p.Profit();
            }
            return sum;
        }

        public double ProfitMargin()
        {
            return Profit() / CostSubtotal();
        }

        public double ProfitMarginTotal(IEnumerable<Product> products)
        {
            return ProfitTotal(products) / CostTotal(products);
        }
    }
}
