using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHDone.AI.Prompts
{
    internal class CreateTaskPrompt
    {
        private string prompt;
        public CreateTaskPrompt(string UserInput, List<string> Locations, List<string> Categories)
        {
            prompt = $"The user input is: {UserInput}. Provide me with a Summary, Description, Category, MinEstimatedCompletionTime, MaxEstimatedCompletionTime, ToFinishDate, LocationType, and Priority. \n" +
                $"For the priority, determine if the task is Urgent/Important, Not Urgent/Important, Not Important/Urgent, or Not Important/Not Urgent. Respond using 1, 2, 3, or 4 in that order. " +
                $"Return MinEstimatedCompletionTime and MaxEstimatedCompletionTime as a number of minutes. Return ToFinishDate in YYYY-MM-DD format.\n" +
                $"LocationType should be chosen from the following list if possible, but you can create a new one if no appropriate one is found:\n" +
                $"{string.Join(", ", Locations)}. \n\n" +
                $"Category should be chosen from the following list if possible, but you can create a new one if no appropriate one is found.\n" +
                $"{string.Join(", ", Categories)}. \n\nRespond in JSON with no markup.";
        }

        public override string ToString()
        {
            return prompt;
        }
    }
}
