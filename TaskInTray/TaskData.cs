using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TaskInTray
{
    public class TaskData
    {
        public string Name { get; set; } = String.Empty;

        public DateTime DeadlineDate { get; set; } = DateTime.Now;

        public bool IsCompleted { get; set; } = false;

        public string Label { get; set; } = string.Empty;
    }
}
