using Rhyous.BusinessRules;

namespace BusinessRules.Net461.Tests
{
    public class BusinessRule1 : IBusinessRule
    {
        public bool _Result;
        public BusinessRule1(bool result = true) => _Result = result;

        public string Name => "Rule 1";

        public string Description => "An example rule.";

        public BusinessRuleResult IsMet() => new BusinessRuleResult { Result = _Result };
    }
}
