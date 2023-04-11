namespace IRule.Validations.Common
{
    public interface IRequiredValidation
        : IValidation
    {
        bool IsRequired();
    }
}
