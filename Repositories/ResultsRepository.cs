using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace foos_svc
{
    public class ResultsRepository
    {
        private SqlConnection dbConnection;
        public ResultsRepository(SqlConnection sqlConnection)
        {
            dbConnection = sqlConnection;
        }

        public IEnumerable<CompleteDataModel> GetResults()
        {
            string sql = "SELECT m.MatchId, m.Date, t.Name,t.IsWhite,s.Score " +
                "FROM Matches m JOIN Teams t ON t.MatchId = m.MatchId " +
                "JOIN Scores s ON s.MatchId = m.MatchId AND s.IsWhite = t.IsWhite";
            IEnumerable<CompleteDataModel> queryResult = dbConnection.Query<CompleteDataModel>(sql);
            return queryResult;
        }

    }
}
