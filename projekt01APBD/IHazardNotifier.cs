namespace projekt01APBD;

public interface IHazardNotifier
{
    public abstract void SendMessage(string msg, string serialNo);
}