using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fluentRibon
{
    public class Book
    {
        public long BookId { get; set; }

        public string Title { get; set; }

        public int PublishYear { get; set; }

        public virtual List<Person> Author { get; set; }

        public virtual List<Genre> Genres { get; set; }
    }
}
