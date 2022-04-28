using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Models
{
    public class ProdutosCategorias
    {
        [Key]
        public int ProdutosCategoriaId { get; set; }
        public int CategoriaId { get; set; }
        public int ProdutoId { get; set; }
    }


    public class ProdutosCategoriasValidator : AbstractValidator<ProdutosCategorias>
    {

        public ProdutosCategoriasValidator()
        {
            RuleFor(x => x.CategoriaId)
                .NotNull().WithMessage("Categoria não pode ser nula")
                .NotEmpty().WithMessage("Categoria não pode ser vazia");

            RuleFor(x => x.ProdutoId)
                .NotNull().WithMessage("Produto não pode ser nula")
                .NotEmpty().WithMessage("Produto não pode ser vazia"); 
        }

    }
}
