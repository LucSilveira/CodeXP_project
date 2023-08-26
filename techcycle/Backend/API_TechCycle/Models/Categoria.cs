using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produto = new HashSet<Produto>();
        }

        [Key]
        [Column("idCategoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("nomeCategoria")]
        [StringLength(30)]
        public string NomeCategoria { get; set; }

        [InverseProperty("IdCategoriaNavigation")]
        public virtual ICollection<Produto> Produto { get; set; }
    }
}
