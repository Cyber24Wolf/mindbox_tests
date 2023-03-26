using System;
using DatabaseInteractionLibrary;

namespace DatabaseUserIterface
{
    public class Program
    {
        private const string LOCAL_SERVER_ID = "DESKTOP-RE1P6HN";
        private const string LOCAL_TABLE_ID = "products_to_categories";

        public static void Main(string[] args)
        {
            var database = new MSDatabase();
            var dialogHandler = new DialogWithUserHandler();
            
            Reconnect(database, dialogHandler, LOCAL_SERVER_ID, LOCAL_TABLE_ID);
        }

        private static bool Reconnect(MSDatabase database, DialogWithUserHandler dialogHandler, string serverId, string tableId)
        {
            var isConnected = database.CreateConnection(serverId, tableId);
            
            if (isConnected)
            {
                Console.WriteLine($"Succefully connect to {serverId}::{tableId}");
                return true;
            }
            else
            {
                Console.WriteLine($"Cant create connection with {serverId}::{tableId}");

                var userResponce = dialogHandler.Run(new MSServerConnectionMessageToUser());

                return Reconnect(database, dialogHandler, userResponce.ServerId, userResponce.TableId);
            }
        }
    }
}
