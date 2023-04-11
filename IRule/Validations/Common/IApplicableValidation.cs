namespace IRule.Validations.Common
{
    public interface IApplicableValidation
        : IValidation
    {
        bool IsApplicable();
    }
}
