using GFLTestTask.Data;
using GFLTestTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace GFLTestTask.Controllers
{
    public class FolderImporterController : Controller
    {
        private readonly FolderImporterService _folderImporter;
        private readonly DataContext _context;
        private string _fileStoragePath;

        public FolderImporterController(FolderImporterService folderImporter, DataContext context)
        {
            _folderImporter = folderImporter;
            _context = context;
        }

        public IActionResult Index()
        {
            var folderItems = _context.Folders
                .Include(f => f.Subfolders)
                .FirstOrDefault();
            return View(folderItems);
        }

        public IActionResult Import()
        {
            _folderImporter.ImportFolderStructure(@"C:\Program Files");

            return View("Import");
        }
    }
}