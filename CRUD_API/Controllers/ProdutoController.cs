using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_API.IServices;
using CRUD_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoservice;
        public ProdutoController(IProdutoService produto)
        {
            produtoservice = produto;
        }


        [HttpGet]
        [Route("[action]")]        
        public IEnumerable<Produto> GetProduto()
        {
            return produtoservice.GetProduto();
        }

        [HttpPost]
        [Route("[action]")]
        public Produto AddProduto(Produto produto)
        {
            
            ProdutoValidator validator = new ProdutoValidator();
            ValidationResult results = validator.Validate(produto);
            if (! results.IsValid)
            {
                string allMessages = results.ToString("~");
            }
            return produtoservice.AddProduto(produto);
        }

        [HttpPut]
        [Route("[action]")]
        public Produto EditProduto(Produto produto)
        {
            ProdutoValidator validator = new ProdutoValidator();
            ValidationResult results = validator.Validate(produto);
            if (!results.IsValid)
            {
                string allMessages = results.ToString("~");
            }
            return produtoservice.UpdateProduto(produto);
        }

        [HttpDelete]
        [Route("[action]")]
        public Produto DeleteProduto(int id)
        {
            return produtoservice.DeleteProduto(id);
        }


        [HttpGet]
        [Route("[action]")]
        public Produto GetProdutoId(int id)
        {
            return produtoservice.GetProdutoById(id);
        }
    }
}
