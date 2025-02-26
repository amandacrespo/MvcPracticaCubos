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

        #endregion

        #region COMPRAS
        #endregion
    }
}
