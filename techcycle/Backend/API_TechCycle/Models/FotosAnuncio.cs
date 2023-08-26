using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class FotosAnuncio
    {
        [Key]
        [Column("idFotosAnuncio")]
        public int IdFotosAnuncio { get; set; }
        [Column("fotoDoAnuncio")]
        [StringLength(255)]
        public string FotoDoAnuncio { get; set; }
        [Column("idAnuncio")]
        public int? IdAnuncio { get; set; }

        [ForeignKey(nameof(IdAnuncio))]
        [InverseProperty(nameof(Anuncio.FotosAnuncio))]
        public virtual Anuncio IdAnuncioNavigation { get; set; }
    }
}
