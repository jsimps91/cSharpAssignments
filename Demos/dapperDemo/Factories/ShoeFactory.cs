using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dapperDemo.Models;
 
namespace dapperDemo.Factory
{
    public class ShoeFactory : IFactory<Shoe>
    {
        private string connectionString;
        public ShoeFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=Shoes;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public void Add(Shoe item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO shoes (brand, style, size) VALUES (@Brand, @Style, @Size)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Shoe> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Shoe>("SELECT * FROM shoes");
            }
        }
        public Shoe FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Shoe>("SELECT * FROM shoes WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}