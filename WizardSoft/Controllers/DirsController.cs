using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WizardSoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirsController : ControllerBase
    {


        private readonly ApplicationContext _context;
        public DirsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            return Ok(await _context.Dirs.ToListAsync());
        }

        [HttpPost]
        [Route("CreateRootDir")]
        public async Task<ActionResult<List<Dir>>> AddRootDir(string title)
        {
            Dir dir = new Dir();
            dir.Title = title;
            _context.Dirs.Add(dir);
            await _context.SaveChangesAsync();
            return Ok(await _context.Dirs.ToListAsync());
        }


        [HttpPut]
        [Route("UpdateDir")]
        public async Task<ActionResult<List<Dir>>> UpdateDir(Dir req)
        {
            var dbDir = await _context.Dirs.FindAsync(req.Id);
            if (dbDir == null)
            {
                return BadRequest("Not found");
            }
            dbDir.Title = req.Title;
            dbDir.Parent = req.Parent;
            dbDir.ParentId = req.ParentId;
            dbDir.Children = req.Children;
            await _context.SaveChangesAsync();

            return Ok(await _context.Dirs.ToListAsync());
        }

        [HttpDelete]
        [Route("DeleteDir")]
        public async Task<ActionResult<List<Dir>>> Delete(int id)
        {
            var dbDir = await _context.Dirs.FindAsync(id);
            if (dbDir == null)
            {
                return BadRequest("Not found");
            }
            _context.Dirs.Remove(dbDir);
            await _context.SaveChangesAsync();
            return Ok(await _context.Dirs.ToListAsync());
        }

    }
}
