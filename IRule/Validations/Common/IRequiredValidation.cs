namespace XRule.Validations.Common
{
    public interface IRequiredValidation
        : IValidation
    {
        bool IsRequired();
    }
}
