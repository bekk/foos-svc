using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace foos_svc
{
    public class MatchesRespository
    {
        private SqlConnection dbConnection;

        public MatchesRespository(SqlConnection sqlConnection)
        {
            dbConnection = sqlConnection;
        }

        public IEnumerable<Matches> GetMatches()
        {
            string sql = "SELECT * from Match";
            IEnumerable<Matches> queryResult = dbConnection.Query<Matches>(sql);
            return queryResult;
        }

        public bool Add(Matches match)
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
