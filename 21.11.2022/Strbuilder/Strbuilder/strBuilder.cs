class BuilderString
{
    private char[] _arr;
    public int Capacity { get; set; }
    public BuilderString()
    {
        Capacity = 0;
        _arr = new char[Capacity];
    }

    public BuilderString(int capacity)
    {
        Capacity = capacity;
        _arr = new char[Capacity];
    }

    public void Append(char symbol)
    {
        if (Capacity == 0)
        {
            Capacity = 16;
            Array.Resize(ref _arr, Capacity);
        }
        if (_arr[Capacity - 1] != 0)
        {
            Capacity *= 2;
            Array.Resize(ref _arr, Capacity);
            _arr[Capacity / 2] = symbol;
            return;
        }

        for (int i = 0; i < Capacity; i++)
        {
            if (_arr[i] == 0)
            {
                _arr[i] = symbol;
                break;
            }

        }
    }

    public BuilderString Replace(char oldVal, char newVal)
    {
        for (int i = 0; i < Capacity; i++)
        {
            if (_arr[i] == 0) break;
            if (_arr[i] == oldVal)
            {
                _arr[i] = newVal;
            }
        }
        return this;
    }

    public override string ToString()
    {
        string result = string.Empty;
        foreach (char item in _arr)
        {
            if (item == 0) break;
            result += item;
        }
        return result;
    }

    public void Append(string symbol)
    {
        for (int i = 0; i < symbol.Length; i++)
        {
            Append(symbol[i]);
        }
    }
    public void Remove(int starindex,int lastindex)
    {
        for (int i = starindex; i < _arr.Length; i++)
        {
            _arr[i] =' ';
        }
    }
}
