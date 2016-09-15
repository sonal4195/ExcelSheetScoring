using ProjectDomain;
using System;

namespace BusinessLogic.Helpers
{
    public class Logger
    {
        public static void LogRuleResult(IRule rule, Result result)
        {
            Console.WriteLine("Result for rule {0}: Color {1} Score {2}", rule.GetRuleNumber(), result.SignalColor, result.Score);
        }
    }
}
