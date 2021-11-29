using CrudApi.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CrudApi.Domain.Tests
{
    public class ProductTest
    {
        [Fact(DisplayName = "Criar Produto válido")]
        public void CreateProduct_Result_Valid_Object()
        {
            Action action = () => new Product(1,"ProdutoTest","Item exclusivo", 99, 10, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Produto com Id inválido")]
        public void CreateProduct_Result_Invalid_IdObject()
        {
            Action action = () => new Product(-1, "ProdutoTest", "Item exclusivo", 99, 10, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Produto com nome curto")]
        public void CreateProduct_Result_Short_Name()
        {
            Action action = () => new Product(1, "Pr", "Item exclusivo", 99, 10, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Produto com campo descrição inválido")]
        public void CreateProduct_Result_Invalid_Description()
        {
            Action action = () => new Product(1, "ProdutoTest", "a", 99, 10, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Produto com estoque inválido")]
        public void CreateProduct_Result_Invalid_Stock()
        {
            Action action = () => new Product(1, "ProdutoTest", "a", -1, 10, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Produto com preço inválido")]
        public void CreateProduct_Result_Invalid_Price()
        {
            Action action = () => new Product(1, "ProdutoTest", "a", 99, -1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

    }
}
