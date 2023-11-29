using System.Data;
using System.Runtime.CompilerServices;
using Api_Filme.Infrastructure.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;

namespace Api_Filme.Testes.TesteData
{
    public class DataBaseConnectionTesteBasicosConexao
    {
        private string conectionString;
        private MySqlConnection _connection;
       

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            conectionString = "Server=localhost;Port= 3306;Database=ClienteCinema;Uid=root;";
            _connection = new MySqlConnection(conectionString);    
        }


        [Test]
        public void Deve_Conectar_Ao_Banco_De_Dados_Usando_Dapper()
        {
            _connection.Open();

            Assert.IsTrue(_connection.State == ConnectionState.Open);// Verificar se a conexão com o banco de dados está aberta
        }

        [Test]
        public void Deve_fechar_Conexao_Do_Banco_de_Dados_Usando_Dapper()
        {
            _connection.Close();

            Assert.IsTrue(_connection.State == ConnectionState.Closed);// Verificar se a conexão esta fechada
        }

        [Test]
        public void Deve_Estar_Conectando()
        {
            _connection.Open();

            // Verificar se a conexão está aberta
            Assert.IsTrue(_connection.State == ConnectionState.Open);

            var result = _connection.QueryFirstOrDefault<int>("SELECT duracao FROM Filme");

            Assert.IsNotNull(result);

            _connection.Close();
        }


    }
}
