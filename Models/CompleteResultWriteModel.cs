using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foos_svc
{
    public class CompleteResultWriteModel
    {
        public TeamWriteModel WhiteTeam { get; set; }
        public TeamWriteModel BlueTeam { get; set; }
        public int MatchId { get; set; }

    }
}
