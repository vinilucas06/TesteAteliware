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
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PortalTest.Data;
using Microsoft.EntityFrameworkCore;
using PortalTest.Interface;

namespace PortalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGitRepositorieRepository _gitRepositorieRepository;

        public HomeController(IGitRepositorieRepository gitRepositorieRepository)
        {
            _gitRepositorieRepository = gitRepositorieRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            GitRepositorie model = new GitRepositorie();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Buscar(GitRepositorie model)
        {
            if (ModelState.IsValid)
            {

                var client = new GitHubClient(new Octokit.ProductHeaderValue("octokit"));

                var gorepos = await client.Search.SearchRepo(new SearchRepositoriesRequest()
                {
                    Language = (Language)Enum.Parse(typeof(Language), model.Language)
                });

                List<GitRepositorie> retorno = gorepos.Items.OrderByDescending(i => i.CreatedAt)
                     .OrderByDescending(i => i.StargazersCount)
                     .Take(50)
                     .Select(i => new GitRepositorie
                     {
                         Id = i.Id,
                         Name = i.Name,
                         Description = i.Description,
                         LastUpdated = i.UpdatedAt,
                         Url = i.HtmlUrl,
                         WatchCount = i.StargazersCount,
                         Language = i.Language
                     }).ToList();

                HttpContext.Session.SetString("listaprojeto", JsonConvert.SerializeObject(retorno));

                ViewBag.Resultado = retorno;
            }
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Detalhe(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Detalhe", new { id });
        }

        public async Task<IActionResult> Salvar(long id)
        {
            string session = HttpContext.Session.GetString("listaprojeto");
            if (String.IsNullOrEmpty(session) || id == 0)
            {
                return NotFound();
            }

            GitRepositorie model = new GitRepositorie();
            List<GitRepositorie> listaprojeto = JsonConvert.DeserializeObject<List<GitRepositorie>>(session);
            model = listaprojeto.Where(x => x.Id == id).FirstOrDefault();
            var repositorie = await _gitRepositorieRepository.ListarById(id);

            if (repositorie == null)
            {
                await _gitRepositorieRepository.Salvar(model);
            }

            return RedirectToAction("Index", "Listar", new { id });

        }


    }
}
