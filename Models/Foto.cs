using System.ComponentModel.DataAnnotations;

namespace TirarFoto.Models
{
    public class Foto
    {
        public int Id {get; set;}
        public int UID {get; set;}
        
        [Required]
        public string Base64 {get; set;}
        public string Nome {get; set;}
        
        public Foto(string base64="", string nome="")
        {
            Base64 = base64;
            Nome = nome;
        }

        public string Show(){
            return $"data:image/png;base64,{Base64}";
        }
    }
}