using System.Text;
using ByteBankIO;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {
        string enderecoDoArquivo = "contas.txt";
        using (FileStream fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            int numeroDeBytesLidos = -1;
            byte[] buffer = new byte[1024]; //1KB

            // Devoluções:
            // O número total de bytes lidos do buffer. Isso poderá ser menor que o número de 
            // bytes solicitados se esse número de bytes não estiver disponível no momento, ou 
            // zero, se o final do fluxo for atingido

            while(numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                Console.WriteLine($"\n Bytes lidos: {numeroDeBytesLidos} \n");

                EscreverBuffer(buffer, numeroDeBytesLidos);
            }

            fluxoDoArquivo.Close();
        }

        ContaCorrente conta = new ContaCorrente(524, 4518);

        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        string texto = utf8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);

        /*
        foreach (var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
        */
    }
}
