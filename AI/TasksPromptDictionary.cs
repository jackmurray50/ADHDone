using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHDone.AI
{
    internal static class TasksPromptDictionary
    {
        private static Dictionary<Prompt, string> prompts = new()
        {
            [Prompt.ParseTaskFromUserInput] = "For this task, provide me with a Summary, Description, Category, MinEstimatedCompletionTime, MaxEstimatedCompletionTime, ToFinishDate, LocationType, and Priority. For the priority, determine if the task is Urgent/Important, Not Urgent/Important, Not Important/Urgent, or Not Important/Not Urgent. Respond using 1, 2, 3, or 4 in that order. LocationType should be something like 'home', 'grocery store' or similar. Respond in JSON."
        };
        enum Prompt
        {
            ParseTaskFromUserInput
        }
    }
}
