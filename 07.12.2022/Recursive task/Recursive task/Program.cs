void  Func(DirectoryInfo folder)
{
    List<string> res=new();
   if(folder.GetDirectories().Length>0)
    {
        foreach (var item in folder.GetDirectories())
        {
            Console.WriteLine(item);
            Func(item);
        }
        
    }
   
    
}


DirectoryInfo res = new(@"C:\\Users\\User\\Desktop\\check");

Func(res);