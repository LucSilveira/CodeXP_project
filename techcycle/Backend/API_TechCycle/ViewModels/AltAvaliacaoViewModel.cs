using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class AltAvaliacaoViewModel
    {
        [StringLength(255, MinimumLength = 10, ErrorMessage = "O mínimo de caracteres é 10")]
        public string DescricaoAvaliacao { get; set; }
        

        [StringLength(15, MinimumLength = 3, ErrorMessage = "O mínimo de caracteres é 3 e o máximo 15")]
        public string TipoAvaliacao { get; set; }
    }
}