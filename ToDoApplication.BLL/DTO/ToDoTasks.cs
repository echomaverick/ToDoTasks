using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.BLL.DTO
{
    public class ToDoTasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AdminId { get; set; }
        public int? UserId { get; set; }
        public bool? IsCompleted { get; set; }
        public string? UserComment { get; set; }
    }
}
