using CRUD_API.IServices;
using CRUD_API.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosCategoriasController : ControllerBase
    {
        private readonly IProdutosCategoriasService produtosCategoriasService;
        public ProdutosCategoriasController(IProdutosCategoriasService produtosCategorias)
        {
            produtosCategoriasService = produtosCategorias;
        }

        /// <summary>
        /// Retorna todos os ProdutosCategorias cadastrados.
        /// </summary>
       
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ProdutosCategorias> GetCategoria()
        {
            return produtosCategoriasService.GetProdutoCategoria();
        }


        /// <summary>
        /// Adiciona Categorias de Produtos
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///        
        ///     {       
        ///        "CategoriaId": 1,
        ///        "ProdutoId": 1
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Route("[action]")]
        public ProdutosCategorias AddCategoria(ProdutosCategorias produtosCategorias)
        {
            ProdutosCategoriasValidator validator = new ProdutosCategoriasValidator();
            ValidationResult results = validator.Validate(produtosCategorias);
            if (!results.IsValid)
            {
                string allMessages = results.ToString("~");
            }
            return produtosCategoriasService.AddProdutoCategoria(produtosCategorias);
        }

        [HttpPut]
        [Route("[action]")]
        public ProdutosCategorias EditCategoria(ProdutosCategorias produtosCategorias)
        {
            ProdutosCategoriasValidator validator = new ProdutosCategoriasValidator();
            ValidationResult results = validator.Validate(produtosCategorias);
            if (!results.IsValid)
            {
                string allMessages = results.ToString("~");
            }
            return produtosCategoriasService.UpdateProdutoCategoria(produtosCategorias);
        }

        [HttpDelete]
        [Route("[action]")]
        public ProdutosCategorias DeleteCategoria(int id)
        {
            return produtosCategoriasService.DeleteProdutoCategoria(id);
        }


        [HttpGet]
        [Route("[action]")]
        public ProdutosCategorias GetCategoriaId(int id)
        {
            return produtosCategoriasService.GetProdutoCategoriaByProdutoId(id);
        }
    }
}
