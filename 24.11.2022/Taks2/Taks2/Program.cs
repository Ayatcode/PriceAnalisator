using Taks2;

Console.WriteLine("name");
string name=Console.ReadLine();


Console.WriteLine("surname");
string surname = Console.ReadLine();


Console.WriteLine("group name");
string group = Console.ReadLine();

Student student=new(group,name,surname);


student.Getinfo();