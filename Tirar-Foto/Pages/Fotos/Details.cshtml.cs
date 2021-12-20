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
    public class DetailsModel : PageModel
    {
        private readonly Tirar_FotoContext _context;

        public DetailsModel(Tirar_FotoContext context)
        {
            _context = context;
        }

        public Foto Foto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("./Index");
            }

            Foto = await _context.Foto.FirstOrDefaultAsync(m => m.Id == id);

            if (Foto == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
