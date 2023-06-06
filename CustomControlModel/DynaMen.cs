using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.CustomControlModel
{
    public class DynaMen
    {
        public string MenuCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string RouteTo { get; set; }
        public decimal SortOrder { get; set; }
        public List<DynaMen> DetailMenuItem { get; set; } 
    }
}
