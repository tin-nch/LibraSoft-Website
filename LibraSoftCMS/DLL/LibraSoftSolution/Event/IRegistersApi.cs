using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.Event;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Event
{
    public interface IRegistersApi
    {
        //  public Task<bool> AddRegister(RegistersVM register);
        public Task<string> AddRegister(RegistersVM register);
    }
}