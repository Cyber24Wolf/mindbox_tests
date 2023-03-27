using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
