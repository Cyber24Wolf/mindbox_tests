using System;

namespace DatabaseUserIterface
{
    public class MSServerConnectionMessageToUser : MessageToUser<MSServerConnectionUserResponce>
    {

        private const int SERVER_ID_INDEX = 0;
        private const int TABLE_ID_INDEX = 1;

        public MSServerConnectionMessageToUser()
        {            
        }

        public override string GetCommand()
        {
            return "reconnect";
        }

        public override string GetSignatureDescription()
        {
            return "[server-id] [table-id]";
        }

        public override int GetValuesCount()
        {
            return 2;
        }

        public override MSServerConnectionUserResponce ProceedCommand(string[] commandValues)
        {          
            return new MSServerConnectionUserResponce(commandValues[SERVER_ID_INDEX], commandValues[TABLE_ID_INDEX]);
        }

    }

    public class MSServerConnectionUserResponce : UserResponce
    {
        public string ServerId { get; private set; }
        public string TableId { get; private set; }

        public MSServerConnectionUserResponce(string serverId, string tableId)
        {
            ServerId = serverId;
            TableId = tableId;
        }
    }
}
