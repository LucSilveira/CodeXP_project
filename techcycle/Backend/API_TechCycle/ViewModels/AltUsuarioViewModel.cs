using System.ComponentModel.DataAnnotations;

namespace TechCycle_Back.ViewModels
{
    public class AltUsuarioViewModel
    {
        [StringLength(255, MinimumLength = 5, ErrorMessage = "O mínimo de caracteres é 5")]
        public string loginUsuario { get; set; }


        [StringLength(255, MinimumLength = 5, ErrorMessage = "O mínimo de caracteres é 5")]
        [DataType(DataType.Password)]
        public string senha { get; set; }


        [StringLength(255, MinimumLength = 3, ErrorMessage = "O mínimo de caracteres é 3")]
        public string nomeCompleto { get; set; }


        [EmailAddress(ErrorMessage = "O formato do email está inválido")]
        public string email { get; set; }

        public string fotoUsuario { get; set; }


        [StringLength(50, MinimumLength = 2, ErrorMessage = "O mínimo de caracteres é 2")]
        public string departamento { get; set; }

        
        [StringLength(15, MinimumLength = 11, ErrorMessage = "O mínimo de caracteres é 11")]
        public string tipoDeUsuario { get; set; }


        [StringLength(10, MinimumLength = 7, ErrorMessage = "O mínimo de caracteres é 7")]
        public string statusAprovacao { get; set; }
    }
}