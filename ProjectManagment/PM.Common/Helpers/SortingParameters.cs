using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Common.Helpers
{
    public class SortingParameters
    {
        public string OrderBy { get; set; }

        public bool IsDescendingSortOrder { get; set; }

        public SortingParameters()
        {
        }

        public SortingParameters(string orderBy, bool isDescendingSortOrder)
        {
            this.OrderBy = orderBy;
            this.IsDescendingSortOrder = IsDescendingSortOrder;
        }
    }
}
