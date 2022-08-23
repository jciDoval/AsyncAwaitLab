using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwaitLab.Models.Weathers
{
    public class Weather
    {           
        public string Product { get; set; }
        public string Init { get; set; }
        public List<DataSeries> Dataseries { get; set; }
    
    }
}