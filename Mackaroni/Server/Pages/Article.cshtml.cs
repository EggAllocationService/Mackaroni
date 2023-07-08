using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mackaroni.Server.Pages;

public class Article : PageModel
{
    public string ArticleName;
    public void OnGet([FromRoute] string name)
    {
        ArticleName = name;
    }
}