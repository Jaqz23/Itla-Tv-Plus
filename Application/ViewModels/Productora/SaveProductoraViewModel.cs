using Application.ViewModels.Common;
using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels.Productora
{
    public class SaveProductoraViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "El nombre de la productora es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres.")]
        public string Name { get; set; }
    }
}
