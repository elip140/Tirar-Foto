using TirarFoto.Models;
using System.IO;
using System;

namespace TirarFoto.FotosService
{
    public static class FotosList
    {
        private static List<Foto> Lista{get; }

        private static int nextID = 4;

        static FotosList()
        {
            byte[] imageArray1 = File.ReadAllBytes(@"Services/Placeholders/placeholder1.png");
            byte[] imageArray2 = File.ReadAllBytes(@"Services/Placeholders/placeholder2.png");
            byte[] imageArray3 = File.ReadAllBytes(@"Services/Placeholders/placeholder3.png");
            Lista = new List<Foto>
            {
                new Foto(Convert.ToBase64String(imageArray1), "Placeholder1"){Id = 1, UID = 10001},
                new Foto(Convert.ToBase64String(imageArray2), "Placeholder2"){Id = 2, UID = 10001},
                new Foto(Convert.ToBase64String(imageArray3), "Placeholder3"){Id = 3, UID = 10001}
            };
        }

        public static List<Foto> GetAll() => Lista;

        public static Foto Get(int id) => Lista.FirstOrDefault(p => p.Id == id);

        public static void Add(Foto f, string base64)
        {
            f.Id = nextID++;
            Lista.Add(f);
        }

        public static void Delete(int id)
        {
            var f = Get(id);
            if (f is null)
                return;

            Lista.Remove(f);
        }

        public static void Update(Foto f)
        {
            var index = Lista.FindIndex(p => p.Id == f.Id);
            if (index == -1)
                return;

            Lista[index] = f;
        }
    }
}



