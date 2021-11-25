using CrudApi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido ou não informado.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. Campo obrigatório.");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido. Informar nome completo com 3 caracteres ou mais.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
               "Descrição é campo obrigatório.");
            DomainExceptionValidation.When(name.Length < 5,
                "Descrição inválida. Informar pelo menos 5 caracteres ou mais.");
            DomainExceptionValidation.When(price < 0,
                "Preço inválido.");
            DomainExceptionValidation.When(stock < 0,
                "Estoque inválido.");
            DomainExceptionValidation.When(image.Length < 250,
               "Imagem inválida. Tente novamente.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        //Relacionando o produto a uma categoria
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
