namespace projekt01APBD;

public class CKontener : Kontener, IHazardNotifier
{
    private List<string> _productTypes = new List<string>();
    private double _temperature; // nie może być niższa niż wymagana przez produkt
    
    private static Dictionary<string, double> possibleTemp = new Dictionary<string, double>
    {
        {"Bananas", 13.3},
        {"Chocolate", 18 },
        {"Fish", 2},
        {"Meat", -15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    
    public CKontener(double height, double massWithoutLoad, double depth, double maxLoad, double temperature) : base(height, massWithoutLoad, depth, maxLoad)
    {
        this._temperature = temperature;
        foreach (var product in possibleTemp)
        {
            if (product.Value <= temperature)
            {
                _productTypes.Add(product.Key);
            }
        }
        this.SerialNo = "C";
    }

    public void Load(double loadWeight, string productType)
    {
        base.Load(loadWeight);
        if (!_productTypes.Contains(productType))
        {
            SendMessage("Próba załadowania produktu do kontenera ze zbyt niską temperaturą. NIE ZAŁADOWANO.", SerialNo);
        }

        massLoaded += loadWeight;
        if (KontenerowiecAssigned != null) KontenerowiecAssigned.AddWeight(loadWeight);
        Console.WriteLine("Załadowano kontener " + SerialNo);
    }
    
    public void SendMessage(string msg, string serialNo)
    {
        Console.WriteLine("Kontener na płyny {0} z niebezpieczną sytuacją: {1}", serialNo, msg);
    }

    public List<string> getProductTypes()
    {
        return _productTypes;
    }

    public override string ToString()
    {
        return "Kontener chłodniczy " + SerialNo + " z ładunkiem " + massLoaded + " kg z temperaturą " + _temperature + " stopni";
    }
}