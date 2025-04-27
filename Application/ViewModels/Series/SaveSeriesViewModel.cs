using Application.ViewModels.Common;
using Application.ViewModels.Genero;
using Application.ViewModels.Productora;
using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels.Series
{
    public class SaveSeriesViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "El nombre de la serie es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "La imagen de portada es obligatoria.")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "El enlace del video es obligatorio.")]
        public string VideoLink { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una productora.")]
        public int ProductoraId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género primario.")]
        public int GeneroPrimarioId { get; set; }

        public int? GeneroSecundarioId { get; set; }

        // Listas para los selects de productoras y géneros
        public List<ProductoraViewModel> Productoras { get; set; } = new();
        public List<GeneroViewModel> Generos { get; set; } = new();
    }
}
