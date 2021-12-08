using System.ComponentModel.DataAnnotations;

namespace TirarFoto.Models
{
    public class Foto
    {
        public int Id {get; set;}
        public int UID {get; set;}
        public string Nome {get; set;}
        
        [Required]
        public string Base64 {get; set;}

        public Foto(){
            Nome = "";
        }

        public string Show(){
            return $"data:image/png;base64,{Base64}";
        }
    }
}