using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal class PagedResults
    {
        public PagedResults()
        {
            Results = new List<User>();
            Paging = new Paging();

        }

        public List<User> Results { get; set; }
        public Paging Paging { get; set; }
    }
}
