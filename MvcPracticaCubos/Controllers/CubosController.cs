using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MvcPracticaCubos.Models;
using MvcPracticaCubos.Repositories;

namespace MvcPracticaCubos.Controllers
{
    public class CubosController : Controller
    {
        public RepositoryCubos repo;
        private IMemoryCache cache;

        public CubosController(RepositoryCubos repo, IMemoryCache cache)
        {
            this.repo = repo;
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            List<Cubo> cubos = await this.repo.GetCubosAsync();
            return View(cubos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Cubo cubito = await this.repo.BuscarCuboAsync(id);
            return View(cubito);
        }
    }
}
