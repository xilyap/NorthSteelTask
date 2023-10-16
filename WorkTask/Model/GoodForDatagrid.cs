using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTask.Model
{
    internal class GoodForDatagrid
    {
        public string Title { get; set; }
        public float Weight { get; set; }

        public float Price { get; set; }
        public SupplyGood Good { get; set; }
    }
}
