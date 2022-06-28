using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraSoftSolution.ViewModel
{
    [Table("Piranha_ContactForm")]
    public class ReasonReachingViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "Phone")]
        [Phone]
        public string? Phone { get; set; }
        [DisplayName("ReasonR")]
        public int? ReasonReachingId { get; set; }
        public List<SelectListItem>? ListofReason { get; set; }
        public string? MessageContent { get; set; }
    }
}
