﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foos_svc
{
    public class TeamWriteModel
    {
        public IEnumerable<string> Players { get; set; }
        public int Score { get; set; }
    }
}
