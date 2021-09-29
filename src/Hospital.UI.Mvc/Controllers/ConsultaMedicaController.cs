using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hospital.Domain.Entidades;
using Hospital.Domain.Interfaces.Servicos;
using Hospital.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Hospital.UI.Mvc.Controllers
{
    public class ConsultaMedicaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConsultaMedicaServico _consultaMedica;
        private readonly IPacienteServico _pacienteServico;
        private readonly IExameServico _exameServico;
        public ConsultaMedicaController(IMapper mapper,
                                        IConsultaMedicaServico consultaMedica,
                                        IPacienteServico pacienteServico,
                                        IExameServico exameServico)
        {
            _mapper = mapper;
            _consultaMedica = consultaMedica;
            _pacienteServico = pacienteServico;
            _exameServico = exameServico;
        }

        public ActionResult Index() =>
        //var result = _consultaMedica.ConsultarTodos();
            //var paciente = _pacienteServico.ConsultarPorCpf(cpf);
            //if (!string.IsNullOrEmpty(Pesquisa))
            //{

            //}

             View(_consultaMedica.ConsultarTodos());

        

        public ActionResult Create()
        {
            ViewBag.Pacientes = this.ObterPacientes();
            ViewBag.Exames = this.ObterExames();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultaMedicaViewModel consulta)
        {
            try
            {
                if (_consultaMedica.ValidarSeExisteConsultaData(consulta.DataHoraExame))
                {
                    return View();
                }
                var entity = _mapper.Map<ConsultaMedica>(consulta);
                _consultaMedica.Inserir(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> ObterPacientes() =>
            _pacienteServico.ConsultarTodos()
                .Select(c => new SelectListItem()
                {
                    Text = c.Nome,
                    Value = c.Id.ToString()
                })
                .ToList();

        private IEnumerable<SelectListItem> ObterExames() =>
            _exameServico.ConsultarTodos()
                .Select(c => new SelectListItem()
                {
                    Text = c.Nome,
                    Value = c.Id.ToString()
                })
                .ToList();
    }
}