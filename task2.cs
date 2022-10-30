#region  Task1
//int num = 256;
//int i = 2;

//while (num >= i)
//{

//    if (num == i)
//    {
//        system.console.writeline("2 ededin quvvetidir"); 

//    }
//    else if (num < i)
//    {
//        system.console.writeline("2 ededin quvveti deyil"); 
//    }
//    i = i * 2;
//}
#endregion
#region Task 2
int number = 26;
int tNumber = 0;
int rem = 0;
int rev = 0;
 tNumber=number


while (number > 0)
{
    rem = number % 10;
    rev = rev * 10 + rem;
    number = number / 10;

}


if (rev == tNumber)
    Console.WriteLine("Given Number is Palindrome");
else
    Console.WriteLine("Given Number is not a Palindrome");
#endregion
#region task3

//int num = 15;
//int i = 1;
//int count = 0;

//while (i <= num)
//{
//    if (num % i == 0)
//    {
//        count++;
//    }
//    i++;
//}
//if (count == 2)
//{
//    System.Console.WriteLine("sade ededir"); 
//}
//else
//{
//    System.Console.WriteLine("murekkeb ededir");
//}
#endregion
#region Task4

// int month = 4;

//switch (month)
//{
//    case 1:
//    case 2:
//    case 3:
//        System.Console.WriteLine("Winter");
//        break;
//    case 4:
//    case 5:
//    case 6:
//        System.Console.WriteLine("Spring");
//        break;
//    case 7:
//    case 8:
//    case 9:
//        System.Console.WriteLine("Summer");
//        break;
//    case 10:
//    case 11:
//    case 12:
//        System.Console.WriteLine("Autumn");
//        break;
//    default:
//        System.Console.WriteLine("Error");
//}

#endregion



