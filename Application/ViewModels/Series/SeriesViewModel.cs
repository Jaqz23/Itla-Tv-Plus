using Application.ViewModels.Common;


namespace Application.ViewModels.Series
{
    public class SeriesViewModel : BaseViewModel
    {
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public string VideoLink { get; set; }

        // IDs Necesarios para los Filtros
        public int ProductoraId { get; set; }
        public int GeneroPrimarioId { get; set; }
        public int? GeneroSecundarioId { get; set; } 

        // Nombres de Relacion
        public string Productora { get; set; }
        public string GeneroPrimario { get; set; }
        public string? GeneroSecundario { get; set; }

    }
}
