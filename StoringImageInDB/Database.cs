using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace StoringImageInDB
{
    public class Database:DbContext
    {
        public DbSet<ImageClass> Images { get; set; }
    }
}
