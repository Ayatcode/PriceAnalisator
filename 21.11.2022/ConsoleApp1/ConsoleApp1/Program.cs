
class Strbuilder
{

	string str;
	int index;
	int count;
	string letter;
	string new_letter;

	public Strbuilder()
	{

	}

	public void Capacity(ref string[] str,int count=16)
	{
		while (str.Length > count)
		{
			count = count * 2;
			
		}
		string[] strings= new string[count];
	}
	public void Clear(string[] str)
	{
		for (int i = 0; i < str.Length; i++)
		{
			str[i] = null;
		}
		Console.WriteLine(str.Length);
	}

	public void Append(ref string[] str, string new_letter)
	{
		string[] array_new = new string[str.Length + 1];

		array_new[str.Length] = new_letter;
		Console.WriteLine(array_new);
	}

	public void Remove(ref string[] str, string letter)
	{
		string[] res = new string[str.Length];
		for (int i = 0; i < res.Length; i++)
		{
			if (str[i] == letter)
			{
				res[i] = null;
			}
			else
			{
				res[i] = str[i];
			}
		}
		for (int i = 0; i < res.Length; i++)
		{
			Console.WriteLine(res[i]);
		};
	}
	public void Replace(ref string[] str,string letter,string new_letter)
	{
        string[] res = new string[str.Length];
        for (int i = 0; i < str.Length; i++)
		{
			if (str[i] == letter)
			{
				res[i] = new_letter;
			}
			else
			{
				res[i] = str[i];
			}
		}
	}

    public void Replace(ref string[] str, string letter, string new_letter,int index)
    {
        string[] res = new string[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == letter && i>=index)
            {
                res[i] = new_letter;
            }
            else
            {
                res[i] = str[i];
            }
        }
    }

    public void Replace(ref string[] str, string letter, string new_letter, int index,int count)
    {
        string[] res = new string[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == letter && i >= index && i<=index+count)
            {
                res[i] = new_letter;
            }
            else
            {
                res[i] = str[i];
            }
        }
		for (int i = 0; i < str.Length; i++)
		{
			Console.WriteLine(res[i]);
		}
    }



}



