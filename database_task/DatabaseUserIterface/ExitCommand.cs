using System;

namespace DatabaseUserIterface
{
    public class ExitCommand : Command
    {
        public override void Proceed()
        {
            Environment.Exit(0);
        }

        public static string GetSignatureDescription()
        {
            return "\"exit\" - exit from app";
        }
    }
}
