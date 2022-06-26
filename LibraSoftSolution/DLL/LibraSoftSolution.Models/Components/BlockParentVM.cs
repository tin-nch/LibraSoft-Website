﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.ViewModels.Components
{
    public class BlockParentVM
    {
        public List<BlockChildVM> blockChildVMs { get; set; }
        public string Id { get; set; }
        public string Clrtype { get; set; }
        public DateTime Created { get; set; }
        public bool IsReusable { get; set; }
        public DateTime LastModified { get; set; }
        public string Title { get; set; }
        public List<string> HtmlValue { get; set; }

    }
}
