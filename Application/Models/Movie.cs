using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [DisplayName("Título")]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayName("Data de lançamento")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Gênero")]
        public string Genre { get; set; } = string.Empty;

        [DisplayName("Preço")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [DisplayName("Avaliação")]
        public string Rating { get; set; } = string.Empty;
    }
}