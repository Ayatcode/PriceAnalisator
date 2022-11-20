class Car : Vihecle
{
    public string Brand;
    public string model;
    public int Fuelcapacity;
    public int Fuelfor1km;
    public int CurrentFuel;

    public Car() 
    {

    }
    public Car(string Color, int Year, string Brand) :base(Color,Year)
    {

        this.Brand = Brand;

    }
    
    public Car(string Color, int Year, string Brand, string model, int Fuelcapacity, int Fuelfor1km, int CurrentFuel) : this(Color, Year,Brand)
    {
        this.Brand = Brand;
        this.model = model;
        this.Fuelcapacity = Fuelcapacity;
        this.CurrentFuel = CurrentFuel;
        this.Fuelfor1km = Fuelfor1km;


    }
    public string ShowInfo()
    {
        return $"Color:{Color} Brand:{Brand} Model{model} Year:{Year} Capacity:{Fuelcapacity} CurrentFuel:{CurrentFuel} Fuelforkm:{Fuelfor1km}" ;
    }
    public void Drive(int km) 
    {
        if((Fuelfor1km*km) <= Fuelcapacity)
        {
            Console.WriteLine("Yes u can");
        }
        else
        {
            Console.WriteLine("u dont have  fuel for that ");
        }
    }
}


