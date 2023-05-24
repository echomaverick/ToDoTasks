using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Common.Enums;

namespace ToDoApplication.DAL.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<ToDoTask> ToDoTasks { get; set; }
        public PersonType PersonType
        {
            get
            {
                return PersonType.Admin;
            }
            set
            {

            }
        }
    }
}
