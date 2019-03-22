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
            string sql = "SELECT * from Matches";
            IEnumerable<Matches> queryResult = dbConnection.Query<Matches>(sql);
            return queryResult;
        }

        public int Add()
        {
            string sql = "INSERT INTO Matches DEFAULT VALUES; SELECT CAST(SCOPE_IDENTITY() as int)";
            var returnId = dbConnection.Query<int>(sql).SingleOrDefault();
            return returnId;
        }
    }
}
