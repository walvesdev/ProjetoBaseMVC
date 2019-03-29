using ProjetoBase.AcessoDados;
using ProjetoBase.AcessoDados.Repositorios;
using ProjetoBaseMVC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseMVC.Dados.AcessoDados.Repositorios
{
    public class EmpresaRepositorio : Repositorio<Empresa, int?>
    {
        public EmpresaRepositorio(ApplicationContext context) : base(context)
        {
        }
    }
}
