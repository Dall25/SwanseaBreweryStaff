using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TableControls<T>
    {
        public TableControls(Sorting<T> sorting, Paging paging)
        {
            Sorting = sorting;
            Paging = paging;
        }

        public Sorting<T> Sorting { get; set; }
        public Paging Paging { get; set; }
    }
}
