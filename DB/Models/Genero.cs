
namespace DB.Models
{
    public class Genero : BaseEntity
    {
        // Navigation Properties
        public ICollection<Serie>? GeneroPrimario { get; set; }
        public ICollection<Serie>? GeneroSecundario { get; set; }
    }
}
