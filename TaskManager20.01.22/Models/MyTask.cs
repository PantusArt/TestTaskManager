using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager20._01._22.Models
{
    public class MyTask
    {
        public int MyTaskId { get; set; }
        public string MyTaskTitle { get; set; }
        public string MyTaskAbout { get; set; }
        public DateTime MyTaskDate { get; set; }
        public int MyTaskTerm { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; }

        public Category Category { get; set; }
        public Status Status { get; set; }

        public ApplicationUser User { get; set; }

    }
}
