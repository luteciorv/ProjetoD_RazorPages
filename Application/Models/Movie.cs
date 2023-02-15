using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class Movie
    {
        public int Id { get; set; }
                
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Quantidade mínima e máxima de caracteres, respectivamente: 2 e 60")]
        [DisplayName("Título"), Required(ErrorMessage = "O campo \"Título\" é obrigatório")]
        public string Title { get; set; } = string.Empty;
        
        [DisplayName("Data de lançamento"), DataType(DataType.Date), Required(ErrorMessage = "O campo \"Data de lançamento\" é obrigatório")] 
        public DateTime ReleaseDate { get; set; }
        
        [StringLength(30, ErrorMessage = "Quantidade máxima de caracteres: 30")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Por favor, use apenas expressões regulares")]
        [DisplayName("Gênero"), Required(ErrorMessage = "O campo \"Gênero\" é obrigatório")]
        public string Genre { get; set; } = string.Empty;
        
        [Range(1, 100, ErrorMessage = "O valor do filme deve estar entre R$ 1,00 e R$ 100,00")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Preço"), Required(ErrorMessage = "O campo \"Preço\" é obrigatório")]
        public decimal Price { get; set; }
        
        [StringLength(2)]
        [DisplayName("Avaliação"), Required(ErrorMessage = "O campo \"Avaliação\" é obrigatório")]
        public string Rating { get; set; } = string.Empty;
    }
}