using DapperExtensions;
using Npgsql;
using System.Data;

namespace Shared.Data
{
    public class PostgresDB : FactoryConnection
    {
        public IDbConnection Create()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.PostgreSqlDialect();

            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = "localhost";
            sb.Username = "postgres";
            sb.Password = "postgres";
            sb.Database = "armazem";
            sb.Port = 5432;
            sb.Timeout = 90;

            var conexao = new NpgsqlConnection(sb.ConnectionString);
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao conectar no banco.", ex);
            }
            return conexao;
        }
    }

    public interface FactoryConnection 
    {
        IDbConnection Create();
    }  
}
