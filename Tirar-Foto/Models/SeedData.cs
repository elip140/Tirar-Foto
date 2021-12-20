using Microsoft.EntityFrameworkCore;

namespace TirarFoto.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Tirar_FotoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Tirar_FotoContext>>()))
            {
                if (context == null || context.Foto == null)
                {
                    throw new ArgumentNullException("Null Tirar_FotoContext");
                }

                if (context.Foto.Any())
                {
                    return; 
                }

                byte[] imageArray1 = File.ReadAllBytes(@"Services/Placeholders/placeholder1.png");
                byte[] imageArray2 = File.ReadAllBytes(@"Services/Placeholders/placeholder2.png");
                byte[] imageArray3 = File.ReadAllBytes(@"Services/Placeholders/placeholder3.png");
                context.Foto.AddRange(
                    new Foto(){ UID = 10001, Base64 = Convert.ToBase64String(imageArray1), Nome = "Placeholder1"},
                    new Foto(){ UID = 10001, Base64 = Convert.ToBase64String(imageArray2), Nome = "Placeholder2"},
                    new Foto(){ UID = 10001, Base64 = Convert.ToBase64String(imageArray3), Nome = "Placeholder3"}
                );
                context.SaveChanges();
            }
        }
    }
}