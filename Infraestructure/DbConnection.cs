using Infraestructure.Enum;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public sealed class DbConnection : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public DbConnection() { }

        public DbConnection(string connectionString, DatabaseType type)
        {
            Connection = GetConnection(connectionString, type);
        }

        //TODO: Implementar Transcation
        //CRIAR EXEMPLO

        ///Se você pretende reabrir esta mesma conexão futuramente, a melhor escolha é 
        ///utilizar o Close, caso contrário, utilizando o Dispose precisará gerar um novo objeto Connection.
        //Connection?.Dispose();
        //GC.SuppressFinalize(this);
        public void Dispose() => Connection?.Dispose();

        public void Close() => Connection?.Close();

        private static IDbConnection GetConnection(string connectionString, DatabaseType dbType)
        {
            return dbType switch
            {
                //DatabaseType.Oracle => new OracleConnection(connectionString),
                DatabaseType.SqlServer => new SqlConnection(connectionString),
                //DatabaseType.Mysql => new MySqlConnection(connectionString),
                _ => new SqlConnection(connectionString),
            };
        }

    }

}
