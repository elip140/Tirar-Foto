using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TirarFoto.Models;

namespace Tirar_Foto.Pages_Fotos
{
    public class EditModel : PageModel
    {
        private readonly Tirar_FotoContext _context;

        public EditModel(Tirar_FotoContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Foto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FotoExists(Foto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FotoExists(int id)
        {
            return _context.Foto.Any(e => e.Id == id);
        }
    }
}
