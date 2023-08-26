using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class AltComentarioViewModel
    {
        [StringLength(255, MinimumLength = 1, ErrorMessage = "O comentário está vazio")]
        public string ComentarioTexto { get; set; }


        // [RegularExpression("([0-9]+)", ErrorMessage = "Anúncio inválido!")]
        public int idAnuncio { get; set; }
        

        // [RegularExpression("([0-9]+)", ErrorMessage = "Usuário inválido!")]
        public int idUsuario { get; set; }
    }
}