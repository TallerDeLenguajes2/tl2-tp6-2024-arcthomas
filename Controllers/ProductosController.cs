using Microsoft.AspNetCore.Mvc;
using espacioProductos;
using PresViewModel;

public class ProductosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Listar()
    {
        ProductosRepository repo = new ProductosRepository();
        List<Productos> listaProd = new List<Productos>();
        listaProd = repo.GetAll();
        return View(listaProd);
    }
    [HttpGet]
    public IActionResult Modificar()
    {
        ProductosRepository repo = new ProductosRepository();
        List<Productos> listaProd = new List<Productos>();
        listaProd = repo.GetAll();
        return View(listaProd);
    }
    [HttpPost]
    public IActionResult Crear(Productos producto)
    {
        if (!ModelState.IsValid)
        {
            TempData["Errors"] = ModelState.Values
                                           .SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList();
            return View("Index");
            Console.WriteLine("Error en la validación del modelo");
        }
        ProductosRepository repo = new ProductosRepository();
        repo.Create(producto);
        TempData["SuccessMessage"] = "Producto creado con éxito.";
        return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult ModificarOk(Productos producto)
    {
        ProductosRepository repo = new ProductosRepository();
        repo.Update(producto);
        return RedirectToAction("Modificar");
    }
    [HttpGet]
    public IActionResult Eliminar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Eliminar(int id)
    {
        ProductosRepository repo = new ProductosRepository();
        repo.Delete(id);
        return RedirectToAction("Index");
    }
}