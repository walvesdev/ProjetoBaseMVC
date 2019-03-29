using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoBase.AcessoDados;
using ProjetoBaseMVC.Controllers;
using ProjetoBaseMVC.Dados.AcessoDados.Repositorios;
using ProjetoBaseMVC.Model.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace ProjetoBaseMVC.Teste
{
    public class EmpresaTeste : IDisposable
    {
        private ApplicationContext dbcontext;
        private EmpresaRepositorio context;
        private EmpresaController empresa;
        private List<Empresa> result;

        public EmpresaTeste(ApplicationContext dbcontext, EmpresaRepositorio context, EmpresaController empresa, List<Empresa> result):base()
        {
            this.dbcontext = dbcontext;
            this.context = context;
            this.empresa = empresa;
            this.result = result;
        }

        [Fact]
        public void ActionIndexRetorno()
        {
            //Assert.Throws<EqualException>(() => 
            //{
            //});
            //dbcontext = new ApplicationContext();
            //context = new EmpresaRepositorio(dbcontext);
            //empresa = new EmpresaController(context);
            var index = empresa.Index() as List<Empresa>;

            Assert.Equal(result, index);

        }

        public void Dispose()
        {
            dbcontext.Dispose();
            context.Dispose();
        }
    }
}
