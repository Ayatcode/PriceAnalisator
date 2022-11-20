

class Vihecle
{
	public string Color;
	public int Year;

	public Vihecle()
	{

	}
	
	public Vihecle(string Color)
	{
		this.Color = Color;
	}
	public Vihecle(string Color, int Year) : this(Color)
	{
		this.Year = Year;
	}
}


