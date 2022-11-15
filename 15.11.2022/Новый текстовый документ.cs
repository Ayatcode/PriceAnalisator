

int Len = int.Parse(Console.ReadLine());
var arr = new int[Len];
int res = 0;

for (int i = 0; i < Len; i++)
{
    int num = int.Parse(Console.ReadLine());
    arr[i] = num;
}
foreach (var elem in arr)
{
    if (elem % 2 == 0)
    {
        res += elem;
    }
}
Console.WriteLine(res);