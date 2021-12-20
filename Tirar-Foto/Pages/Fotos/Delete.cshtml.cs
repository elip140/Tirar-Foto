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
    public class DeleteModel : PageModel
    {
        private readonly Tirar_FotoContext _context;

        public DeleteModel(Tirar_FotoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Foto Foto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Foto = await _context.Foto.FirstOrDefaultAsync(m => m.Id == id);

            if (Foto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Foto = await _context.Foto.FindAsync(id);

            if (Foto != null)
            {
                _context.Foto.Remove(Foto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
