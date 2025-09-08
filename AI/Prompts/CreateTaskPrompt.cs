using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHDone.AI.Prompts
{
    internal class CreateTaskPrompt
    {
        public CreateTaskPrompt(string UserInput, List<string> Locations, List<string> Categories)
        {
            string prompt = $"The user input is: {UserInput}. Provide me with a Summary, Description, Category, MinEstimatedCompletionTime, MaxEstimatedCompletionTime, ToFinishDate, LocationType, and Priority. " +
                $"For the priority, determine if the task is Urgent/Important, Not Urgent/Important, Not Important/Urgent, or Not Important/Not Urgent. Respond using 1, 2, 3, or 4 in that order. " +
                $"LocationType should be chosen from the following list if possible, but you can create a new one if no appropriate one is found." +
                $"{string.Join(", ", Locations)}. " +
                $"Category should be chosen from the following list if possible, but you can create a new one if no appropriate one is found." +
                $"{string.Join(", ", Categories)}. Respond in JSON with no markup.";
        }
    }
}
