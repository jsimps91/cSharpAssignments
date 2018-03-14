using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using demo.Models;
 
namespace DapperApp.Factory
{
    public class CohortFactory : IFactory<Cohort>
    {
        private string connectionString;
        public CohortFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=demo;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
    }
}