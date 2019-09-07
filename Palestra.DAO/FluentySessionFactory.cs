using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;

namespace Palestra.DAO
{
    public class FluentySessionFactory
    {
        
        private static ISessionFactory session;

        public static ISessionFactory CriarSessao()
        {
            if (ConfigurationManager.AppSettings["DBConnection"] == null)
                throw new System.Exception("ConnectionString não configurada na aplicação.");

            if (session != null)
                return session;

            string connectionString = ConfigurationManager.AppSettings["DBConnection"].ToString();

            IPersistenceConfigurer persistenceConfigurer = MsSqlConfiguration.MsSql7.ConnectionString(connectionString);

            var config = Fluently.Configure().Database(persistenceConfigurer).Mappings(x => x.FluentMappings.AddFromAssemblyOf<UsuarioMap>());
            session = config.BuildSessionFactory();
            return session;
        }

        public static ISession AbrirSessao()
        {
            if (session == null)
                session = CriarSessao();

            return session.OpenSession();
        }
    }
}
