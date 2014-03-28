using Catalogo.Revistas.Biblioteca.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Revistas.Biblioteca.Repository.Util
{
    public abstract class HibernateUtil
    {
        private static string ConnectionString = "Server=localhost;Database=catalogo_4;Uid=root;Pwd=root;";
        private static ISessionFactory session;

        public static ISessionFactory CriarSession()
        {
            if (session != null)
            {
                return session;
            }

            IPersistenceConfigurer configDB = MySQLConfiguration.Standard.ConnectionString(ConnectionString);
            var configMap = Fluently.Configure().Database(configDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<RevistaMap>());
            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession AbrirSession()
        {
            return CriarSession().OpenSession();
        }
    }
}
