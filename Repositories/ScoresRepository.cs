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

        public Scores Add(Scores score)
        {
                string sql = "INSERT INTO Scores(MatchId, IsWhite, Score) values(@MatchId, @IsWhite, @Score); SELECT * FROM Scores WHERE MatchId = @MatchId AND IsWhite = @IsWhite";
                return dbConnection.Query<Scores>(sql, score).SingleOrDefault();
        }

        public IEnumerable<Scores> Add(IEnumerable<Scores> scores)
        {
            var scoresList = new List<Scores>();
            foreach (var score in scores)
            {
                var newScore = Add(score);
                scoresList.Add(newScore);
            }
            return scoresList;
        }

    }
}
