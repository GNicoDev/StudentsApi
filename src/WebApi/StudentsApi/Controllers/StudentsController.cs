
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace GNDSoft.Students.Services.StudentsApi.Controllers
{
    [ApiController]
    public class StudentsController: ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger = null)
        {
            _logger = logger ?? NullLogger<StudentsController>.Instance;
        }
    }
}