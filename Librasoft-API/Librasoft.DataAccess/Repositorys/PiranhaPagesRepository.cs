﻿using Librasoft.DataAccess.Repositorys.Constracts;

using Librasoft_API.Entities;
using Librasoft_API.Librasoft.DataAccess.EFs;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys
{
    public class PiranhaPagesRepository : GenericRepository<PiranhaPage>, IPagesRepository
    {
        public PiranhaPagesRepository(PiranhaCoreContext context) : base(context)
        {
        }

        public List<PiranhaPage> GetListPages()
        {
            return _context.PiranhaPages.ToList();
        }

        public List<string> GetListTitle()
        {
            List<string> listTitle = new List<string>();
            List<PiranhaPage> piranhaPages = new List<PiranhaPage>();
            piranhaPages = GetListPages();
            foreach (PiranhaPage a in piranhaPages)
            {
                listTitle.Add(a.NavigationTitle.ToString());
            }
            return listTitle;
        }
    }
}
