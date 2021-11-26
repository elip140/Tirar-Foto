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

    public List<Foto> Lista = new();
    public Foto Placeholder = new();

    [BindProperty]
    public Foto NewFoto { get; set; } = new();

    public void OnGet()
    {
        Placeholder = FotosList.Get(2);
        Lista = FotosList.GetAll();
    }
}
