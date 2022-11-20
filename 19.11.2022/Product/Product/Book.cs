internal class Book : Product
{
	public string authorName;
	public int pageCount;
	public int discountPercent;

	public Book()
	{

	}
	public Book(string name, int costPrice, int saledPrice, string authorName) : base(name, costPrice, saledPrice)
	{
		this.authorName = authorName;
	}
    public Book(string name, int costPrice, int saledPrice, string authorName,int pageCount) : this(name, costPrice, saledPrice,authorName) 
    {
        this.pageCount = pageCount;
    }
    public Book(string name, int costPrice, int saledPrice, string authorName, int pageCount,int discountPercent) : this(name, costPrice, saledPrice, authorName, pageCount)
    {
        this.discountPercent = discountPercent;
    }

	public string Getinfo()
	{
		return $"Name:{name} Costprice:{costPrice} Saledprice:{saledPrice} Author:{authorName} pageCount:{pageCount} dispercent:{discountPercent}";

	}
	public int GetDiscountedPrice()
	{
		return saledPrice=saledPrice-(saledPrice*discountPercent)/100;
	}
}	