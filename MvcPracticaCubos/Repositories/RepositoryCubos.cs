using Microsoft.EntityFrameworkCore;
using MvcPracticaCubos.Data;
using MvcPracticaCubos.Models;

namespace MvcPracticaCubos.Repositories
{
    public class RepositoryCubos
    {
        private PracticaContext context;

        public RepositoryCubos(PracticaContext context)
        {
            this.context = context;
        }

        #region CUBOS

        public async Task<List<Cubo>> GetCubosAsync()
        {
            var consulta = from datos in this.context.Cubos
                           select datos;

            return await consulta.ToListAsync();
        }

        public async Task<Cubo> BuscarCuboAsync(int id)
        {
            var consulta = from datos in this.context.Cubos
                           where datos.IdCubo == id
                           select datos;

            return await consulta.FirstOrDefaultAsync();
        }

        public async Task InsertarCuboAsync(string nombre, string modelo, string marca, string imagen, int precio)
        {
            int maxId = await this.context.Cubos.MaxAsync(x => x.IdCubo);

            Cubo c = new Cubo
            {
                IdCubo = maxId + 1,
                Nombre = nombre,
                Modelo = modelo,
                Marca = marca,
                Imagen = imagen,
                Precio = precio
            };

            await this.context.Cubos.AddAsync(c);
            await this.context.SaveChangesAsync();
        }

        public async Task ActualizarCuboAsync(int idCubo, string nombre, string modelo, string marca, string imagen, int precio)
        {
            Cubo cubo = await this.BuscarCuboAsync(idCubo);

            if (cubo != null)
            {
                cubo.Nombre = nombre;
                cubo.Modelo = modelo;
                cubo.Marca = marca;
                cubo.Imagen = imagen;
                cubo.Precio = precio;

                await this.context.SaveChangesAsync();
            }
        }

        public async Task BorrarCuboAsync(int id)
        {
            Cubo cubo = await this.BuscarCuboAsync(id);

            if (cubo != null)
            {
                this.context.Cubos.Remove(cubo);
                await this.context.SaveChangesAsync();
            }
        }

        #endregion

        #region COMPRAS
        #endregion
    }
}
