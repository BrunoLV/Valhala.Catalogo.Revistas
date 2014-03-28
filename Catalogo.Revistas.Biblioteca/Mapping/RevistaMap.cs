using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Catalogo.Revistas.Biblioteca.Entities;

namespace Catalogo.Revistas.Biblioteca.Mapping
{
    public class RevistaMap : ClassMap<Revista>
    {
        public RevistaMap()
        {
            Table("tb_revista");
            Id(r => r.Id, "id");
            Map(r => r.Titulo, "titulo");
            Map(r => r.SubTitulo, "subtitulo");
            Map(r => r.Arco, "arco");
            Map(r => r.Ano, "ano");
            Map(r => r.Valor, "valor");
        }
    }
}
