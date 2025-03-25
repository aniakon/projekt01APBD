namespace projekt01APBD;

public class GKontener : Kontener, IHazardNotifier
{
    private double _pressure;
    private double _pressureMax;
    
    public GKontener(double height, double massWithoutLoad, double depth, double maxLoad, double pressureMax) : base(height, massWithoutLoad, depth, maxLoad)
    {
        this._pressure = 0;
        this._pressureMax = pressureMax;
        this.SerialNo = "G";
    }

    public override void Unload()
    {
        massLoaded = 0.05 * massLoaded;
    }

    public void Load(double loadWeight, double addedPressure)
    {
        base.Load(loadWeight);
        if (_pressure + addedPressure > _pressureMax)
        {
            SendMessage("Próba załadowania gazu prowadząca do zbyt wysokiego ciśnienia w kontenerze", SerialNo);
        }
        else
        {
            _pressure += addedPressure;
            massLoaded += loadWeight;
            if (KontenerowiecAssigned != null) KontenerowiecAssigned.AddWeight(loadWeight);
            Console.WriteLine("Załadowano kontener " + SerialNo);
        }
    }
    
    public void SendMessage(string msg, string serialNo)
    {
        Console.WriteLine("Kontener na gaz {0} z niebezpieczną sytuacją: {1}", SerialNo, msg);
    }
    
    public override string ToString()
    {
        return "Kontener na gaz " + SerialNo + " z ładunkiem " + massLoaded + " kg z ciśnieniem " + _pressure + " atmosfer";
    }
}