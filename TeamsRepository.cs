using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace foos_svc
{
    public class TeamsRepository
    {
        private SqlConnection dbConnection;
        public TeamsRepository(SqlConnection sqlConnection)
        {
            dbConnection = sqlConnection;
        }

        public IEnumerable<Teams> GetTeams()
        {
            string sql = "SELECT * FROM Teams";
            IEnumerable<Teams> queryResult = dbConnection.Query<Teams>(sql);
            return queryResult;
        }

        public bool Add(Teams team)
        {
            try
            {
                string sql = "INSERT INTO Teams(MatchId, Name, IsWhite) values(@MatchId, @Name, @IsWhite); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = dbConnection.Query<int>(sql, team).SingleOrDefault();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
