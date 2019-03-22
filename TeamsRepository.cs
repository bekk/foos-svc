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

        public Teams Add(Teams team)
        {
                string sql = "INSERT INTO Teams(MatchId, Name, IsWhite) values(@MatchId, @Name, @IsWhite); SELECT * FROM Teams WHERE MatchId = @MatchId AND Name = @Name";
                var returnTeam = dbConnection.Query<Teams>(sql, team).SingleOrDefault();
                return returnTeam;
        }

        public IEnumerable<Teams> Add(IEnumerable<Teams> teams)
        {

            var teamsList = new List<Teams>();
            foreach (var team in teams)
            {
                var newTeam =  Add(team);
                teamsList.Add(newTeam);
            }
            return teamsList;
        }

    }
}
