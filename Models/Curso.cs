//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROJETO3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Curso
    {
        public Curso()
        {
            this.Participante = new HashSet<Participante>();
        }

        [DisplayName("C�DIGO DO CURSO ")]    
        public int codCurso { get; set; }
        [DisplayName("NOME do CURSO ")]
        public string nmCurso { get; set; }
    
        public virtual ICollection<Participante> Participante { get; set; }
    }
}
