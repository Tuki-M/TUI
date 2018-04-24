using FlightManager.Common.Constants;
using FlightManager.Common.Exceptions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Data
{
    /// <summary>
    /// Factory to create nhibernate sessions
    /// </summary>
    internal class DataSourceFactory
    {
        private string _connectionString = AppSetting.ConnectionString;
        
        public DataSourceFactory()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new FlightManagerException(Error.ConnectionStringEmpty);
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .UsingFile(_connectionString)
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataSourceFactory>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            if (!File.Exists(_connectionString))
            {
                var se = new SchemaExport(config);
                se.Create(false, true);
            }           
        }

    }
}
