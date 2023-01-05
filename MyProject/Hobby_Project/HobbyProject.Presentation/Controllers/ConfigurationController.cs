using HobbyProject.Presentation.Middleware.UserMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HobbyProject.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IUserConfiguration clientConfiguration;

        public ConfigurationController(IUserConfiguration clientConfiguration)
        {
            this.clientConfiguration = clientConfiguration;
        }

        [HttpGet]
        public ActionResult<UserConfiguration> GetConfigurationController()
        {
            return new UserConfiguration
            {
                Username = clientConfiguration.Username,
                InvokedDateTime = clientConfiguration.InvokedDateTime
            };
        }
    }
}
