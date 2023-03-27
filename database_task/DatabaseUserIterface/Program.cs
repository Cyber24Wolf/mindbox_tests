using DatabaseInteractionLibrary;

namespace DatabaseUserIterface
{
    public class Program
    {
        public class ProgramState
        {
            public MSDatabase Database { get; private set; }
            public DialogWithUserHandler DialogWithUserHandler { get; private set; }

            public ProgramState(MSDatabase database, DialogWithUserHandler dialogWithUserHandler)
            {
                Database = database;
                DialogWithUserHandler = dialogWithUserHandler;
            }
        }

        public static ProgramState CurrentState { get; private set; }

        public static void Main(string[] args)
        {
            CurrentState = new ProgramState(new MSDatabase(), new DialogWithUserHandler());

            var reconnectCommand = new ReconnectToServerCommand(CurrentState);
            reconnectCommand.Proceed();

            ProceedUserCommands(CurrentState);
        }

        private static void ProceedUserCommands(ProgramState state)
        {            
            while (true)
            {
                var userResponce = state.DialogWithUserHandler.SendUserMessage<AskUserCommand, UserCommandResponce>(new AskUserCommand(), null);
                userResponce.UserCommand.Proceed();
            }
        }
    }
}
