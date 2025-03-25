namespace projekt01APBD;

public class CannotAddKontenerException : Exception
{
    public CannotAddKontenerException(String message)
    {
        Console.WriteLine(message);
    }
}