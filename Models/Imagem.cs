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
    
    public partial class Imagem
    {
        public Imagem()
        {
            this.Questao = new HashSet<Questao>();
        }
    
        public int codImagem { get; set; }
        public string tituloImagem { get; set; }
        public byte[] bitmapImagem { get; set; }
    
        public virtual ICollection<Questao> Questao { get; set; }
    }
}
