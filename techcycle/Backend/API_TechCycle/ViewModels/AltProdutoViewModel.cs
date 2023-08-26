using System;
using System.ComponentModel.DataAnnotations;

namespace API_TechCycle.ViewModels
{
    public class AltProdutoViewModel
    {
        [StringLength(255, MinimumLength = 4, ErrorMessage = "O mínimo de caracteres é 4")]
        public string NomeProduto { get; set; }
        

        [StringLength(255, MinimumLength = 1, ErrorMessage = "O modelo não pode ser nulo")]
        public string ModeloProduto { get; set; }


        [RegularExpression("([0-9]+)", ErrorMessage = "Informe a quantidade da memória")]
        public int MemoriaProduto { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "A quantidade mínima de caracteres é 3")]
        public string Processador { get; set; }


        [StringLength(255, MinimumLength = 1, ErrorMessage = "É necessário colocar uma descrição")]
        public string Descricao { get; set; }


        [StringLength(255, MinimumLength = 7, ErrorMessage = "O mínimo de caracteres é 7")]
        public string CodIdentificacao { get; set; }
        

        [DataType(DataType.DateTime, ErrorMessage = "A data é necessária")]
        public DateTime DataLancamento { get; set; }


        [RegularExpression("([0-2]+)", ErrorMessage = "Categoria inválida")]
        public int IdCategoria { get; set; }


        [RegularExpression("([0-2]+)", ErrorMessage = "Marca inválida")]
        public int IdMarca { get; set; }
    }
}