using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace MvcnetCoreUtilidades.Helpers
{
    public enum Folders { Images, Facturas, Uploads, Temporal}

    public class HelperPathProvider
    {
        private IWebHostEnvironment hostEnvironment;
        private IServer server;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment, IServer server)
        {
            this.hostEnvironment = hostEnvironment;
            this.server = server;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";

            switch (folder)
            {
                case Folders.Images:
                    carpeta = "images";
                    break;
                case Folders.Facturas:
                    carpeta = "facturas";
                    break;
                case Folders.Uploads:
                    carpeta = "uploads";
                    break;
                default:
                    carpeta = "temporal";
                    break;
            }

            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, fileName);
            return path;
        }

        public string GetPublicPath(string fileName, Folders folder)
        {
            string carpeta = "";

            // Determina la carpeta pública según el tipo de archivo
            switch (folder)
            {
                case Folders.Images:
                    carpeta = "images";
                    break;
                case Folders.Facturas:
                    carpeta = "facturas";
                    break;
                case Folders.Uploads:
                    carpeta = "uploads";
                    break;
                default:
                    carpeta = "temporal";
                    break;
            }

            // La ruta pública relativa accesible desde el navegador
            string publicPath = "/" + carpeta + "/" + fileName.ToLower();
            return publicPath;
        }

        public string MapPathUrl(string fileName, Folders folder)
        {
            string carpeta = "";

            switch (folder)
            {
                case Folders.Images:
                    carpeta = "images";
                    break;
                case Folders.Facturas:
                    carpeta = "facturas";
                    break;
                case Folders.Uploads:
                    carpeta = "uploads";
                    break;
                default:
                    carpeta = "temporal";
                    break;
            }

            var addresses = this.server.Features.Get<IServerAddressesFeature>().Addresses;

            string rootPath = this.hostEnvironment.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, fileName);
            return path;
        }

    }
}
