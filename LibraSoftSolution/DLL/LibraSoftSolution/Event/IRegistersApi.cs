using LibraSoftSolution.ViewModels.Event;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Event
{
    public interface IRegistersApi
    {
        public Task<bool> AddRegister(RegistersVM register);
    }
}