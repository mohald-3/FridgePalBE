﻿namespace Infrastructure.Services.OpenAI
{
    public class OpenAIResponse
    {
        public List<Choice> choices { get; set; }

        public class Choice
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public string content { get; set; }
        }
    }
}
