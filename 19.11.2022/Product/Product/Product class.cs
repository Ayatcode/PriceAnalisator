


internal class Product
{
    public string name;
    public int costPrice;
    public int saledPrice;

    public Product()
    {

    }
    public Product(string name)
    {
        this.name = name;
    }
    public Product(string name, int costPrice) : this(name) 
    {
        this.costPrice = costPrice;
    }
    public Product(string name, int costPrice, int saledPrice) : this(name,costPrice)
    {
        this.costPrice= costPrice;
    }

}


