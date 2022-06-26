using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.ViewModels.Candidate_CV
{
    public class CandidateVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter fullname")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        public string Phone { get; set; }
        public string FilePath { get; set; }
    }
}
