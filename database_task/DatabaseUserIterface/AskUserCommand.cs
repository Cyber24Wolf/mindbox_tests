using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseUserIterface
{
    public class AskUserCommand : MessageToUser<UserCommandResponce>
    {
        public override string GetMessageText()
        {
            return "write one of this command:\n" +
                $"\t\"category_of [product]\" - for showing category of specific product\n" +
                $"\t\"category_of -all\" - for showing category of all products\n" +
                $"\t{ReconnectToServerCommand.GetSignatureDescription(reconnectToDefaultServer: true)}" +
                $"\t{ReconnectToServerCommand.GetSignatureDescription(reconnectToDefaultServer: false)}" +
                $"\t\"exit\" - exit from app\n";
        }

        public override UserCommandResponce ProceedUserResponce(string rawMessage)
        {
            Command userCommand = null;
            do
            {
                var splitResult = rawMessage.Split(' ');

                switch (splitResult[0])
                {
                    case "category_of":
                        break;
                    case "reconnect":
                        userCommand = new ReconnectToServerCommand(Program.CurrentState, splitResult);
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Unknown command. Look command signatures below");
                        continue;
                }
            }
            while (userCommand == null);

            return new UserCommandResponce(userCommand);
        }
    }

    public class UserCommandResponce : UserResponce
    {
        public Command UserCommand { get; private set; }

        public UserCommandResponce(Command userCommand)
        {
            UserCommand = userCommand;
        }
    }
}
