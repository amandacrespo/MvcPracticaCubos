using MvcPracticaCubos.Data;

namespace MvcPracticaCubos.Repositories
{
    public class RepositoryCubos
    {
        private PracticaContext context;

        public RepositoryCubos(PracticaContext context)
        {
            this.context = context;
        }

    }
}
