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
    
    public partial class MasterEventosOrdem
    {
        public int codGrupo { get; set; }
        public byte ordem { get; set; }
        public string codConexao { get; set; }
    
        public virtual Grupo Grupo { get; set; }
    }
}
