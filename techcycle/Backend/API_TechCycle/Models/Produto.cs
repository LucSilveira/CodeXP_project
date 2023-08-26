using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Anuncio = new HashSet<Anuncio>();
        }

        [Key]
        [Column("idProduto")]
        public int IdProduto { get; set; }
        [Required]
        [Column("nomeProduto")]
        [StringLength(255)]
        public string NomeProduto { get; set; }
        [Required]
        [Column("modeloProduto")]
        [StringLength(255)]
        public string ModeloProduto { get; set; }
        [Column("memoriaProduto")]
        public int MemoriaProduto { get; set; }
        [Required]
        [Column("processador")]
        [StringLength(50)]
        public string Processador { get; set; }
        [Column("descricao", TypeName = "text")]
        public string Descricao { get; set; }
        [Column("codIdentificacao")]
        [StringLength(255)]
        public string CodIdentificacao { get; set; }
        [Column("dataLancamento", TypeName = "date")]
        public DateTime? DataLancamento { get; set; }
        [Column("idMarca")]
        public int? IdMarca { get; set; }
        [Column("idCategoria")]
        public int? IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(Categoria.Produto))]
        public virtual Categoria IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdMarca))]
        [InverseProperty(nameof(Marca.Produto))]
        public virtual Marca IdMarcaNavigation { get; set; }
        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<Anuncio> Anuncio { get; set; }
    }
}
