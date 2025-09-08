using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

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
        public Microsoft.Maui.Graphics.Color Color { get; set; }
        internal Priority(int priorityNumber)
        {
            PriorityNumber = priorityNumber;
            switch (priorityNumber)
            {
                case 1:
                    PriorityName = "Urgent/Important";
                    Color = Colors.Red;
                    break;
                case 2:
                    PriorityName = "Not Urgent/Important";
                    Color = Colors.Orange;
                    break;
                case 3:
                    PriorityName = "Not Important/Urgent";
                    Color = Colors.Yellow;
                    break;
                case 4:
                    PriorityName = "Not Important/Not Urgent";
                    Color = Colors.Green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Priority number must be between 1 and 4.");
            }
        }
    }
}
