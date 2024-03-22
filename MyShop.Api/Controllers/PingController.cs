using Microsoft.AspNetCore.Mvc;

namespace MyShop.Api.Controllers
{
    public class PingController : BaseController
    {
        [HttpGet]
        public string Get()
        {
            return "Pong";
        }
    }
}
