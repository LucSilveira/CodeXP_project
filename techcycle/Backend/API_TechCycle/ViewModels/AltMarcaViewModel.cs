using System.ComponentModel.DataAnnotations;

namespace TechCycle_Back.ViewModels
{
    public class AltMarcaViewModel
    {
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O mínimo de caracteres é 4")]
        public string NomeMarca { get; set; }
    }
}