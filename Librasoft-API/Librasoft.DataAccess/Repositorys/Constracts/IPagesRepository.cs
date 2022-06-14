﻿using Librasoft.Entities.Entities;

using Librasoft_API.Librasoft.DataAccess.Repositorys.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.DataAccess.Repositorys.Constracts
{
    public interface IPagesRepository :IEfRepository<PiranhaPage>
    {

        public List<PiranhaPage> GetPagesListWithHomeTitle();
    }
}
