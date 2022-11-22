BuilderString BuilderString=new BuilderString();

BuilderString.Append('a');
BuilderString.Append('b');
BuilderString.Append('c');
BuilderString.Append('d');
BuilderString.Append('a');
BuilderString.Append('f');
BuilderString.Append('a');


BuilderString.Remove(2,5);

Console.WriteLine(BuilderString);