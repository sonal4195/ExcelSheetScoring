﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDomain
{
    public class ExcelDataRow
    {
        public bool HasRepositorySystem { get; set; }
        public bool HasBackup { get; set; }
        public bool BranchingUsed { get; set; }
        public bool TaggedReleases { get; set; }
    }
}
