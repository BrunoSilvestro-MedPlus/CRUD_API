using CRUD_API.IServices;
using CRUD_API.Models;
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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService categoriaservice;
        public CategoriaController(ICategoriaService categoria)
        {
            categoriaservice = categoria;
        }


        [HttpGet]        
        [Route("[action]")]        
        public IEnumerable<Categoria> GetCategoria()
        {
            return categoriaservice.GetCategoria();
        }

        [HttpPost]
        [Route("[action]")]        
        public Categoria AddCategoria(Categoria categoria)
        {
            CategoriaValidator validator = new CategoriaValidator();
            ValidationResult results = validator.Validate(categoria);
            if (!results.IsValid)
            {
                string allMessages = results.ToString("~");
            }
            return categoriaservice.AddCategoria(categoria);
        }

        [HttpPut]
        [Route("[action]")]        
        public Categoria EditCategoria(Categoria categoria)
        {
            CategoriaValidator validator = new CategoriaValidator();
            ValidationResult results = validator.Validate(categoria);
            if (!results.IsValid)
            {
                string allMessages = results.ToString("~");
            }
            return categoriaservice.UpdateCategoria(categoria);
        }

        [HttpDelete]
        [Route("[action]")]
        public Categoria DeleteCategoria(int id)
        {
            return categoriaservice.DeleteCategoria(id);
        }


        [HttpGet]
        [Route("[action]")]      
        public Categoria GetCategoriaId(int id)
        {
            return categoriaservice.GetCategoriaById(id);
        }
    }
}
