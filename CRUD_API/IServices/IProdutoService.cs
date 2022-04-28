using CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.IServices
{
    public interface IProdutoService 
    {
        IEnumerable<Produto> GetProduto();
        Produto GetProdutoById(int id);
        Produto AddProduto(Produto produto);
        Produto UpdateProduto(Produto produto);
        Produto DeleteProduto(int id);
    }
}
