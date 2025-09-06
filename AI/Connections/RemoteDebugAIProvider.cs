using ADHDone.AI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;
using OllamaSharp;
using System.Text.Json;

namespace ADHDone.AI.Connections
{


    internal class RemoteDebugAIProvider : IAIProvider
    {
        IChatClient chatClient;
        List<ChatMessage> chatHistory = new();
        RemoteDebugAIProvider()
        {
            chatClient =
                new OllamaApiClient(new Uri(
#if DEBUG
                    "http://10.0.2.2:11434/"
#endif
#if RELEASE
                    "http://localhost:11434/"
#endif
                    ), "gpt-oss:20b");
        }
        public T SendPrompt<T>(string prompt)
        {
            throw new NotImplementedException();
        }

        public async Task<T> SendPromptAsync<T>(string prompt)
        {
            chatHistory.Add(new ChatMessage(ChatRole.User, prompt));
            var response = "";
            await foreach (ChatResponseUpdate item in
            chatClient.GetStreamingResponseAsync(chatHistory))
            {
                Console.Write(item.Text);
                response += item.Text;
            }
            chatHistory.Add(new ChatMessage(ChatRole.Assistant, response));

            return JsonSerializer.Deserialize<T>(response) ?? throw new FormatException($"Incorrect response\nPrompt:{prompt}\nResponse:{response}");
            throw new NotImplementedException();
        }
    }
}
