using System.Collections.Generic;

namespace Rhyous.BusinessRules
{
    public class BusinessRuleResult
    {
        public bool Result { get; set; }
        public List<object> FailedObjects
        {
            get { return _FailedObjects ?? (_FailedObjects = new List<object>()); }
            set { _FailedObjects = value; }
        } private List<object> _FailedObjects;

        public void AddFailedObject(object o)
        {
            if (!FailedObjects.Contains(o))
                FailedObjects.Add(o);
        }
    }
}
