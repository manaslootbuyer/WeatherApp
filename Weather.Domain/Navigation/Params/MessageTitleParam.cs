using System;
namespace Weather.Domain.Navigation.Params
{
    public class MessageTitleParam : IMessageTitleParam
    {
        public MessageTitleParam(string message, string title)
        {
            Message = message;
            Title = title;
        }

        public string Message { get; }
        public string Title { get; }
    }
}

