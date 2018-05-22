using Rhyous.BusinessRules;

namespace BusinessRules.Net461.Tests
{
    public class RuleCollection1 : BusinessRuleCollectionBase
    {
        public override string Name => "Rule Collection 1";

        public override string Description => $"Descrpition for {Name}";
    }
}
