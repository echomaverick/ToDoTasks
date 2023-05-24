using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Common.Enums;

namespace ToDoApplication.BLL.DTO
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Duhet plotesuar fusha e username")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username duhet te jete 4 deri 20 karaktereve")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Duhet plotesuar fusha e password")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Password duhet te jete 4 deri 20 karaktereve")]
        public string Password { get; set; }
        public List<ToDoTasks> ToDoTasks { get; set; }
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
