using System.ComponentModel.DataAnnotations;

namespace TirarFoto.Models
{
    public class Foto
    {
        private int Id {get; set;}
        private int UID {get; set;}
        [Required]
        public string Base64 {get; set;}

        public Foto(string base64)
        {
            Base64 = base64;
        }
    }
}