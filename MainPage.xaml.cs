using ADHDone.AI.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;
using ADHDone.AI.Connections;
using ADHDone.AI;
using ADHDone.TaskList.Modules;
using ADHDone.AI.Prompts;

namespace ADHDone
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string, ToDoTask> allTasks;
        ToDoTask root;
        ToDoTask activeTask;
        GlobalSettings gs;
        public MainPage()
        {
            //On initialization, pull information from storage
            LoadRoot();
            InitializeComponent();
        }

        private async void LoadRoot()
        {
            gs = GlobalSettings.RetrieveGlobalSettings();
            //Check if there's an existing Tasks file. If not, create it.
            if (File.Exists(@"Tasks.json"))
            {
                //Try to find an existing default tasks file
                allTasks = JsonSerializer.Deserialize<Dictionary<string, ToDoTask>>(File.ReadAllText(@"Tasks.json"));
            }
            else
            {
                //Default tasks file didn't exist; create one.
                allTasks = await CreateDefaultTasks();
                File.WriteAllText(@"Tasks.json", JsonSerializer.Serialize(allTasks));
            }
            //Pull in settings
            root = allTasks[gs.DefaultTask];
            activeTask = root;
        }

        private async Task<Dictionary<string, ToDoTask>> CreateDefaultTasks()
        {
            Dictionary<string, ToDoTask> TasksToReturn = new();
            ToDoTask root = new ToDoTask();
            IAIProvider AIProvider = new RemoteDebugAIProvider();
            List<string> TasksToAdd = new()
            {
                "Do laundry",
                "Get groceries",
                "Exercise for an hour",
                "Do dishes",
                "Call your parents",
            };
            TasksToReturn.Add("Default", ToDoTask.CreateRoot("Default"));
            foreach(string prompt in TasksToAdd)
            {
                // Use AI to parse the prompt into a ToDoTask object
                ToDoTask newTask = await AIProvider.SendPromptAsync<ToDoTask>(new CreateTaskPrompt(prompt, gs.Locations, gs.Categories).ToString());
                // Add the new task to the default root task
                TasksToReturn["Default"].Children.Add(newTask);
            }

            return TasksToReturn;
        }

    }
}
