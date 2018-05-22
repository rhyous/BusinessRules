using Rhyous.BusinessRules;
using System;

namespace BusinessRules.Net461.Tests
{
    public class BusinessRuleThatThrowsException : IBusinessRule
    {

        public string Name => "Rule 1";

        public string Description => "An example rule.";

        public BusinessRuleResult IsMet() => throw new Exception("An unexpected exception.");
    }
}
