using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
