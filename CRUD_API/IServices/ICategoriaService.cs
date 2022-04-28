using CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.IServices
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> GetCategoria();
        Categoria GetCategoriaById(int id);
        Categoria AddCategoria(Categoria categoria);
        Categoria UpdateCategoria(Categoria categoria);
        Categoria DeleteCategoria(int id);
    }
}
