using System.Collections;

namespace XRule.Validations.Common
{
    public interface IAllowedValidation
        : IValidation
    {
        IEnumerable GetAllowedValues();
    }
}
