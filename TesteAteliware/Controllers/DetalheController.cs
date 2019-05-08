using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Octokit;
using Octokit.Internal;
using PortalTest.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PortalTest.Data;
using Microsoft.EntityFrameworkCore;
using PortalTest.Interface;

namespace PortalTest.Controllers
{
    public class DetalheController : Controller
    {
        private readonly IGitRepositorieRepository _gitRepositorieRepository;

        public DetalheController(IGitRepositorieRepository gitRepositorieRepository)
        {
            _gitRepositorieRepository = gitRepositorieRepository;
        }

        public async Task<IActionResult> Index(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            GitRepositorie model = new GitRepositorie();
            string session = HttpContext.Session.GetString("listaprojeto");
            if (!String.IsNullOrEmpty(session))
            {
                List<GitRepositorie> listaRepositorie = JsonConvert.DeserializeObject<List<GitRepositorie>>(session);
                model = listaRepositorie.Where(x => x.Id == id).FirstOrDefault();
            }
          
            return View("Detalhe",model);
        }

        public async Task<IActionResult> IndexDb(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            GitRepositorie model = await _gitRepositorieRepository.ListarById(id);

            return View("Detalhe", model);
        }
    }
}