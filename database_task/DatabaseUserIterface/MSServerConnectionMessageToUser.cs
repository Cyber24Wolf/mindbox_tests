using System;

namespace DatabaseUserIterface
{
    public class MSServerConnectionMessageToUser : MessageToUser<MSServerConnectionUserResponce>
    {

        private const int SERVER_ID_INDEX = 0;
        private const int DATABASE_ID_INDEX = 1;

        public override string GetMessageText()
        {
            return "Put [server-id] [database-id]";
        }

        public override MSServerConnectionUserResponce ProceedUserResponce(string rawMessage)
        { 
            var splitResult = rawMessage.Split(' ');

            if (splitResult.Length == 2)
            {
                return new MSServerConnectionUserResponce(splitResult[SERVER_ID_INDEX], splitResult[DATABASE_ID_INDEX]);
            }
            else
            {
                Console.WriteLine($"Wrong input signature. {GetMessageText()}");
                return null;
            }
        }
    }

    public class MSServerConnectionUserResponce : UserResponce
    {
        public string ServerId { get; private set; }
        public string DatabaseId { get; private set; }

        public MSServerConnectionUserResponce(string serverId, string databaseId)
        {
            ServerId = serverId;
            DatabaseId = databaseId;
        }
    }
}
