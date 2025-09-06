using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADHDone.TaskList.Modules
{
    /// <summary>
    /// Stores a tasks priority as in an Eisenhower matrix 
    /// </summary>
    /// eisenhower matrix: https://en.wikipedia.org/wiki/Time_management#Eisenhower_method
    internal class Priority
    {
        public int PriorityNumber { get; set; }
        public string PriorityName { get; set; }
        public Color Color { get; set; }
    }
}
