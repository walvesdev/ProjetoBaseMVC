using FluentValidation;
using ProjetoBaseMVC.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoBaseMVC.Model.Models
{
    public class Empresa
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }


    }
}

