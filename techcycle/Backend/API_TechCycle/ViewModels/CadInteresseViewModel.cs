using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class CadInteresseViewModel
    {
        [Required(ErrorMessage = "É necessário informar o usuario interessado")]
        public int IdUsuarioInteressado { get; set; }


        [Required(ErrorMessage = "É necessário informar o usuario que aprovara")]
        public int IdUsuarioAprovacao { get; set; }


        [Required(ErrorMessage = "É necessário informar o anuncio pertencente")]
        public int IdAnuncio { get; set; }
    }
}