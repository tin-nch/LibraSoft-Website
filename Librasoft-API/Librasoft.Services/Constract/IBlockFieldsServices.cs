﻿using Librasoft.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Librasoft.Services.Constract
{
    public interface IBlockFieldsServices
    {

        public Task<IEnumerable<PiranhaBlockField>> GetBlockFieldlistAsync();
    }
}