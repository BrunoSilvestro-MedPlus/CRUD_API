using CRUD_API.IServices;
using CRUD_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Services
{
    public class CategoriaService : ICategoriaService
    {
        CrudContext dbContext;
        public CategoriaService(CrudContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Categoria> GetCategoria()
        {
            var categoria = dbContext.Categorias.ToList();
            return categoria;
        }


        public Categoria AddCategoria(Categoria categoria)
        {
            if (categoria != null)
            {
                dbContext.Categorias.Add(categoria);
                dbContext.SaveChanges();
                return categoria;
            }
            return null;
        }

        public Categoria UpdateCategoria(Categoria categoria)
        {
            dbContext.Entry(categoria).State = EntityState.Modified;
            dbContext.SaveChanges();
            return categoria;
        }

        public Categoria DeleteCategoria(int id)
        {
            var categoria = dbContext.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            dbContext.Entry(categoria).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return categoria;
        }

        public Categoria GetCategoriaById(int id)
        {
            var categoria = dbContext.Categorias.FirstOrDefault(x => x.CategoriaId == id);
            return categoria;
        }
    }
}
