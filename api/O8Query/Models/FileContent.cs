using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotChocolate;

namespace O8Query.Models
{
    public class FileContent
    {
        public enum FileType
        {
            Logo
        }

        [Key]
        public long No { get; set; }
        [Required]
        public FileType Type { get; set; }
        [Required]
        [MaxLength(256)]
        public string FileName { get; set; }
        [Required]
        public byte[] Content { get; set; }
        [Required]
        public int ContentSize { get; set; }
        [Required]
        [MaxLength(50)]
        public string ContentType { get; set; }
        [Required]
        public DateTime Created { get; set; }

        [GraphQLIgnore]
        public List<Company> Companies { get; set; }
    }
}