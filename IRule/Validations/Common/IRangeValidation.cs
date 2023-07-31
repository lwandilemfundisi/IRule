namespace IRule.Validations.Common
{
    public interface IRangeValidation
        : IValidation
    {
        object GetMinimum();

        object GetMaximum();
    }
}
