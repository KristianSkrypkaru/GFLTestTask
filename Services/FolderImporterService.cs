using GFLTestTask.Data;
using GFLTestTask.Models;

namespace GFLTestTask.Services
{
    public class FolderImporterService
    {
        private readonly DataContext _context;

        public FolderImporterService(DataContext context)
        {
            _context = context;
        }

        public void ImportFolderStructure(string rootPath, int? parentFolderId = null)
        {
            var folders = Directory.GetDirectories(rootPath);

            foreach (var folderPath in folders)
            {
                var folderName = Path.GetFileName(folderPath);

                var folderItem = new Folder
                {
                    FolderName = folderName,
                    ParentFolderID = parentFolderId
                };

                _context.Folders.Add(folderItem);
                _context.SaveChanges();

                ImportFolderStructure(folderPath, folderItem.FolderID);
            }
        }
    }
}
