using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PagedResults<T1, T2>
    {
        public PagedResults(T1 results, TableControls<T2> tableControls)
        {
            Results = results;
            TableControls = tableControls;
        }

        public T1 Results { get; set; }
        public TableControls<T2> TableControls { get; set; }

    }
}
