using Catalogo.Revistas.Biblioteca.Entities;
using Catalogo.Revistas.Biblioteca.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Revistas.Biblioteca.Service
{
    public class RevistaService
    {
        private IRevistaRepository repository;

        public RevistaService(ISession session) 
        {
            this.repository = new RevistaRepository(session);
        }

        public void CadastrarRevista(Revista revista)
        {
            this.repository.Inserir(revista);
        }

        public void EditarRevista(Revista revista) 
        {
            this.repository.Editar(revista);
        }

        public void DeletarRevista(Revista revista)
        {
            this.repository.Excluir(revista);
        }

        public Revista BuscatPorId(int id)
        {
            return this.repository.BuscarPorId(id);
        }

        public IList<Revista> ListarTudo()
        {
            return this.repository.ListarTudo();
        }
    }
}
