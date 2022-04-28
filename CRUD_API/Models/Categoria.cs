using FluentValidation;
using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_API.Models
{
    public partial class Categoria
    {
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }

    public class CategoriaValidator : AbstractValidator<Categoria>
    {

        public CategoriaValidator()
        {
            RuleFor(x => x.CategoriaNome).NotEmpty().WithMessage("nome não pode ser vazio")
                .NotNull().WithMessage("nome não pode ser nulo")
                .Length(1, 100).WithMessage("nome não pode possuir mais de 100 caracteres");
                       
        }

    }


}
