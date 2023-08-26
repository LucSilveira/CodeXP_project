using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class CadComentarioViewModel
    {
        [Required(ErrorMessage = "O comentário deve ser informado!")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "O comentário está vazio")]
        public string ComentarioTexto { get; set; }


        [Required(ErrorMessage = "O anúncio comentado deve ser informado!")]
        [RegularExpression("([0-1]+)", ErrorMessage = "Anúncio inválido!")]
        public int idAnuncio { get; set; }
        

        [Required(ErrorMessage = "O usuário que comentou deve ser informado!")]
        [RegularExpression("([0-1]+)", ErrorMessage = "Usuário inválido!")]
        public int idUsuario { get; set; }
    }
}