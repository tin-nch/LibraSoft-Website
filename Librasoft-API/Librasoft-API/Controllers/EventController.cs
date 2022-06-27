using Librasoft.Services.Constract;
using Microsoft.AspNetCore.Mvc;

namespace Librasoft_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IApplicationFormServices _applicationFormService;
        private readonly ISendEmailServices _sendEmailServices;
        public EventController(IApplicationFormServices _applicationFormService, ISendEmailServices _sendEmailServices)
        {
            this._applicationFormService = _applicationFormService;
            this._sendEmailServices = _sendEmailServices;
        }
    }
}
