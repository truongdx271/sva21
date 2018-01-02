using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTestCsharp.Model
{
    public class Scan
    {
        public int No { get; set; }
        public DateTime scantime { get; set; }
        public int total { get; set; }
        public List<ResultItem> resultItems { get; set; }
        public Scan(int No, DateTime scantime, int total, List<ResultItem> resultItems)
        {
            this.No = No;
            this.scantime = scantime;
            this.total = total;
            this.resultItems = resultItems;
        }
        public Scan()
        {

        }
    }
}
