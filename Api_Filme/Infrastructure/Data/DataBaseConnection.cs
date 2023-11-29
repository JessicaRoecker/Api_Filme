using System.Runtime.Intrinsics.X86;
using System;
using Dapper;
using MySql.Data.MySqlClient;
using static Google.Protobuf.WellKnownTypes.Field.Types;
using Npgsql;

namespace Api_Filme.Infrastructure.Data
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters)
        {
            string connectionString = _configuration.GetConnectionString("MysqlConnection");

            using (var con = new MySqlConnection(connectionString))
            {
                return await con.QueryAsync<T>(query, parameters);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameters)
        {
            string connectionString = _configuration.GetConnectionString("MysqlConnection");

            using (var con = new MySqlConnection(connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
        }

        public async Task<int> ExecuteAsync(string query, object parameters)
        {
            string connectionString = _configuration.GetConnectionString("MysqlConnection");

            using (var con = new MySqlConnection(connectionString))
            {
                return await con.ExecuteAsync(query, parameters);
            }
        }
    }
}
