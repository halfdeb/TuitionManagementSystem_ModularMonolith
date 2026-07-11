namespace Shared.Exception;

public class NotFoundException : System.Exception
{
    public NotFoundException(string entityName, object key) : base($"{entityName} with id '{key} was not found.")
    {
        
    }
}