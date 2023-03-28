using System;
using System.IO;
using System.Reflection;
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
            ValidateConnection();

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
            ValidateConnection();

            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void SendAllCategoriesQuery()
        {
            ValidateConnection();

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "DatabaseInteractionLibrary.Queries.SelectAllCategories.sql";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var query = reader.ReadToEnd();
                var command = new SqlCommand(query, _connection);

                var commandExecutionReader = command.ExecuteReader();

                while (commandExecutionReader.Read())
                {
                    Console.WriteLine($"product {commandExecutionReader.GetString(0)} category {commandExecutionReader.GetString(1)}");
                }
                commandExecutionReader.Close();
            }
        }

        private bool ValidateConnection()
        {
            if (_connection == null)
            {
                throw new CreateConnectionFirstException();
            }
            return true;
        }

        public class CreateConnectionFirstException : Exception { }
    }
}
