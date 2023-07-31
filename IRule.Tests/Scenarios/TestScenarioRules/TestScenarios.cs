using XRule.Validations;
using XRule.Validations.Attributes;
using XRule.Validations.Common;

namespace XRule.Tests.Scenarios.TestScenarioRules
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
