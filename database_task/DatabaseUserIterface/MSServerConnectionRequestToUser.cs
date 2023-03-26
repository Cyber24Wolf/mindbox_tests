using System;

namespace DatabaseUserIterface
{
    public class MSServerConnectionRequestToUser
    {

        private const int SERVER_ID_INDEX = 0;
        private const int TABLE_ID_INDEX = 1;

        public MSServerConnectionRequestToUser()
        {            
        }

        public MSServerConnectionUserResponce Send()
        {
            MSServerConnectionUserResponce responce = null;

            do
            {
                Console.WriteLine("Put [server_id] [table_id]");

                var input = Console.ReadLine();
                var splitResult = input.Split(' ');

                if (splitResult.Length == 2)
                {
                    responce = new MSServerConnectionUserResponce(splitResult[SERVER_ID_INDEX], splitResult[TABLE_ID_INDEX]);
                }
                else
                {
                    Console.WriteLine("Wrong input, try again");
                }

            } while (responce == null);

            return responce;
        }
    }

    public class MSServerConnectionUserResponce
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
