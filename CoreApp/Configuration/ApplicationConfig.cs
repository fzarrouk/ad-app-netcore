using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Configuration
{
    public class ApplicationConfig
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public Author AppAuthor { get; set; }

    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
