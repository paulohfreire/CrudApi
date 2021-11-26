using CrudApi.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CrudApi.Domain.Tests
{
    public class CategoryTest
    {
        [Fact(DisplayName = "Criar categoria válida")]
        public void CreateCategory_Result_Valid_Object()
        {
            Action action = () => new Category(1, "Nome da categoria teste");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_Invalid_Id()
        {
            Action action = () => new Category(-1, "Nome da categoria teste");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_Nome_Curto()
        {
            Action action = () => new Category(1, "te");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Nome inválido. Informar nome completo com 3 caracteres ou mais.");
        }
    }
}
