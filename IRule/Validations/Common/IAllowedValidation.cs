using System.Collections;

namespace IRule.Validations.Common
{
    public interface IAllowedValidation
        : IValidation
    {
        IEnumerable GetAllowedValues();
    }
}
