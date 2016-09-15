
namespace ProjectDomain
{
    public class ExcelDataRow //TODO: Use enum wherever applicable
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

        public string AutomatedBuildAndDeployment { get; set; }
        public string CodeReview { get; set; }
        public string DevModel { get; set; }

        public bool FollowCodeGuidelines { get; set; }
        public string GuideLines { get; set; }
        public string TestCoverage { get; set; }

        public string DesignDiscussions { get; set; }
        public string ScrumPractices { get; set; }
    }
}
