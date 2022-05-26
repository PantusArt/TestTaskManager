using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TaskManager20._01._22.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<MyTask> MyTasks { get; set; }
    }
}
