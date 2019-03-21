using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace foos_svc
{
    public class ScoresRepository
    {
        private SqlConnection dbConnection;

        public ScoresRepository(SqlConnection sqlConnection)
        {
            dbConnection = sqlConnection;
        }

        public IEnumerable<Scores> GetScores()
        {
            string sql = "SELECT * FROM Scores";
            IEnumerable<Scores> queryResult = dbConnection.Query<Scores>(sql);
            return queryResult;
        }

        public bool Add(Scores score)
        {
            try
            {
                string sql = "INSERT INTO Scores(MatchId, IsWhite, Score) values(@MatchId, @IsWhite, @Score); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = dbConnection.Query<int>(sql, score).SingleOrDefault();
                //score.MatchId = returnId;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
