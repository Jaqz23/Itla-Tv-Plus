
namespace DB.Models
{
    public class Serie : BaseEntity
    {
        public string ImagePath { get; set; }
        public string VideoLink { get; set; }
        public virtual string? Description { get; set; }

        // Foreign Keys
        public int ProductoraId { get; set; }
        public int GeneroPrimarioId { get; set; }
        public int? GeneroSecundarioId { get; set; }

        // Navigation Properties
        public Productora? Productora { get; set; }
        public Genero? GeneroPrimario { get; set; }
        public Genero? GeneroSecundario { get; set; }
    } 
}
