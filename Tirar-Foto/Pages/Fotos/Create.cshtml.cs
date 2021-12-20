using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TirarFoto.Models;

namespace Tirar_Foto.Pages_Fotos
{
    public class CreateModel : PageModel
    {
        private readonly Tirar_FotoContext _context;

        public CreateModel(Tirar_FotoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Foto Foto { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Foto.Add(Foto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
