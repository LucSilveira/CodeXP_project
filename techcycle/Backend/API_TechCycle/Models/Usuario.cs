using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TechCycle.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentario = new HashSet<Comentario>();
            InteresseIdUsuarioAprovacaoNavigation = new HashSet<Interesse>();
            InteresseIdUsuarioInteressadoNavigation = new HashSet<Interesse>();
        }

        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Required]
        [Column("loginUsuario")]
        [StringLength(255)]
        public string LoginUsuario { get; set; }
        [Required]
        [Column("senha")]
        [StringLength(255)]
        public string Senha { get; set; }
        [Required]
        [Column("nomeCompleto")]
        [StringLength(255)]
        public string NomeCompleto { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("fotoUsuario")]
        [StringLength(255)]
        public string FotoUsuario { get; set; }
        [Column("departamento")]
        [StringLength(50)]
        public string Departamento { get; set; }
        [Required]
        [Column("tipoDeUsuario")]
        [StringLength(15)]
        public string TipoDeUsuario { get; set; }
        [Required]
        [Column("statusAprovacao")]
        [StringLength(10)]
        public string StatusAprovacao { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Comentario> Comentario { get; set; }
        [InverseProperty(nameof(Interesse.IdUsuarioAprovacaoNavigation))]
        public virtual ICollection<Interesse> InteresseIdUsuarioAprovacaoNavigation { get; set; }
        [InverseProperty(nameof(Interesse.IdUsuarioInteressadoNavigation))]
        public virtual ICollection<Interesse> InteresseIdUsuarioInteressadoNavigation { get; set; }
    }
}
