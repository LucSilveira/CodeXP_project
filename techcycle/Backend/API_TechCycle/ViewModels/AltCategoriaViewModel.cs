using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class AltCategoriaViewModel
    {
        [StringLength(30, MinimumLength = 4, ErrorMessage = "O mínimo de caracteres é 4")]
        public string nomeCategoria { get; set; }
    }
}