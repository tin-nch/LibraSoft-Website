﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Entities.Entities.Dtos
{
    public class EventParticipantDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string IDEvent { get; set; }
    }
}
