namespace DatabaseUserIterface
{
    public abstract class MessageToUser<T> where T : UserResponce
    {
        public abstract string GetMessageText();

        public abstract T ProceedUserResponce(string rawMessage);
    }

    public abstract class UserResponce
    {
    }
}
