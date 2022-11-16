#region TASK 1Bir method yazın parametr olaraq bir array və size parametrləri qəbul etsin etsin
//int[] arr = { 1, 2, 3, 4, 5 };
//int len= int.Parse(Console.ReadLine());


//void Resize(ref int[] arr,int len)
//{
//    int[] new_arr= new int[arr.Length+len];
//	for (int i = 0; i < arr.Length; i++)
//	{
//		new_arr[i]= arr[i];
//	}

//	foreach(int num in new_arr)
//	{
//		Console.WriteLine(num);
//	}

//}
//Resize(ref arr,len);
#endregion


#region TASK 2 Repeat

//string word=Console.ReadLine();
//int count=int.Parse(Console.ReadLine());	

//void Repeat(string word,int count)
//{
//	string res = String.Empty;
//	if (count < 0)
//	{
//		Console.WriteLine("menfi !!");
//	}
//	for (int i = 0; i < count; i++)
//	{
//		res += word;
//	}
//    Console.WriteLine(res);
//}
//Repeat(word, count);
#endregion


#region TASK 3 Sahe

//using System.Diagnostics.CodeAnalysis;

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = new int[3];
//        Console.WriteLine("1) Duzbucaqli,2)Daire,3)Ucbucaq");
//        int ask=int.Parse(Console.ReadLine());
//        if (ask == 1)
//        {
//        int num1=int.Parse(Console.ReadLine());
//        int num2 = int.Parse(Console.ReadLine());
//        if(num1>0 && num2 > 0)
//            {

//             Area(num1, num2);
//            }
//            else
//            {
//                Console.WriteLine("Menfi olmaz!");
//            }

//        }else if (ask == 2)
//        {
//            int num1 = int.Parse(Console.ReadLine());

//            AreaofSquare(num1);
//        }else if (ask == 3)
//        {
//            int num1 = int.Parse(Console.ReadLine());
//            for (int i = 0; i < 3; i++)
//            {
                
//                int num2 = int.Parse(Console.ReadLine());
//                if (num2 > 0)
//                {

//                arr[i] = num2;
//                }
//                else
//                {
//                    Console.WriteLine("menfi olmaz");
//                }
                
//            }
//            Area(num1,arr);

//        }
//        else
//        {
//            Console.WriteLine("Secim et!!");
//        }

        

//    }

//    public static void Area(int num1, int num2)
//    {
//        Console.WriteLine($"Duzbucaqli:{ num1* num2}");
//    }

//    public static void AreaofSquare(int num1,int pi=3)
//    {
//        Console.WriteLine($"Daire:{ num1* num1*3}");
//    }
//    public  static void Area(int num1, params int []num2)
//    {
//        int sum = 0;
//        int p = 0;
//        if (num2.Length == 3)
//        {
//        foreach (var nums in num2)
//        {
//                sum += nums;
//        }
//        p= sum/2;
//        Console.WriteLine(num1 * p);
//        }
//        else
//        {
//            Console.WriteLine("3 eded olmalidi");
//        }
//    }

//}
#endregion