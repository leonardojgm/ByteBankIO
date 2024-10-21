using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        string caminhoNovoArquivo = "contasExportadas.csv";

        using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            string contaComoString = "456,7895,4785.40,Gustavo Santos";
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = Encoding.UTF8.GetBytes(contaComoString);

            fluxoDeArquivo.Write(bytes, 0, bytes.Length);
        }
    }

    static void CriarArquivoComWrite()
    {
        string caminhoNovoArquivo = "contasExportadas.csv";

        using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
        {
            escritor.Write("456,65465,456.0,Pedro");
        }
    }

    static void TestaEscrita()
    {
        string caminhoNovoArquivo = "teste.txt";

        using (FileStream fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (StreamWriter escritor = new StreamWriter(fluxoDeArquivo))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush(); //Despeja o buffer para o Stream
                
                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }
        }
    }
}
