using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.DAL.Entities
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AdminId { get; set; }
        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public bool? IsCompleted { get; set; }
        public string? UserComment { get; set; }

    }
}
