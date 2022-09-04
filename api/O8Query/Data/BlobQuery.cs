using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using O8Query.Models;

namespace O8Query.Data
{
    public class BlobQuery: DbContext
    {
        public BlobQuery(DbContextOptions<BlobQuery> baseContext) : base(baseContext) { }

        public DbSet<FileContent> Files { get; set; }
    }
}