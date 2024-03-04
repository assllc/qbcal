using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace qbcal.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
    }
}
