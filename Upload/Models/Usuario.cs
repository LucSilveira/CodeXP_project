using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upload.Models
{
    public partial class Usuario
    {
        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }
        
        [StringLength(255)]
        public string Foto { get; set; }
    }
}
