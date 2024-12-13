using Microsoft.AspNetCore.Mvc;
using espacioP;

public class PresupuestosController : Controller 
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Listar()
    {
        PresupuestosRepository repo = new PresupuestosRepository();
        List<Presupuestos> listaPres = new List<Presupuestos>();
        listaPres = repo.GetAll();
        return View(listaPres);
    }
    [HttpGet]
    public IActionResult Modificar()
    {
        PresupuestosRepository repo = new PresupuestosRepository();
        List<Presupuestos> listaPres = new List<Presupuestos>();
        listaPres = repo.GetAll();
        return View(listaPres);
    }
    [HttpPost]
    public IActionResult ModificarOk(Presupuestos presupuesto)
    {
        PresupuestosRepository repo = new PresupuestosRepository();
        repo.Update(presupuesto);
        return RedirectToAction("Modificar");
    }
}