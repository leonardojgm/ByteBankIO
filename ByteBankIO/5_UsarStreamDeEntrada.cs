partial class Program
{
    static void UsarStreamDeEntrada()
    {
        using (Stream fluxoDeEntrada = Console.OpenStandardInput())
        using (FileStream fs = new FileStream("entradaConsole.txt", FileMode.Create))
        {
            byte[] buffer = new byte[1024]; //1Kb

            while(true)
            {
                int bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                fs.Write(buffer, 0, bytesLidos);
                fs.Flush();

                Console.WriteLine($"Bytes lidos na console: {bytesLidos}");
            }
        }
    }
}
