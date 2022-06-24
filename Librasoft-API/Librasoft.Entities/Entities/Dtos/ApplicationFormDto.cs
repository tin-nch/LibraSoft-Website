using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Entities.Entities.Dtos
{
    public class ApplicationFormDto
    {
     
        public int Id { get; set; }
    
    
        public string FullName { get; set; }
        public string Email { get; set; }

      
        public string Phone { get; set; }
        public IFormFile File { get; set; }
    }
}
