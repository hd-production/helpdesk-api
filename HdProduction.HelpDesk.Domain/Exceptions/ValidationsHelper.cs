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

        public static BusinessLogicException EntityAlreadyExists(string entity, string param)
        {
            return new BusinessLogicException($"{entity} with such {param} already exists");
        }

        public static BusinessLogicException WrongFormat(string param)
        {
            return new BusinessLogicException($"{param} has wrong format");
        }
        
        public static EntityNotFoundException EntityNotFound(string entity = "Entity")
        {
            return new EntityNotFoundException($"{entity} doesn't exist");
        }
    }
}