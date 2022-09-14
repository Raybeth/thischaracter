class Utils
{   
    public static string ReadString(string msj)
    {
        Console.Write(msj);
        return Console.ReadLine() ??"";
    }

    public static void Pausa(string msj)
    {
        Console.Write(msj);
        Console.ReadLine();


    }
}