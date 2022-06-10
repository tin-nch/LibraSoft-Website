using LibraSoftSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Test
{
    public interface ITestAPI
    {
        Task<List<string>> GetAll();
    }
}
