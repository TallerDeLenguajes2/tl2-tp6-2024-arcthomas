using Microsoft.AspNetCore.Mvc;
using espacioP;
using PresViewModel;

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
    [HttpGet]
    public IActionResult Crear()
    {
        ClientesRepository repo = new ClientesRepository();
        var clientes = repo.GetAll(); // Obtén la lista de clientes
        var model = new PresupuestoViewModel()
        {
            FechaCreacion = DateTime.Now,
            Clientes = clientes
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult CrearOk(Presupuestos presupuesto)
    {
        PresupuestosRepository repo = new PresupuestosRepository();
        repo.Create(presupuesto);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult ModificarOk(Presupuestos presupuesto)
    {
        PresupuestosRepository repo = new PresupuestosRepository();
        repo.Update(presupuesto);
        return RedirectToAction("Modificar");
    }
}