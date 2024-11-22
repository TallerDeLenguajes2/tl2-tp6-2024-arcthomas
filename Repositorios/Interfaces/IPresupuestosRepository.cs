using System.Collections;
using espacioP;
using espacioProductos;

namespace espacioInterfaz;

public interface IPresupuestosRepository
{
Presupuestos GetById(int id);
List<Presupuestos> GetAll(); 
void Create(Presupuestos producto);
void Update(Presupuestos producto);
void Delete(int id);
} 