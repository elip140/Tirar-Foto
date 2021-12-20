using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TirarFoto.Models;

    public class Tirar_FotoContext : DbContext
    {
        public Tirar_FotoContext (DbContextOptions<Tirar_FotoContext> options)
            : base(options)
        {
        }

        public DbSet<TirarFoto.Models.Foto> Foto { get; set; }
    }
    
