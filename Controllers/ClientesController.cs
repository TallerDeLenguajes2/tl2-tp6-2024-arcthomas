using Microsoft.AspNetCore.Mvc;
using espacioP;

public class ClienteController : Controller 
{
    public IActionResult Index()
    {
        return View();
    }
}