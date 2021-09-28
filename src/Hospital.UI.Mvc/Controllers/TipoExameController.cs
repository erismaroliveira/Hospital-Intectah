using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.UI.MVC.Controllers
{
    public class TipoExameController : Controller
    {
        private readonly ITipoExameServico _servico;

        public TipoExameController(ITipoExameServico servico)
        {
            _servico = servico;
        }

        // GET: TipoExameController
        public ActionResult Index()
        {
            var result = _servico.ConsultarTodos();
            return View(result);
        }

        // GET: TipoExameController/Details/5
        public ActionResult Details(int id) =>
            View(_servico.ConsultarPorId(id));

        // GET: TipoExameController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoExameController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoExame tipoExame)
        {
            try
            {
                _servico.Inserir(tipoExame);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoExameController/Edit/5
        public ActionResult Edit(int id) =>
            View(_servico.ConsultarPorId(id));

        // POST: TipoExameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoExame tipoExame)
        {
            try
            {
                _servico.Alterar(tipoExame);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id) =>
            View(_servico.ConsultarPorId(id));

        // POST: TipoExameController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoExame tipoExame)
        {
            try
            {
                _servico.Excluir(tipoExame.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}