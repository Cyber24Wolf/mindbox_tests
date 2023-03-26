using System;
using DatabaseInteractionLibrary;

namespace DatabaseUserIterface
{
    public class Program
    {
        private const string LOCAL_SERVER_ID = "DESKTOP-RE1P6HN";
        private const string LOCAL_DATABASE_ID = "products_to_categories";

        public static void Main(string[] args)
        {
            var database = new MSDatabase();
            var dialogHandler = new DialogWithUserHandler();
            
            Reconnect(database, dialogHandler, LOCAL_SERVER_ID, LOCAL_DATABASE_ID);

            dialogHandler.WaitForUserCommand();
        }

        private static bool Reconnect(MSDatabase database, DialogWithUserHandler dialogHandler, string serverId, string databaseId)
        {
            var isConnected = database.CreateConnection(serverId, databaseId);
            
            if (isConnected)
            {
                Console.WriteLine($"Succefully connect to {serverId}::{databaseId}");
                return true;
            }
            else
            {
                Console.WriteLine($"Cant create connection with {serverId}::{databaseId}");
                MSServerConnectionUserResponce userResponce = dialogHandler.SendUserMessage<MSServerConnectionMessageToUser, MSServerConnectionUserResponce>(new MSServerConnectionMessageToUser());
                return Reconnect(database, dialogHandler, userResponce.ServerId, userResponce.DatabaseId);
            }
        }
    }
}
