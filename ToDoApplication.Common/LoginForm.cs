using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApplication.Common
{
    public class LoginForm
    {
        [Required(ErrorMessage = "Duhet plotesuar fusha e username ")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username duhet te jete 4 deri ne 50 karaktere i gjate")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Duhet plotesuar fusha e fjalekalimit")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Fjalekalimi duhet te jete 4 deri ne 50 karaktere i gjate")]
        public string Password { get; set; }
    }
}
