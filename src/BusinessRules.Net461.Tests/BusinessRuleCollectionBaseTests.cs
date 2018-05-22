using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.BusinessRules;

namespace BusinessRules.Net461.Tests
{
    [TestClass]
    public class BusinessRuleCollectionBaseTests
    {
        [TestMethod]
        public void BusinessRuleCollection_IsMet_True_Test()
        {
            // Arrange
            var collection1 = new RuleCollection1();
            var rule = new BusinessRule1();
            collection1.Rules.Add(rule);

            // Act
            var businessRuleResult = collection1.IsMet();

            // Assert
            Assert.IsTrue(businessRuleResult.Result);
            Assert.AreEqual(0, businessRuleResult.FailedObjects.Count);
        }

        [TestMethod]
        public void BusinessRuleCollection_IsMet_False_Test()
        {
            // Arrange
            var collection1 = new RuleCollection1();
            var rule = new BusinessRule1(false);
            collection1.Rules.Add(rule);

            // Act
            var businessRuleResult = collection1.IsMet();

            // Assert
            Assert.IsFalse(businessRuleResult.Result);
            Assert.AreEqual(1, businessRuleResult.FailedObjects.Count);
        }

        [TestMethod]
        public void BusinessRuleCollection_TaskAgregateException_Unwrapped_Test()
        {
            // Arrange
            var collection1 = new RuleCollection1();
            var rule = new BusinessRuleThatThrowsException();
            collection1.Rules.Add(rule);

            // Act
            var businessRuleResult = collection1.IsMet();

            // Assert
            Assert.IsFalse(businessRuleResult.Result);
            Assert.AreEqual(2, businessRuleResult.FailedObjects.Count);
            Assert.AreEqual(typeof(Exception), businessRuleResult.FailedObjects[1].GetType());
        }
    }
}
