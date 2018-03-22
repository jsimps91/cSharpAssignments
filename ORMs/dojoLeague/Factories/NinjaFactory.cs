using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using dojoLeague.Models;
namespace dojoLeague.Factory
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;

        public NinjaFactory()
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

        public void Add(Ninja ninja)
        {
            using (IDbConnection dbConnection = Connection)
            {
                if (ninja.dojo_id == 0)
                {
                    string query = "INSERT INTO ninjas(name, level, description) VALUES (@name, @level, @description)";
                    dbConnection.Open();
                    dbConnection.Execute(query, ninja);
                }
                else
                {
                    string query = "INSERT INTO ninjas(name, level, dojo_id, description) VALUES (@name, @level, @dojo_id, @description)";
                    dbConnection.Open();
                    dbConnection.Execute(query, ninja);
                }

            }
        }
        public IEnumerable<Ninja> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT dojos.name as dojo_name, dojo_id, ninjas.id, ninjas.name FROM ninjas LEFT JOIN dojos ON ninjas.dojo_id = dojos.id");
            }
        }
        public Ninja FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT dojos.name as dojo_name, description, ninjas.id, ninjas.name, ninjas.level, dojo_id FROM ninjas JOIN dojos WHERE ninjas.dojo_id = dojos.id AND ninjas.id = @Id", new { Id = id }).FirstOrDefault();
              
            }
        }
        public Ninja FindRogueNinjaByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE id= @Id", new { Id = id }).FirstOrDefault();
              
            }
        }
        public IEnumerable<Ninja> FindByDojo(int dojo_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE dojo_id = @Dojo_id", new { Dojo_id = dojo_id });
            }
        }
        public IEnumerable<Ninja> FindRogueNinjas()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE dojo_id is null");
            }
        }
        public void Banish(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojo_id = null WHERE id = {id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void Recruit(int id, int dojo_id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojo_id = {dojo_id} WHERE id = {id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }

    }
}