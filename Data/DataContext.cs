using GFLTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace GFLTestTask.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Folder> Folders => Set<Folder>();

        public static IEnumerable<object> Folder { get; internal set; }

        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Folder>()
                .HasOne(f => f.ParentFolder)
                .WithMany(f => f.Subfolders)
                .HasForeignKey(f => f.ParentFolderID)
                .IsRequired(false);

            modelBuilder.Entity<Folder>().HasData(
               new Folder[]
               {
                    new Folder { FolderID = 1, FolderName = "Creating Digital Images", ParentFolderID = null},
                    new Folder { FolderID = 2, FolderName = "Resources", ParentFolderID = 1},
                    new Folder { FolderID = 3, FolderName = "Evidence", ParentFolderID = 1},
                    new Folder { FolderID = 4, FolderName = "Graphic Products", ParentFolderID = 1},
                    new Folder { FolderID = 5, FolderName = "Primary Sources", ParentFolderID = 2},
                    new Folder { FolderID = 6, FolderName = "Secondary Sources", ParentFolderID = 2},
                    new Folder { FolderID = 7, FolderName = "Process", ParentFolderID = 4},
                    new Folder { FolderID = 8, FolderName = "Final Product", ParentFolderID = 4},

               });
        }
    }
}
