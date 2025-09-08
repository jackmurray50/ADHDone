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
    internal class ToDoTask
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public Priority Priority { get; set; }
        public DateTime MinEstimatedCompletionTime { get; set; }
        public DateTime MaxEstimatedCompletionTime { get; set; }
        public DateTime ToFinishDate { get; set; }
        public string LocationType { get; set; } 

        public List<ToDoTask> Children { get; set; } 
        public ToDoTask ParentToDoTask { get; set; }

        internal static ToDoTask CreateRoot(string name)
        {
            ToDoTask root = new ToDoTask();
            root.Summary = name;
            root.Description = "";
            root.Category = "root";
            root.Priority = null;
            root.Children = new();

            return root;
        }
    }
}
