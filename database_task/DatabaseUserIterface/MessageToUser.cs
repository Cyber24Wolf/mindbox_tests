namespace DatabaseUserIterface
{
    public abstract class MessageToUser<T> where T : UserResponce
    {
        public abstract string GetCommand();

        public abstract T ProceedCommand(string[] commandValues);

        public abstract int GetValuesCount();

        public abstract string GetSignatureDescription();
    }

    public abstract class UserResponce
    {
    }
}
