using System;

namespace PatternTest.Structural.Bridge
{
    internal interface ISender
    {
        void Send(string message);
    }

    internal sealed class WebService : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine(message + " | Sending message using WebService");
        }
    }

    internal sealed class ThirdPartySender : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine(message + " | Sending message using ThirdParty API");
        }
    }

    internal abstract class MessageManager
    {
        public ISender Sender { protected get; set; }

        public MessageManager(ISender sender)
        {
            Sender = sender;
        }

        public virtual void Send(string message)
        {
            Sender.Send(message);
        }
    }

    internal sealed class SimpleMessageManager : MessageManager
    {
        public SimpleMessageManager(ISender sender) : base(sender)
        {
            Console.WriteLine("Using SimpleMessageManager");
        }
    }
}
