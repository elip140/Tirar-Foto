using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TirarFoto.FotosService;
using TirarFoto.Models;

namespace Tirar_Foto_DOTNET.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    [BindProperty]
    public Foto NewFoto {get; set;} = new();

    public List<Foto> Lista = FotosList.GetAll();

    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if(!ModelState.IsValid)
        {
            return Page();
        }
            FotosList.Add(NewFoto);
            return RedirectToAction("Get");
    }
}
