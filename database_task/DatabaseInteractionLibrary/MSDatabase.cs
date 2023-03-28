using System;
using System.Data.SqlClient;

namespace DatabaseInteractionLibrary
{
    public class MSDatabase : IDatabase
    {
        private const string INTEGRATED_SECURITY = "True";
        private SqlConnection _connection;

        public bool CreateConnection(string serverId, string databaseId)
        {
            _connection = new SqlConnection($"Data Source={serverId};Initial Catalog={databaseId};Integrated Security={INTEGRATED_SECURITY}");
            return OpenConnetion();
        }

        public bool OpenConnetion()
        {
            if (_connection == null)
            {
                throw new CreateConnectionFirstException();
            }
            
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    _connection.Open();
                    return true;
                }
                catch (Exception exeption)
                {
                    throw exeption;
                }
            }

            return _connection.State == System.Data.ConnectionState.Open;
        }

        public void CloseConnection()
        {
            if (_connection == null)
            {
                throw new CreateConnectionFirstException();
            }

            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public class CreateConnectionFirstException : Exception { }
    }
}
