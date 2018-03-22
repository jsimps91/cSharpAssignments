using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojoLeague.Models;
namespace dojoLeague.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;

        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojoLeague;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<Dojo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
            }
        }
        public void Add(Dojo dojo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO dojos (name, location, info) VALUES (@name, @location, @info)";
                dbConnection.Open();
                dbConnection.Execute(query, dojo);
            }
        }
        public Dojo FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
        public Dojo FindDojoByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query =
                @"
        SELECT * FROM dojos WHERE id = @Id;
        SELECT * FROM ninjas where WHERE dojo_id = @Id;
        ";

                using (var multi = dbConnection.QueryMultiple(query, new { Id = id }))
                {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }
    }
}