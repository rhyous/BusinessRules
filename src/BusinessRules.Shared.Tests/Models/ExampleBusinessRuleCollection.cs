using Rhyous.BusinessRules;
using System;

namespace BusinessRules.Tests
{
    public class ExampleBusinessRuleCollection : BusinessRuleCollectionBase
    {
        public override string Name => "Example Business Rule Collection";

        public override string Description => "Example Business Rule Collection";

        public ExampleBusinessRuleCollection(int exampleRuleCount, Func<int, bool> passOrFailLogic)
        {
            int i = 0;
            while (i++ < exampleRuleCount)
                Rules.Add(new FakeBusinessRule(i, passOrFailLogic(i)));
        }
    }
}
