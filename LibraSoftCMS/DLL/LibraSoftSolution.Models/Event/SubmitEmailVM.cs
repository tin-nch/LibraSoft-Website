using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.ViewModels.Event
{
    public class SubmitEmailVM
    {
        [Required(ErrorMessage = "Please enter email address")]
        public string Email { get; set; }
    }
}
