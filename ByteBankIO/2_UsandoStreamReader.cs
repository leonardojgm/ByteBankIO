using ByteBankIO;

partial class Program
{
    static void UsandoStreamReader(string[] args)
    {
        string enderecoDoArquivo = "contas.txt";
        
        using (FileStream fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            StreamReader leitor = new StreamReader(fluxoDoArquivo);
            // string linha = leitor.ReadLine();

            // Console.WriteLine(linha);

            // string texto = leitor.ReadToEnd();

            // Console.WriteLine(texto);

            // int numero = leitor.Read();
            
            // Console.WriteLine(numero);

            while(!leitor.EndOfStream)
            {
                string linha = leitor.ReadLine();

                ContaCorrente contaCorrente = ConverterStringParaContaCorrente(linha);

                string msg = $"{contaCorrente.Titular.Nome} : Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";

                Console.WriteLine(msg);
            }
        }

        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        //375,4644,2483.13,Jonatan
        string[] campos = linha.Split(',');
        string agencia = campos[0];
        string numero = campos[1];
        string saldo = campos[2].Replace('.',',');
        string titular = campos[3];

        int agenciaComoInt = int.Parse(agencia);
        int numeroComoInt = int.Parse(numero);
        double saldoComoDouble = double.Parse(saldo);

        ContaCorrente resultado = new ContaCorrente(agenciaComoInt, numeroComoInt);

        resultado.Depositar(saldoComoDouble);
        resultado.Titular = new Cliente() { Nome = titular };

        return resultado;
    }
}
