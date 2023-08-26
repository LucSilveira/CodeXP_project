using System;
using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class CadAnuncioViewModel
    {
        [Required(ErrorMessage = "O preco do anúncio deve ser informado!")]
        [Range(0, 9999.99, ErrorMessage = "A quantidade máxima é de 10 mil reais")]
        public decimal precoAnuncio { get; set; }


        [Required(ErrorMessage = "A data de lançamento deve ser informada!")]
        [DataType(DataType.DateTime, ErrorMessage = "A data deve ser informada")]
        public DateTime dataLancamento { get; set; }


        [Required(ErrorMessage = "A avaliação pertencente deve ser informado!")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Avaliação é inválida")]
        public int idAvaliacao { get; set; }


        [Required(ErrorMessage = "O produto pertencente deve ser informado")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Produto é inválida")]
        public int idProduto { get; set; }
    }
}