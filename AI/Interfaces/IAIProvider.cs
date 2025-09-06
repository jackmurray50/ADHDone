using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHDone.AI.Interfaces
{
    internal interface IAIProvider
    {
        /// <summary>
        /// Send a prompt to an AI and get a response back in JSON format, which will be deserialized to the desired object type T
        /// </summary>
        /// <typeparam name="T">The desired object the AI's output should deserialize to</typeparam>
        /// <param name="prompt">The prompt to send to the AI</param>
        /// <returns>A T which has been deserialized from the AI's output</returns>
        public Task<T> SendPromptAsync<T>(string prompt);
        public T SendPrompt<T>(string prompt);
    }
}
