namespace projekt01APBD;

public class OverfillException : Exception
{
    public OverfillException()
    {
        Console.WriteLine("Masa ładunku jest większa niż pojemność danego kontenera");
    }
}