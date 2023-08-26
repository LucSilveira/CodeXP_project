using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class AltInteresseViewModel
    {
        [StringLength(10, MinimumLength = 7, ErrorMessage = "O mínimo de caracteres é 7")]
        public string StatusAprovacao { get; set; }


        // [RegularExpression("([0-9]+)", ErrorMessage = "O usuário com interesse deve ser informado!")]
        public int idUsuarioInteressado { get; set; }


        // [RegularExpression("([0-9]+)", ErrorMessage = "O usuário de aprovação deve ser informado!")]
        public int idUsuarioAprovacao { get; set; } 


        // [RegularExpression("([0-9]+)", ErrorMessage = "O anúncio interessado deve ser informado!")]
        public int idAnuncio { get; set; }
    }
}