using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foos_svc
{
    public class CompleteDataModel
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public String Name { get; set; }
        public bool IsWhite { get; set; }
        public int Score { get; set; }
    }
}
