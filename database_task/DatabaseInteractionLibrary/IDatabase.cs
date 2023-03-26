namespace DatabaseInteractionLibrary
{
    public interface IDatabase
    {
        bool CreateConnection(string serverId, string databaseId);
        bool OpenConnetion();
        void CloseConnection();
    }
}
