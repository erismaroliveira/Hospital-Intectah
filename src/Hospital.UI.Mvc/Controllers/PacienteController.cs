using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.UI.MVC.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IPacienteServico _pacienteServico;
        public PacienteController(IPacienteServico pacienteServico)
        {
            _pacienteServico = pacienteServico;
        }

        public ActionResult Index()
        {
            var result = _pacienteServico.ConsultarTodos();
            return View(result);
        }

        public ActionResult Details(int id) =>
            View(_pacienteServico.ConsultarPorId(id));

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente paciente)
        {
            try
            {
                _pacienteServico.Inserir(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id) =>
            View(_pacienteServico.ConsultarPorId(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            try
            {
                _pacienteServico.Alterar(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id) =>
            View(_pacienteServico.ConsultarPorId(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Paciente paciente)
        {
            try
            {
                _pacienteServico.Excluir(paciente.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}