using System;
using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class AltAnuncioViewModel
    {
        [Range(0, 9999.99, ErrorMessage = "A quantidade máxima é de 10 mil reais")]
        public decimal precoAnuncio { get; set; }


        [DataType(DataType.DateTime, ErrorMessage = "A data deve ser informada")]
        public DateTime dataLancamento { get; set; }


        [RegularExpression("([0-9]+)", ErrorMessage = "Avaliação é inválida")]
        public int idAvaliacao { get; set; }


        [RegularExpression("([0-9]+)", ErrorMessage = "Produto é inválida")]
        public int idProduto { get; set; }
    }
}