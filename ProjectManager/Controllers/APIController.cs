using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using ProjectManager.Models.BusinessLogic;
using ProjectManager.Models.Database;
using ProjectManager.Models.Common;
using ProjectManager.Models.ViewMode;

namespace ProjectManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly SqlModel _sqlmodel;
        private readonly ApplicationDbContext _context;

        public APIController(SqlModel sqlmodel, ApplicationDbContext context)
        {
            _sqlmodel = sqlmodel;
            _context = context;
        }


        [HttpGet]
        [Route("products")]
        public IActionResult GetProducts()
        {
            var products = new List<string> { "Product1", "Product2", "Product3" };
            return Ok(products); // Trả về danh sách sản phẩm dạng JSON
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [Route("productsbyid")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
                return NotFound();

            return Ok($"Product{id}");
        }

        [HttpGet]
        [Route("Clientbyid")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var product = await _context.Clients.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpGet]
        [Route("all-params")]
        public IActionResult GetAllParams()
        {
            var allParams = new
            {
                Clients = _context.Clients.ToList(),
                Teams = _context.TEAM.ToList(),
                Assigns = _context.USER.ToList(),
                ProjectTypes = _context.PROJECT_TYPE.ToList(),
                User = _context.USER.ToList(),
                Status = _context.STATUS.ToList(),
                IssueType = _context.ISSUE_TYPE.ToList(),
                PriorityLevel =_context.Prioritys.ToList(),
                Label= _context.PROJECT.Where(r => !string.IsNullOrEmpty(r.Label)).Select(r =>r.Label).Distinct().ToList(),
            };

            return Ok(allParams);
        }

        [HttpGet]
        [Route("maxProjectID")]
        public IActionResult getMaxProjectId()
        {
            int projectid = _sqlmodel.getMaxProjectId();
            if (!_sqlmodel.InsertProject(projectid))
            {
                Console.WriteLine("Cann't insert to DB");
            }
            return Ok(projectid); 
        }

    }
}
