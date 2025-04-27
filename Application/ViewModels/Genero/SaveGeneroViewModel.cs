using Application.ViewModels.Common;
using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels.Genero
{
    public class SaveGeneroViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "El nombre del género es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres.")]
        public string Name { get; set; }
    }
}
