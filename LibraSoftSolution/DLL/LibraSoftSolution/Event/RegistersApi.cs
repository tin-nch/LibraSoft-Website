using LibraSoftSolution.API.Utilities;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraSoftSolution.API.Event
{
    public class RegistersApi : BaseApiClient,IRegistersApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegistersApi(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> AddRegister(RegistersVM register)
        {
            var body = await AddAsync<RequestResponse, RegistersVM>("/api/EventParticipants/add", register);

            return OutPutApi.OutPutBool<bool>(body);
        }
    }
}
