using AutoMapper;
using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using Hospital.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.UI.MVC.Controllers
{
    public class ExameController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IExameServico _servico;
        private readonly ITipoExameServico _servicoTipoExame;

        public ExameController(IMapper mapper, IExameServico servico, ITipoExameServico servicoTipoExame)
        {
            _mapper = mapper;
            _servico = servico;
            _servicoTipoExame = servicoTipoExame;
        }

        // GET: ExameController
        public ActionResult Index() =>
            View(_servico.ConsultarTodos());

        // GET: ExameController/Details/5
        public ActionResult Details(int id) =>
            View(_servico.ConsultarPorId(id));

        // GET: ExameController/Create
        public ActionResult Create()
        {
            ViewBag.TiposExame = this.ObterTiposDeExames();
            return View();
        }

        // POST: ExameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExameViewModel exame)
        {
            try
            {
                var entity = _mapper.Map<Exame>(exame);
                _servico.Inserir(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExameController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TiposExame = this.ObterTiposDeExames();
            var result = _mapper.Map<ExameViewModel>(_servico.ConsultarPorId(id));
            return View(result);
        }

        // POST: ExameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExameViewModel exame)
        {
            try
            {
                var entity = _mapper.Map<Exame>(exame);
                _servico.Alterar(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExameController/Delete/5
        public ActionResult Delete(int id) =>
            View(_servico.ConsultarPorId(id));

        // POST: ExameController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Exame exame)
        {
            try
            {
                _servico.Excluir(exame.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> ObterTiposDeExames() =>
            _servicoTipoExame.ConsultarTodos()
                             .Select(c => new SelectListItem()
                             {
                                 Text = c.Nome,
                                 Value = c.Id.ToString()
                             })
                             .ToList();
    }
}