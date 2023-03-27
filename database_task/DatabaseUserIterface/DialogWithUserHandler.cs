using System;

namespace DatabaseUserIterface
{
    public class DialogWithUserHandler
    {
        public R SendUserMessage<M, R>(M message, Action<R> onResponce) 
            where R : UserResponce
            where M : MessageToUser<R>
        {
            Console.WriteLine(message.GetMessageText());

            R responce = null;
            do
            {
                var rawInput = Console.ReadLine();
                responce = message.ProceedUserResponce(rawInput);
            }
            while (responce == null);

            onResponce?.Invoke(responce);
            return responce;
        }
    }
}
