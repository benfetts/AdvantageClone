using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace AdvantageFramework.Core.Database
{
    public class DbContext : AdvantageFramework.Core.Database.DataContext
    {
        //private string _connectionString = "";

        //public string ConnectionString { get {
        //        return _connectionString;
        //    }
        //    set {
        //        _connectionString = value;
        //    }
        //}
        //public string UserCode { get; internal set; }
        public DbContext(string connectionString, string userCode) : base(connectionString, userCode)
        {

        }
        public DbContext(string connectionString) : base(connectionString,null)
        {
            //ConnectionString = connectionString;
        }
        //public DataTable Select(string storedProcedureorCommandText, bool isStoredProcedure = true)
        //{
        //    DataTable dataTable = new DataTable();
        //    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.StoredProcedure;
        //            if (!isStoredProcedure)
        //            {
        //                command.CommandType = CommandType.Text;
        //            }
        //            command.CommandText = storedProcedureorCommandText;
        //            connection.Open();
        //            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //            dataAdapter.Fill(dataTable);
        //            return dataTable;
        //        }
        //    }
        //}
        //public IEnumerable<T> ExecuteObject<T>(string storedProcedureorCommandText, bool isStoredProcedure = true)
        //{
        //    List<T> items = new List<T>();
        //    var dataTable = Select(storedProcedureorCommandText, isStoredProcedure); //this will use the DataTable Select function
        //    foreach (var row in dataTable.Rows)
        //    {
        //// ***  I CAN'T GET THIS PART TO WORK!!! ***
        //        T item = (T)Activator.CreateInstance(typeof(T), row);
        //        //items.Add(item);
        //        ////items.Add((T)Activator.CreateInstance(typeof(T), new object[] { dataTable.Rows }));
        //        items.Add((T)Activator.CreateInstance(typeof(T), new object[] { row }));
        //    }
        //    return items;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public bool SqlQueryBool(string CommandText)
        {
            Database.GetDbConnection().Open();

            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CommandText;
                command.CommandType = System.Data.CommandType.Text;

                return bool.Parse(command.ExecuteScalar().ToString());
            }
        }
        public short SqlQueryShort(string CommandText)
        {
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CommandText;
                command.CommandType = System.Data.CommandType.Text;

                return short.Parse(command.ExecuteScalar().ToString());
            }
        }
        public int SqlQueryInt(string CommandText)
        {
            Database.GetDbConnection().Open();

            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CommandText;
                command.CommandType = System.Data.CommandType.Text;

                return int.Parse(command.ExecuteScalar().ToString());
            }
        }
        public string[] SqlQueryString(string CommandText)
        {
            List<string> rc = new List<string>();
            Database.GetDbConnection().Open();

            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CommandText;
                command.CommandType = System.Data.CommandType.Text;

                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rc.Add(reader.GetString(0));
                }

                reader.Close();

            }

            return rc.ToArray();
        }

        public int ExecuteNonQuery(string CommandText)
        {
            if (Database.GetDbConnection().State != System.Data.ConnectionState.Open) 
            {
                Database.GetDbConnection().Open();
            }


            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = CommandText;
                command.CommandType = System.Data.CommandType.Text;

                int rc = command.ExecuteNonQuery();

                //Database.GetDbConnection().Close();

                return rc;
            }
        }
    }
}
