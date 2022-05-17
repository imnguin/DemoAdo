using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserEntities
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Pass Word is required.")]
        public string PassWord { get; set; }
    }
}
