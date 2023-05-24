using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Common.Enums;

namespace ToDoApplication.Common
{
    public class SessionPerson
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public PersonType PersonType { get; set; }
    }
}
