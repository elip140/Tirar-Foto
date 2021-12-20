using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TirarFoto.Models;

namespace Tirar_Foto.Pages_Fotos
{
    public class IndexModel : PageModel
    {
        private readonly Tirar_FotoContext _context;

        public IndexModel(Tirar_FotoContext context)
        {
            _context = context;
        }

        public IList<Foto> Foto { get;set; }

        public async Task OnGetAsync()
        {
            Foto = await _context.Foto.ToListAsync();
        }
    }
}
