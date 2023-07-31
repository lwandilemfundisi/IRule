using XRule.Notifications;
using XRule.Validations;
using Microservice.Framework.Common;
using System.Reflection;

namespace XRule
{
    public interface IValidator
    {
        Task<Notification> Validate(
            IEnumerable<IValidation> validations,
            CancellationToken cancellationToken);

        Task<Notification> Validate(
            object instance,
            object context,
            SystemCulture culture,
            Assembly assembly,
            CancellationToken cancellationToken);

        Task<Notification> Validate(
            object instance,
            object context,
            SystemCulture culture,
            IEnumerable<Assembly> assemblies,
            CancellationToken cancellationToken);
    }
}
