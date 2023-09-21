using GFLTestTask.Data;
using GFLTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GFLTestTask.Controllers
{
    public class OpenFoldersController : Controller
    {
        private readonly DataContext _context;
        
        public OpenFoldersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [Route("Creating Digital Images/{name}")]
        public IActionResult OpenFolders([FromRoute] string name = "Creating Digital Images")
        {
            var folders = _context.Folders
            .Include(f => f.Subfolders)
            .FirstOrDefault(f => f.FolderName == name);
            return View("OpenFolders", folders);
        }

    }
}
