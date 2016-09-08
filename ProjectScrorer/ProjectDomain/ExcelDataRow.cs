using System;
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
        public string ProjectManagementTool { get; set; }

        public bool BranchingUsed { get; set; }
        public bool TaggedReleases { get; set; }
        public string DocTool { get; set; }
        public string ApplicationMonitoring { get; set; }
        public string Documentation { get; set; }
        public string Tests { get; set; }
        public string CodeReview { get; set; }
        public string DevModel { get; set; }
        public string TestCoverage { get; set; }
    }
}
