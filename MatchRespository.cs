using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace foos_svc
{
    public class MatchRespository
    {
        private SqlConnection dbConnection;

        public MatchRespository(SqlConnection sqlConnection)
        {
            dbConnection = sqlConnection;
        }

        public IEnumerable<Match> GetMatches()
        {
            string sql = "SELECT * from Match";
            IEnumerable<Match> queryResult = dbConnection.Query<Match>(sql);
            return queryResult;
        }

        public bool Add(Match match)
        {
            try
            {
                string sql = "INSERT INTO Match(Name, IsWhite) values(@Name, @IsWhite); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = dbConnection.Query<int>(sql, match).SingleOrDefault();
                match.MatchId = returnId;
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
