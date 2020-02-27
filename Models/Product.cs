using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Campo deve possuir no máximo 60 Caracteres ")]
        [MinLength(3, ErrorMessage = "Campo deve possuir no Minimo 3 Caracteres ")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior do que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}