using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GFLTestTask.Models
{
    public class Folder
    {
        [Key]
        public int FolderID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FolderName { get; set; }

        public int? ParentFolderID { get; set; }

        public Folder ParentFolder { get; set; }

        public List<Folder> Subfolders { get; set; }
    }

}
