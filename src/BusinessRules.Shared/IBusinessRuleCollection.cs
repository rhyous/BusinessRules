using System.Collections.Generic;

namespace Rhyous.BusinessRules
{
    public interface IBusinessRuleCollection : IBusinessRule
    {
        List<IBusinessRule> Rules { get; }

        IDictionary<IBusinessRule, BusinessRuleResult> Results { get; }

    }
}
