using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LibraSoftSolution.ViewModels.Candidate_CV
{
    public class CandidateFormVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter fullname")]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please attach your CV")]
        [Display(Name = "File")]
        public IFormFile File { get; set; }
    }
}
