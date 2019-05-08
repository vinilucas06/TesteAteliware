using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalTest.Data;
using PortalTest.Interface;
using PortalTest.Models;

namespace PortalTest.Controllers
{
    public class ListarController : Controller
    {

        private readonly IGitRepositorieRepository _gitRepositorieRepository;

        public ListarController(IGitRepositorieRepository gitRepositorieRepository)
        {
            _gitRepositorieRepository = gitRepositorieRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<GitRepositorie> model = await _gitRepositorieRepository.Listar();
            return View("Listar", model);
        }

        public IActionResult Detalhe(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return RedirectToAction("IndexDb", "Detalhe", new { id });
        }

    }
}