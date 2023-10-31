using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }
    }
}