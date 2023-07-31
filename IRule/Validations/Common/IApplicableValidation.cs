namespace XRule.Validations.Common
{
    public interface IApplicableValidation
        : IValidation
    {
        bool IsApplicable();
    }
}
