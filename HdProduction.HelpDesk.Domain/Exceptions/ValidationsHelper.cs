namespace HdProduction.HelpDesk.Domain.Exceptions
{
    public static class ExceptionsHelper
    {
        public static BusinessLogicException Empty(string param)
        {
            return new BusinessLogicException($"{param} can not be empty");
        }

        public static BusinessLogicException LongLength(string param)
        {
            return new BusinessLogicException($"{param} is too long");
        }

        public static BusinessLogicException Duplicate(string param)
        {
            return new BusinessLogicException($"There can not be duplicated {param}");
        }

        public static EntityNotFoundException EntityNotFound(string entity = "Entity")
        {
            return new EntityNotFoundException($"{entity} doesn't exist");
        }
    }
}