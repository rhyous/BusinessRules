using Rhyous.BusinessRules;
using System.Collections.Generic;

namespace BusinessRules.Tests
{
    public class FakeBusinessRule : IBusinessRule
    {
        private readonly bool _PassOrFail;

        public FakeBusinessRule(int id, bool passOrFail)
        {
            Id = id;
            _PassOrFail = passOrFail;
        }
        public int Id { get; set; }

        public string Name => $"Rule {Id}";

        public string Description => $"Rule {Id} Description";

        public BusinessRuleResult IsMet()
        {
            return _PassOrFail ? new BusinessRuleResult { Result = true } : new BusinessRuleResult
            {
                FailedObjects = new List<object> { $"Data {Id}.1", $"Data {Id}.2" },
                Result = false
            };
        }
    }
}
