using System.ComponentModel.DataAnnotations;

namespace TechCycle_Back.ViewModels
{
    public class CadUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo de user name deve ser informado!")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "O mínimo de caracteres é 5")]
        public string loginUsuario { get; set; }


        [Required(ErrorMessage = "O campo de senha deve ser informado!")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "O mínimo de caracteres é 5")]
        [DataType(DataType.Password)]
        public string senha { get; set; }


        [Required(ErrorMessage = "O campo de nome deve ser informado!")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O mínimo de caracteres é 3")]
        public string nomeCompleto { get; set; }


        [Required(ErrorMessage = "O campo de email deve ser informado!")]
        [EmailAddress(ErrorMessage = "O formato do Email é inválido")]
        public string email { get; set; }


        // Não há obrigátoriedade
        public string fotoUsuario { get; set; }


        [Required(ErrorMessage = "O campo de departamento deve ser informado!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O minímo de caracteres é 2")]
        public string departamento { get; set; }
    }
}