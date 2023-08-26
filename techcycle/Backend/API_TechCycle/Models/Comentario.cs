using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Comentario
    {
        [Key]
        [Column("idComentario")]
        public int IdComentario { get; set; }
        [Column("comentarioTexto", TypeName = "text")]
        public string ComentarioTexto { get; set; }
        [Column("idAnuncio")]
        public int? IdAnuncio { get; set; }
        [Column("idUsuario")]
        public int? IdUsuario { get; set; }

        [ForeignKey(nameof(IdAnuncio))]
        [InverseProperty(nameof(Anuncio.Comentario))]
        public virtual Anuncio IdAnuncioNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Comentario))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
