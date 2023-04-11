using IRule.Tests.Scenarios.TestScenarioRules;
using IRule.Validations;
using Microservice.Framework.Common;
using Microsoft.Extensions.DependencyInjection;
using IRule.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IRule.Tests.Scenarios.Required
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
