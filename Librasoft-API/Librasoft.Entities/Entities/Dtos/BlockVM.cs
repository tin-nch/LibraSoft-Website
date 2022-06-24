using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Entities.Entities.Dtos
{
    public class BlockParentVM
    {

        public BlockParentVM()
        {
            
        }
        public BlockParentVM(PiranhaBlock p)
        {
            this.Id = p.Id;
            this.Clrtype = p.Clrtype;
            this.Created = p.Created;
            this.LastModified = p.LastModified;
            this.Title = p.Title;
            this.IsReusable = p.IsReusable;
        }

        public List<BlockChildVM> blockChildVMs { get; set; }
        public Guid Id { get; set; }
        public string Clrtype { get; set; }
        public DateTime Created { get; set; }
        public bool IsReusable { get; set; }
        public DateTime LastModified { get; set; }
        public string Title { get; set; }
        public List<string> HtmlValue  { get; set; }
        public int SortOrder { get; set; }

    }

    public class BlockChildVM
    {
        public BlockChildVM()
        {  }

        public BlockChildVM(PiranhaBlock p)
        {
            this.Id = p.Id;
            this.Clrtype = p.Clrtype;
            this.Created = p.Created;
            this.LastModified = p.LastModified;
            this.Title = p.Title;
            this.IsReusable = p.IsReusable;
        }
        public Guid Id { get; set; }
        public string Clrtype { get; set; }
        public DateTime Created { get; set; }
        public bool IsReusable { get; set; }
        public DateTime LastModified { get; set; }
        public string Title { get; set; }
        public string HtmlValue { get; set; }
        public int SortOrder { get; set; }
    }




}
