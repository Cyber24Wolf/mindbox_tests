using System;

namespace DatabaseUserIterface
{
    public class ReconnectToServerCommand : Command
    {
        private const string LOCAL_SERVER_ID = "DESKTOP-RE1P6HN";
        private const string LOCAL_DATABASE_ID = "products_to_categories";
        private const int SERVER_ID_INDEX = 1;
        private const int DATABASE_ID_INDEX = 2;

        public string ServerId { get; private set; }
        public string DatabaseId { get; private set; }

        private Program.ProgramState _programState;

        public ReconnectToServerCommand(Program.ProgramState programState, string serverId, string databaseId)
        {
            ServerId = serverId;
            DatabaseId = databaseId;

            _programState = programState;
        }

        public ReconnectToServerCommand(Program.ProgramState programState, string[] splittedString) : 
                    this(programState, SplittedStringArgsHandler.GetArgValueFromRawString(splittedString, SERVER_ID_INDEX, LOCAL_SERVER_ID),
                                       SplittedStringArgsHandler.GetArgValueFromRawString(splittedString, DATABASE_ID_INDEX, LOCAL_DATABASE_ID))
        {
        }

        public ReconnectToServerCommand(Program.ProgramState programState) : this(programState, LOCAL_SERVER_ID, LOCAL_DATABASE_ID)
        {
        }

        public override void Proceed()
        {
            Reconnect(_programState, ServerId, DatabaseId);
        }

        private void Reconnect(Program.ProgramState programState, string serverId, string databaseId)
        {
            var isConnected = programState.Database.CreateConnection(serverId, databaseId);

            if (isConnected)
            {
                Console.WriteLine($"Succefully connect to {serverId}::{databaseId}");
            }
            else
            {
                Console.WriteLine($"Cant create connection with {serverId}::{databaseId}");
                programState.DialogWithUserHandler.SendUserMessage<MSServerConnectionMessageToUser, MSServerConnectionUserResponce>(
                    new MSServerConnectionMessageToUser(),
                    onResponce: responce =>
                    {
                        Reconnect(programState, responce.ServerId, responce.DatabaseId);
                    });
            }
        }

        public static string GetSignatureDescription(bool reconnectToDefaultServer)
        {
            return reconnectToDefaultServer ? "\"reconnect\" - for reconnect to default database on default server" :
                                              "\"reconnect [server-id] [database-id]\" - for reconnect to database on server";
        }
    }
}
