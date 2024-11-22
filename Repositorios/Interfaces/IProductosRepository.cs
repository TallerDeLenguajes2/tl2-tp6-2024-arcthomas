using System.Collections;
using espacioProductos;

namespace espacioInterfaz;

public interface IProductosRepository
{
Productos GetById(int id);
List<Productos> GetAll();
void Create(Productos producto);
void Update(Productos producto);
void Delete(int idUsuario);
} 