
namespace DB.Models
{
    public class Productora : BaseEntity
    {
        // Navigation Property
        public ICollection<Serie>? Series { get; set; }
    }
}
