using System;
using System.Collections.Generic;

namespace LibraSoftCMS.Models
{
    public partial class PiranhaEventImage
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }

        public virtual PiranhaEvent IdNavigation { get; set; }
    }
}
