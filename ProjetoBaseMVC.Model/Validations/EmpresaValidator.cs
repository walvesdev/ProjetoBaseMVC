using FluentValidation;
using ProjetoBaseMVC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseMVC.Model.Validations
{

    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Digite o nome da empresa!")
                .Length(0, 50).WithMessage("O nome pode conter no maxo 50 caracteres");
            RuleFor(x => x.DataFundacao)
                .NotEmpty().WithMessage("Digite a data de abertura da empresa!");
        }
    }
}