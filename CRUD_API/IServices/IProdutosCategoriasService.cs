using CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.IServices
{
    public interface IProdutosCategoriasService
    {
        IEnumerable<ProdutosCategorias> GetProdutoCategoria();
        ProdutosCategorias GetProdutoCategoriaByProdutoId(int id);
        ProdutosCategorias AddProdutoCategoria(ProdutosCategorias produtosCategorias);
        ProdutosCategorias UpdateProdutoCategoria(ProdutosCategorias produtosCategorias);
        ProdutosCategorias DeleteProdutoCategoria(int id);
    }
}
