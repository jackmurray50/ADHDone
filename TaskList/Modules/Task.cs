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
    internal struct Task
    {
        string Summary { get; set; }
        string Description { get; set; }
        string Category { get; set; }

        Priority Priority { get; set; }
        DateTime MinEstimatedCompletionTime { get; set; }
        DateTime MaxEstimatedCompletionTime { get; set; }
        DateTime ToFinishDate { get; set; }
        string LocationType { get; set; } 

        List<Task> children { get; set; }
    }
}
