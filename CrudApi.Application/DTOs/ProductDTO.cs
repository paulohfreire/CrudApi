using CrudApi.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApi.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Descrição é campo obrigatório")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Preço é campo obrigatório")]
        [Column(TypeName="decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantidade é campo obrigatório")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }
        [MaxLength(250)]
        [DisplayName("Imagem do produto")]
        public string Image { get; set; }
        public int CategoryId { get; set; }

        [DisplayName("Categorias")]
        public Category Category { get; set; }
    }
}
