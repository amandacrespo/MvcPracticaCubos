using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MvcnetCoreUtilidades.Helpers;
using MvcPracticaCubos.Models;
using MvcPracticaCubos.Repositories;

namespace MvcPracticaCubos.Controllers
{
    public class CubosController : Controller
    {
        public RepositoryCubos repo;
        private IMemoryCache cache;
        private HelperPathProvider helperPath;

        public CubosController(RepositoryCubos repo, IMemoryCache cache, HelperPathProvider helperPath)
        {
            this.repo = repo;
            this.cache = cache;
            this.helperPath = helperPath;
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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string modelo, string marca, IFormFile imagen, int precio)
        {

            string fileName = imagen.FileName;

            string path = this.helperPath.MapPath(fileName, Folders.Cubos);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            await this.repo.InsertarCuboAsync(nombre, modelo, marca, fileName, precio);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Cubo cubito = await this.repo.BuscarCuboAsync(id);
            return View(cubito);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cubo cubicho)
        {
            await this.repo.ActualizarCuboAsync(cubicho.IdCubo, cubicho.Nombre, cubicho.Modelo, cubicho.Marca, cubicho.Imagen, cubicho.Precio);

            return RedirectToAction("Details", new { id = cubicho.IdCubo });

        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.BorrarCuboAsync(id);
            return RedirectToAction("Index");
        }
    }
}
