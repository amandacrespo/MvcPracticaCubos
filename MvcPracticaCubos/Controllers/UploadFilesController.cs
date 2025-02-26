using Microsoft.AspNetCore.Mvc;
using MvcnetCoreUtilidades.Helpers;

namespace MvcnetCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {
        private HelperPathProvider helperPath;

        public UploadFilesController(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;
        }

        public IActionResult SubirFicheros()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirFicheros(IFormFile fichero)
        {
            string fileName = fichero.FileName;

            // Usar MapPath para obtener la ruta completa en el servidor
            string path = this.helperPath.MapPath(fileName, Folders.Images);

            // Guardar el archivo en el servidor
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }

            // Obtener la ruta pública accesible desde el navegador
            string publicPath = this.helperPath.GetPublicPath(fileName, Folders.Images);

            // Pasar la ruta pública al ViewBag para mostrarla en la vista
            ViewBag.Mensaje = "Fichero subido correctamente.";
            ViewBag.Path = publicPath;

            return View();
        }
    }
}
