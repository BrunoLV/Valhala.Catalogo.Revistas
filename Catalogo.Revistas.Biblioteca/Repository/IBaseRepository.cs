using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Revistas.Biblioteca.Repository
{
    public interface IBaseRepository<T>
    {
        void Inserir(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        IList<T> ListarTudo();
    }
}
