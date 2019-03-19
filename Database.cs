using System;
using Dapper;
using DapperExtensions;
using System.Data.SqlClient;


namespace foos_svc
{
    internal class Database
    {
        internal static void Migrate(string connectionString)
        {
            //Migrer database her
            var connection = new SqlConnection(connectionString);
            string sql = System.IO.File.ReadAllText(@"./migrations/CreateTable.sql");

            connection.Execute(sql);
        }
    }
}