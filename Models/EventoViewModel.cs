using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO3.Models
{
    [NotMapped]
    public class EventoViewModel
    {
        [Key]
        public int codEvento { get; set; }
        [Required(ErrorMessage = "É necessário a Descrição do evento")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "Insira uma DATA Válida")]
        public System.DateTime data { get; set; }
        [Required(ErrorMessage = "Escolha um Tipo de Evento")]
        public byte codTipoEvento { get; set; }
        [Required]
        public string codStatus { get; set; }
        [Required]
        public short codProfessor { get; set; }
        [Required(ErrorMessage = "É preciso gerar uma chave identificadora para o novo evento!")]
        public string identificador { get; set; }
        [Required(ErrorMessage = "Esse evento precisa estar associado a um Assunto")]
        public int codAssunto { get; set; }


        //   PARA SER IMPLEMENTADO NA CONTROLLER:

        /*
            String x="";           
            
            while (x.Length < 8)
            {

                char c = (char) sorteio (0,127);
                if (c > 50 && c < 57 || c > 97 && c < 120)
                {
                    x = x + c;
                }

                 http://www.ascii-code.com

            } */



    }
}