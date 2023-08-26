using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class CadMarcaViewModel
    {
        [Required(ErrorMessage = "O nome da marca deve ser informado!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O mínimo de caracteres é 4")]
        public string NomeMarca { get; set; }
    }
}