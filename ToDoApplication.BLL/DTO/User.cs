using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Common.Enums;

namespace ToDoApplication.BLL.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Duhet plotesuar e username")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Username duhet te kete 4 deri ne 20 karaktere")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Duhet plotesuar e fjalekalimit")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Fjalekalimi duhet te kete 4 deri ne 20 karaktere")]
        public string Password { get; set; }
        public List<ToDoTasks> ToDoTasks { get; set; }
        public PersonType PersonType
        {
            get
            {
                return PersonType.User;
            }
            set
            {

            }
        }
    }
}
