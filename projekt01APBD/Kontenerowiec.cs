namespace projekt01APBD;

public class Kontenerowiec
{
    private List<Kontener> _konteners = new List<Kontener>();
    private double _maxVelocity;
    private int _maxKontenersNumber;
    private double _maxKontenersWeight; // w tonach
    private double _sumWeight;
    private static int _counter = 0;
    public int Id { get; set; }
    
    
    public Kontenerowiec(double maxVelocity, int maxKontenersNumber, double maxKontenersWeight)
    {
        this._maxVelocity = maxVelocity;
        this._maxKontenersNumber = maxKontenersNumber;
        this._maxKontenersWeight = maxKontenersWeight;
        this._sumWeight = 0.0;
        _counter++;
        this.Id = _counter;
    }

    public void AddKontener(Kontener kontener)
    {
        if (_konteners.Exists(k => k == kontener))
        {
            throw new CannotAddKontenerException("Kontener " + kontener.SerialNo + " już znajduje się na statku " + Id);
        }
        if (_konteners.Count + 1 <= _maxKontenersNumber)
        {
            if (kontener.massLoaded + _sumWeight > _maxKontenersWeight)
            {
                throw new CannotAddKontenerException("Kontener jest zbyt ciężki, aby był dodany do kontenerowca.");
            } 
            else 
            {
                _konteners.Add(kontener);
                _sumWeight += kontener.massLoaded;
                kontener.KontenerowiecAssigned = this;
                Console.WriteLine("Załadowano kontener {0} na statek {1}", kontener.SerialNo, this.Id);
            }
        }
        else
        {
            throw new CannotAddKontenerException("Nie ma miejsca na kolejny kontener na kontenerowcu.");
        }
    }

    public void AddKonteners(List<Kontener> konteners)
    {
        foreach (Kontener kontener in konteners)
        {
            AddKontener(kontener);
        }
    }

    public void RemoveKontener(Kontener kontener)
    {
        bool success = _konteners.Remove(kontener);
        if (success)
        {
            _sumWeight -= kontener.massLoaded;
            kontener.KontenerowiecAssigned = null;
            Console.WriteLine("Usunięto kontener " + kontener.SerialNo + " ze statku " + Id);
        }
        else
        {
            Console.WriteLine("Kontenerowca " + kontener.SerialNo + " nie było na statku " + Id);
        }
    }

    public void Replace(Kontener k1, Kontener k2)
    {
        if (!_konteners.Exists(k => k == k1))
        {
            Console.WriteLine("Wskazany kontener " + k1.SerialNo + " nie znajduje się na statku.");
        }
        else if (_konteners.Exists(k => k == k2))
        {
            Console.WriteLine("Wskazany kontener " + k2.SerialNo + " już znajduje się na statku.");
        }
        else
        {
            int index = _konteners.IndexOf(k1);
            _konteners[index] = k2;
            Console.WriteLine("Na miejsce kontenera " + k1.SerialNo + " wstawiono kontener " + k2.SerialNo);
        }
    }
    
    public void AddWeight(double weight)
    {
        _sumWeight += weight;
    }

    public void SubtractWeight(double weight)
    {
        _sumWeight -= weight;
    }

    public string ToString()
    {
        string loaded = "";
        foreach (Kontener kontener in _konteners)
        {
            loaded += "- " + kontener.ToString() + "\n";
        }
        return "Kontenerowiec " + Id + " z ładunkiem: \n" + loaded;
    }
}