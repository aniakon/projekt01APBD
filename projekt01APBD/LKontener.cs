namespace projekt01APBD;

public class LKontener : Kontener, IHazardNotifier
{
    private bool _isDangerous;
    
    public LKontener(double height, double massWithoutLoad, double depth, double maxLoad, bool isDangerous) : base(height, massWithoutLoad, depth, maxLoad)
    {
        this._isDangerous = isDangerous;
        SerialNo = "L";
    }

    public void Load(double loadWeight)
    {
        base.Load(loadWeight);
        if (_isDangerous)
        {
            if (massLoaded + loadWeight > 0.5 * maxLoad)
            {
                SendMessage("Próba załadowania >50% pojemności kontenera niezbezpiecznym ładunkiem.", SerialNo);
            }
            else
            {
                massLoaded += loadWeight;
                if (KontenerowiecAssigned != null) KontenerowiecAssigned.AddWeight(loadWeight);
                Console.WriteLine("Załadowano kontener " + SerialNo);
            }
        }
        else
        {
            if (massLoaded + loadWeight > 0.9 * maxLoad)
            {
                SendMessage("Próba załadowania >90% pojemności kontenera zwykłym ładunkiem.", SerialNo);
            }
            else
            {
                massLoaded += loadWeight;
                if (KontenerowiecAssigned != null) KontenerowiecAssigned.AddWeight(loadWeight);
                Console.WriteLine("Załadowano kontenerowiec " + SerialNo);
            }
        }
    }

    public void SendMessage(string msg, string serialNo)
    {
        Console.WriteLine("Kontener na płyny {0} z niebezpieczną sytuacją: {1}", serialNo, msg);
    }
    
    public override string ToString()
    {
        if (_isDangerous)
            return "Kontener na płyny " + SerialNo + " z ładunkiem " + massLoaded +
                   " kg z możliwością przewożenia niebezpiecznego ładunku.";
        else
        {
            return "Kontener na płyny " + SerialNo + " z ładunkiem " + massLoaded +
                   " kg bez możliwości przewożenia niebezpiecznego ładunku.";
        }
    }
}