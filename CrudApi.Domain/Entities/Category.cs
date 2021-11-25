using CrudApi.Domain.Validation;
using System.Collections.Generic;

namespace CrudApi.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido ou não informado.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        // Uma categoria pode ter vários produtos
        // Propriedade de navegação
        public ICollection<Product> Products { get; set; }

        //Validação de nomes
        //Utilizando classe criada na validation
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. Campo obrigatório.");

            DomainExceptionValidation.When(name.Length < 3,
                "Nome inválido. Informar nome completo com 3 caracteres ou mais.");

            Name = name;
        }
    }
}
