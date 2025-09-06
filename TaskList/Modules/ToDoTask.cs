using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHDone.TaskList.Modules
{
    /// <summary>
    /// Contains information about a Task.
    /// </summary>
    internal struct ToDoTask
    {
        string Summary { get; set; }
        string Description { get; set; }
        string Category { get; set; }

        Priority Priority { get; set; }
        DateTime MinEstimatedCompletionTime { get; set; }
        DateTime MaxEstimatedCompletionTime { get; set; }
        DateTime ToFinishDate { get; set; }
        string LocationType { get; set; } 

        List<ToDoTask> children { get; set; } 
        ToDoTask parent { get; set; }

        internal static ToDoTask CreateRoot(string name)
        {
            ToDoTask root = new ToDoTask();
            root.Summary = name;
            root.Description = "";
            root.Category = "root";
            root.Priority = null;
            root.children = new();

            return root;
        }
    }
}
