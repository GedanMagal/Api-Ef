using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    // [Table("Categoria")] Schema utilizado para especificar nome da tabela no banco de dados
    public class Category
    {
        [Key]
        // [Column("cat_id")] Schema utilizado para especificar nome da coluna no banco de dados
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

    }
}