using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Revistas.Biblioteca.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ISession session;


        public void Inserir(T entidade)
        {
            this.session.Save(entidade);
        }

        public void Editar(T entidade)
        {
            this.session.Update(entidade);
        }

        public void Excluir(T entidade)
        {
            this.session.Delete(entidade);
        }

        public T BuscarPorId(int id)
        {
            return this.session.Get<T>(id);
        }

        public IList<T> ListarTudo()
        {
            return this.session.CreateCriteria<T>().List<T>();
        }
    }
}
