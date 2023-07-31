namespace XRule.Validations.Common
{
    public interface IRangeValidation
        : IValidation
    {
        object GetMinimum();

        object GetMaximum();
    }
}
