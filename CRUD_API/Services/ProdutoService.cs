using Microsoft.EntityFrameworkCore;
using CRUD_API.IServices;
using CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Services
{
    public class ProdutoService : IProdutoService
    {
        CrudContext dbContext;
        public ProdutoService(CrudContext _db)
        {
            dbContext = _db;
        }

        public IEnumerable<Produto> GetProduto()
        {
            var produto = dbContext.Produtos.ToList();
            return produto;
        }


        public Produto AddProduto(Produto produto)
        {
            if (produto.Data <= DateTime.Now)
            {
                dbContext.Produtos.Add(produto);
                dbContext.SaveChanges();
                return produto;
            }
            return null;
        }

        public Produto UpdateProduto(Produto produto)
        {
            dbContext.Entry(produto).State = EntityState.Modified;
            dbContext.SaveChanges();
            return produto;
        }

        public Produto DeleteProduto(int id)
        {
            var produto = dbContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            dbContext.Entry(produto).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return produto;
        }

        public Produto GetProdutoById(int id)
        {
            var produto = dbContext.Produtos.FirstOrDefault(x => x.ProdutoId == id);
            return produto;
        }
    }
}
