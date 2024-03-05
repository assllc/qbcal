using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using qbcal.Application.Interfaces;
using System.Runtime.CompilerServices;

namespace qbcal.Controllers
{
    [Route("migrations")]
    public class MigrationController : BaseController
    {
        private readonly IMigrationService _migrationService;
        private readonly IConfiguration _configuration;
        public MigrationController(IMigrationService migrationService, IConfiguration configuration)
        {
            _migrationService = migrationService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RunMigrations()
        {
            var connectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            if (connectionString == null) { return Ok(); }

            return Ok(_migrationService.RunDbMigrations(connectionString));
        }
    }
}
