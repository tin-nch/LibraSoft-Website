﻿using Librasoft.DataAccess.EFs;
using Librasoft.DataAccess.Repositorys.Constracts;
using Librasoft.Entities.Entities;
using Librasoft_API.Librasoft.DataAccess.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys
{
    public class BlocksRepository : GenericRepository<PiranhaBlock>, IBlocksRepository
    {
        public BlocksRepository(PiranhaCoreContext context) : base(context)
        {
        }
    }
}
