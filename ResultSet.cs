using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticCashMachine
{
    public class ResultSet
    {
        public int ActualAmount { get; set; }
        public bool IsAmountSetteled { get; set; }
        public int[] NoteCounter { get; set; }
        public int NoOfElementstoskip { get; set; }
    }
}
