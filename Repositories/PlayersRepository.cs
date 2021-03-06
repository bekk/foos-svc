﻿using System;
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
            IEnumerable<Players> queryResult = dbConnection.Query<Players>(sql);
            return queryResult;
        }

        public bool Add(Players player)
        {
            try
            {
                string sql = "INSERT INTO Players(Name, EmployeeId) values(@Name, @EmployeeId); SELECT CAST(SCOPE_IDENTITY() as int)";
                var returnId = dbConnection.Query<string>(sql, player).SingleOrDefault();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
