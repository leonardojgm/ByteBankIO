﻿partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite o seu nome:");

        string nome = Console.ReadLine();

        Console.WriteLine($"Olá, {nome}");

        string[] linhas = File.ReadAllLines("contas.txt");

        Console.WriteLine(linhas.Length);

        foreach (string linha in linhas)
        {
            Console.WriteLine(linha);
        }

        var bytesArquivo = File.ReadAllBytes("contas.txt");

        Console.WriteLine($"Arquivo contas.txt possui: {bytesArquivo.Length} bytes");

        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");
        
        Console.WriteLine("Aplicação Finalizada...");
        Console.ReadLine();
    }
}
