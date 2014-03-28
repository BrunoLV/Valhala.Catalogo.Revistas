using Catalogo.Revistas.Biblioteca.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Revistas.Biblioteca.Repository
{
    public class RevistaRepository : BaseRepository<Revista>, IRevistaRepository
    {

        public RevistaRepository(ISession session)
        {
            this.session = session;
        }

    }
}
