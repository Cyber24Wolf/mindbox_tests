using System;

namespace DatabaseUserIterface
{
    public class DialogWithUserHandler
    {
        public T Run<T>(MessageToUser<T> message) where T : UserResponce
        {
            T responce = null;

            do
            {
                Console.WriteLine($"Put {message.GetSignatureDescription()}");

                var input = Console.ReadLine();
                var splitResult = input.Split(' ');

                if (splitResult.Length == message.GetValuesCount())
                {
                    responce = message.ProceedCommand(splitResult);
                }
                else
                {
                    Console.WriteLine("Wrong input, try again");
                }

            } while (responce == null);

            return responce;
        }
    }
}
