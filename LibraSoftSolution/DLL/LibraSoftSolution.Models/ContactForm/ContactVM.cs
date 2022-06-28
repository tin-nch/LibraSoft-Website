using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibraSoftSolution.ViewModels.ContactForm
{
    public class ContactVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
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
        [Required(ErrorMessage = "Select a reason")]
        [Display(Name = "ReasonReachingId")]
        [BindRequired]
        public int? ReasonReachingId { get; set; }
        public SelectList ListOfReasonReaching { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        [Display(Name = "MessageContent")]
        public string MessageContent { get; set; }
    }
}
