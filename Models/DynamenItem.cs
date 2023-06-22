using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.Models
{
    public class DynamenItem
    {
        public string MenuCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string RouteTo { get; set; }
        //[Precision(18, 2)]
        public decimal SortOrder { get; set; } = 0;
        public List<DynamenItem> DetailMenuItems { get; set; } = null;
    }
}
