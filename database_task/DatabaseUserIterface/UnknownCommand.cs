using System;

namespace DatabaseUserIterface
{
    public class UnknownCommand : Command
    {
        public override void Proceed()
        {
            Console.WriteLine("Unknown command. Look command signatures below");
        }
    }
}
