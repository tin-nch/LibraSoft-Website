using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.ViewModels
{
    public class ContactVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? IndustyId { get; set; }
        public int? CountryId { get; set; }
        public int? ReasonReachingId { get; set; }
        public string MessageContent { get; set; }
    }
}
