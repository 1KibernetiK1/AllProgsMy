using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fluentRibon.dataAccessLayer
{
    public class BookRepo : DbContext
    {
        public BookRepo() : base("Library")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
