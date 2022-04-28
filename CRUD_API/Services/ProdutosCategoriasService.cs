using CRUD_API.IServices;
using CRUD_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Services
{
    public class ProdutosCategoriasService : IProdutosCategoriasService
    {
        CrudContext dbContext;
        public ProdutosCategoriasService(CrudContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<ProdutosCategorias> GetProdutoCategoria()
        {
            var produtosCategorias = dbContext.ProdutosCategorias.ToList();
            return produtosCategorias;
        }


        public ProdutosCategorias AddProdutoCategoria(ProdutosCategorias produtosCategorias)
        {
            if (produtosCategorias != null)
            {
                dbContext.ProdutosCategorias.Add(produtosCategorias);
                dbContext.SaveChanges();
                return produtosCategorias;
            }
            return null;
        }

        public ProdutosCategorias UpdateProdutoCategoria(ProdutosCategorias produtosCategorias)
        {
            dbContext.Entry(produtosCategorias).State = EntityState.Modified;
            dbContext.SaveChanges();
            return produtosCategorias;
        }

        public ProdutosCategorias DeleteProdutoCategoria(int id)
        {
            var produtosCategorias = dbContext.ProdutosCategorias.FirstOrDefault(x => x.CategoriaId == id);
            dbContext.Entry(produtosCategorias).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return produtosCategorias;
        }

        public ProdutosCategorias GetProdutoCategoriaByProdutoId(int id)
        {
            var produtosCategorias = dbContext.ProdutosCategorias.FirstOrDefault(x => x.ProdutoId == id);
            return produtosCategorias;
        }
    }
}

