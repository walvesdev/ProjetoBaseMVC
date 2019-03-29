using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoBase.AcessoDados;
using ProjetoBaseMVC.Dados.AcessoDados.Repositorios;
using ProjetoBaseMVC.Model.Models;
using ProjetoBaseMVC.Services.Filters;

namespace ProjetoBaseMVC.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EmpresaRepositorio _context;

        public EmpresaController(EmpresaRepositorio context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.SelecionarTodos());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = _context.SelecionarPorId(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ModelStateValidator]
        public IActionResult Create([Bind("Id,Nome,DataFundacao")] Empresa empresa)
        {
            _context.Inserir(empresa);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa =  _context.SelecionarPorId(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,DataFundacao")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Atualizar(empresa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = _context.SelecionarPorId(id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var empresa =  _context.SelecionarPorId(id);
            _context.Excluir(empresa);

            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.dbset.Where(e => e.Id == id).Any();
        }
    }
}
