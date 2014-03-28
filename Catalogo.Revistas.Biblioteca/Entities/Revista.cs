using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Revistas.Biblioteca.Entities
{
    public class Revista
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string SubTitulo { get; set; }
        public virtual string Arco { get; set; }
        public virtual int Ano { get; set; }
        public virtual double Valor { get; set; }
    }
}
