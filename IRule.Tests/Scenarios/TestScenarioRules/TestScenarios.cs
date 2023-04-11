using IRule.Validations;
using IRule.Validations.Attributes;
using IRule.Validations.Common;

namespace IRule.Tests.Scenarios.TestScenarioRules
{
    public class TestObject
    {
        public string Name { get; set; }
        public int? Age { get; set; }
    }

    public class TestObjectContext
    {
    }

    [Validation(typeof(TestObject))]
    [ValidationProperty("Name")]
    [ValidationProperty("Age")]
    [ValidationContext(typeof(TestObjectContext))]
    public class TestObjectRequiredValidation : RequiredValidation<TestObject>
    {
    }
}
