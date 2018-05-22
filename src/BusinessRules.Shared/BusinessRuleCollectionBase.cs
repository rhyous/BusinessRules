using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhyous.BusinessRules
{
    public abstract class BusinessRuleCollectionBase : IBusinessRuleCollection
    {
        public BusinessRuleCollectionBase()
        {
            Rules = new List<IBusinessRule>();
            Results = new ConcurrentDictionary<IBusinessRule, BusinessRuleResult>();
        }

        public abstract string Name { get; }

        public abstract string Description { get; }

        public List<IBusinessRule> Rules { get; set; }

        public IDictionary<IBusinessRule, BusinessRuleResult> Results { get; set; }


        public virtual BusinessRuleResult IsMet()
        {
            Results.Clear();
            var tasks = new List<Task>();
            foreach (var rule in Rules)
            {
                var task = Task.Run(() =>
                {
                    Results.Add(rule, rule.IsMet());
                });
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            var result = new BusinessRuleResult();
            result.Result = Results.All(r => r.Value?.Result ?? false);
            var failedObjects = Results.Where(r => !r.Value?.Result ?? false).Select(o => o as object).ToList();
            result.FailedObjects.AddRange(failedObjects);
            return result;
        }
    }
}
