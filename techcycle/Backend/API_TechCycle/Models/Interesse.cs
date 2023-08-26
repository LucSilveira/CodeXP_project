using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Interesse
    {
        [Key]
        [Column("idInteresse")]
        public int IdInteresse { get; set; }
        [Column("idUsuarioInteressado")]
        public int? IdUsuarioInteressado { get; set; }
        [Column("idUsuarioAprovacao")]
        public int? IdUsuarioAprovacao { get; set; }
        [Column("idAnuncio")]
        public int? IdAnuncio { get; set; }
        [Column("statusAprovacao")]
        [StringLength(10)]
        public string StatusAprovacao { get; set; }

        [ForeignKey(nameof(IdAnuncio))]
        [InverseProperty(nameof(Anuncio.Interesse))]
        public virtual Anuncio IdAnuncioNavigation { get; set; }
        [ForeignKey(nameof(IdUsuarioAprovacao))]
        [InverseProperty(nameof(Usuario.InteresseIdUsuarioAprovacaoNavigation))]
        public virtual Usuario IdUsuarioAprovacaoNavigation { get; set; }
        [ForeignKey(nameof(IdUsuarioInteressado))]
        [InverseProperty(nameof(Usuario.InteresseIdUsuarioInteressadoNavigation))]
        public virtual Usuario IdUsuarioInteressadoNavigation { get; set; }
    }
}
