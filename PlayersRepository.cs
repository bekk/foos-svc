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

        public IEnumerable<Players> GetAll()
        {
            string sql = "SELECT * FROM Players";
            var t = dbConnection.Query<Players>(sql);
            IEnumerable<Players> queryResult = dbConnection.Query<Players>(sql);
            return queryResult;

        }

        public bool Add(Players player)
        {
            try
            {
                string sql = "INSERT INTO Players(Name) values(@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = dbConnection.Query<string>(sql, player).SingleOrDefault();
                player.EmployeeId = 1;
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Update(Players player)
        {
            string sql = "UPDATE Player SET Name = @Name WHERE EmployeeId = @EmployeeId";
            var count = dbConnection.Execute(sql, player);
            return count > 0;
        }
    }
}
