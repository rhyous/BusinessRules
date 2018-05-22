using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.BusinessRules;

namespace BusinessRules.Tests
{
    [TestClass]
    public class BusinessRulesCollectionBaseTests
    {
        [TestMethod]
        public void BusinessRuleCollectionTests()
        {
            // Arrange
            var collection = new ExampleBusinessRuleCollection(2, (int id) => false);

            // Act
            var result = collection.IsMet();

            // Assert
            Assert.AreEqual(2, result.FailedObjects.Count);

            var r1 = ((KeyValuePair<IBusinessRule, BusinessRuleResult>)result.FailedObjects[0]).Value;
            var key1 = ((KeyValuePair<IBusinessRule, BusinessRuleResult>)result.FailedObjects[0]).Key as FakeBusinessRule;
            Assert.IsFalse(r1.Result);
            Assert.AreEqual(2, r1.FailedObjects.Count);
            Assert.AreEqual($"Data {key1.Id}.1", r1.FailedObjects[0]);
            Assert.AreEqual($"Data {key1.Id}.2", r1.FailedObjects[1]);

            var r2 = ((KeyValuePair<IBusinessRule, BusinessRuleResult>)result.FailedObjects[1]).Value;
            var key2 = ((KeyValuePair<IBusinessRule, BusinessRuleResult>)result.FailedObjects[1]).Key as FakeBusinessRule;
            Assert.IsFalse(r2.Result);
            Assert.AreEqual(2, r2.FailedObjects.Count);
            Assert.AreEqual($"Data {key2.Id}.1", r2.FailedObjects[0]);
            Assert.AreEqual($"Data {key2.Id}.2", r2.FailedObjects[1]);
        }

        [TestMethod]
        public void BusinessRuleCollectionTests_1000_ConccurentDictionaryIsThreadSafe()
        {
            // Arrange
            // Act
            int i = 0;
            BusinessRuleResult result = null;
            while (i++ < 1000)
            {
                var collection = new ExampleBusinessRuleCollection(2, (int id) => false);
                result = collection.IsMet();
            }

        }

        [TestMethod]
        public void MetRulesDoNotAddFailedObjects()
        {
            // Arrange
            var collection = new ExampleBusinessRuleCollection(10, (int id) => { return id % 2 == 0; });

            // Act
            var result = collection.IsMet();

            // Assert
            Assert.AreEqual(5, result.FailedObjects.Count);
        }

        [TestMethod]
        public void IsMetCanRunTwiceWithoutDuplicatingDataOrCrashingWithDuplicateDictionaryKeys()
        {
            // Arrange
            var collection = new ExampleBusinessRuleCollection(10, (int id) => { return id % 2 == 0; });

            // Act
            var result = collection.IsMet();
            result = collection.IsMet();

            // Assert
            Assert.AreEqual(5, result.FailedObjects.Count);
        }
    }
}
