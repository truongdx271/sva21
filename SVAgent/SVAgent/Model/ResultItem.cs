using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVAgent.Model
{
    public class ResultItem
    {
        public int identify { get; set; }
        public string displayTxt { get; set; }
        public string pathFile { get; set; }
        public int lineNumber { get; set; }
        public string result { get; set; }
        public ResultItem(int identify, string displayTxt, string pathFile, int lineNumber, string result)
        {
            this.identify = identify;
            this.displayTxt = displayTxt;
            this.pathFile = pathFile;
            this.lineNumber = lineNumber;
            this.result = result;
        }
        public ResultItem()
        {

        }
    }
}
