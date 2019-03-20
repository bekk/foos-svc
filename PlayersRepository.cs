using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace foos_svc
{
    public class PlayersRepository 
    {
        private SqlConnection dbConnection;

        public PlayersRepository(SqlConnection sqlConnection)
        {
            dbConnection = sqlConnection;
        }

        public IEnumerable<Player> GetAll()
        {
            string sql = "SELECT * FROM Player";
            IEnumerable<Player> queryResult = dbConnection.Query<Player>(sql);
            return queryResult;

        }

        public bool Add(Player player)
        {
            try
            {
                string sql = "INSERT INTO Player(Name) values(@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = dbConnection.Query<int>(sql, player).SingleOrDefault();
                player.EmployeeId = returnId;
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Update(Player player)
        {
            string sql = "UPDATE Player SET Name = @Name WHERE EmployeeId = @EmployeeId";
            var count = dbConnection.Execute(sql, player);
            return count > 0;
        }
    }
}
