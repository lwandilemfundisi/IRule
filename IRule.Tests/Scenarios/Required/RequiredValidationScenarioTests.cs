using XRule.Tests.Scenarios.TestScenarioRules;
using XRule.Validations;
using Microservice.Framework.Common;
using Microsoft.Extensions.DependencyInjection;
using XRule.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace XRule.Tests.Scenarios.Required
{
    public class RequiredValidationScenarioTests
    {
        private IServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            //Should this be Singleton or Transient?
            services.TryAddTransient<IValidator, Validator>();

            var ruleTypes = GetType().Assembly
                .GetTypes()
                .Where(t => typeof(IValidation).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface);

            foreach (var ruleType in ruleTypes)
            {
                services.TryAddTransient(ruleType);
            }

            _serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public async Task RuleTest()
        {
            var validator = _serviceProvider
                .GetService<IValidator>();

            var validationResult = await validator
                .Validate(
                new TestObject() { },
                new TestObjectContext(),
                SystemCulture.Default(),
                this.GetType().Assembly,
                CancellationToken.None);

            Assert.IsTrue(validationResult.HasErrors());
        }
    }
}
