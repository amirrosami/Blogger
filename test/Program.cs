namespace test;
public class program
{
    public static void Main()
    {
        var x = new amir();
        Console.Write(x.id);
    }
}

public class amir
{
    public int id { get;}
    public int age { get; set; }

    public amir()
    {
        id = 1;
    }
}