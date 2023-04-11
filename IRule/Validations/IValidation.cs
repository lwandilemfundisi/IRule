using IRule.Notifications;
using Microservice.Framework.Common;

namespace IRule.Validations
{
    public interface IValidation
    {
        SeverityType Severity { get; set; }

        SystemCulture Culture { get; set; }

        object Context { get; set; }

        object Owner { get; set; }

        Task<Notification> Validate(CancellationToken cancellationToken);

        bool IsPropertyRule { get; set; }

        bool MustValidate();

        bool CanExecuteParallel();

        string Name { get; set; }

        string PropertyName { get; set; }

        string ReadOnlyMessage { get; set; }

        string DisplayName { get; set; }
    }
}
