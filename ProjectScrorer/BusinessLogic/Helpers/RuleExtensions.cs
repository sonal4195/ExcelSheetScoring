using ProjectDomain;

namespace BusinessLogic.Helpers
{
    public static class RuleExtensions
    {
        public static string GetRuleName(this IRule rule)
        {
            return rule.GetType().Name;
        }

        public static string GetRuleNumber(this IRule rule)
        {
            var ruleName = rule.GetRuleName();
            return ruleName.Substring(4);
        }
    }
}
