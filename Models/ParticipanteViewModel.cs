using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJETO3.Models
{
    [NotMapped]
    public class ParticipanteViewModel
    {
        public int codParticipante { get; set; }
        [DisplayName("NOME ")]
        [Required]
        public string nmParticipante { get; set; }

        [DisplayName("CÓDIGO DO CURSO ")]
        [Required]
        public int codCurso { get; set; }

        [DisplayName("E-MAIL ")]
        [Required]
        [Remote("VerificarEmail","Participante")]
        public string email { get; set; }
        [DisplayName("SENHA ")]
        [Required]
        [DataType(DataType.Password)]
        public string senha { get; set; }
        [DisplayName("ATIVO ")]
        public bool ativo { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual ICollection<Grupo> Grupo { get; set; }
    }
}