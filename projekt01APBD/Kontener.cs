namespace projekt01APBD;

public abstract class Kontener
{
    public double massLoaded { get; set; }
    protected double height;
    protected double massWithoutLoad { get; set; }
    protected double depth;
    protected double maxLoad { get; set; }
    protected static int counter = 1;
    private Kontenerowiec? kontenerowiecAssigned { get; set; }
    private string _serialNo;

    public Kontenerowiec? KontenerowiecAssigned { get; set; }
    public string SerialNo
    {
        get { return _serialNo; }
        set { _serialNo = "KON-"+value+"-"+counter++; Console.WriteLine(_serialNo + " stworzony. "); }
    }


    protected Kontener(double height, double massWithoutLoad, double depth, double maxLoad)
    {
        this.massLoaded = 0;
        this.height = height;
        this.massWithoutLoad = massWithoutLoad;
        this.depth = depth;
        this.maxLoad = maxLoad;
        this.kontenerowiecAssigned = null;
    }

    public virtual void Unload()
    {
        KontenerowiecAssigned.SubtractWeight(massLoaded);
        massLoaded = 0;
    }

    public void Load(double loadWeight)
    {
        if (massLoaded + loadWeight > maxLoad) throw new OverfillException();
    }

    public void ChangeKontenerowiec(Kontenerowiec kontenerowiec)
    {
        KontenerowiecAssigned.RemoveKontener(this);
        kontenerowiec.AddKontener(this);
        kontenerowiecAssigned = kontenerowiec;
    }
    
    public abstract string ToString();
}