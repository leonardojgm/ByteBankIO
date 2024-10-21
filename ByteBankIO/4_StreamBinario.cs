partial class Program
{
    static void EscritaBinaria()
    {
        using (FileStream fs = new FileStream("contaCorrente.txt", FileMode.Create))
        using (BinaryWriter escritor = new BinaryWriter(fs))
        {
            escritor.Write(456); //Número da agência
            escritor.Write(546544); //Número da conta
            escritor.Write(4000.50); //Saldo
            escritor.Write("Gustavo Braga");
        }
    }

    static void LeituraBinaria()
    {
        using (FileStream fs = new FileStream("contaCorrente.txt", FileMode.Open))
        using (BinaryReader leitor = new BinaryReader(fs))
        {
            int agencia = leitor.ReadInt32();
            int conta = leitor.ReadInt32();
            double saldo = leitor.ReadDouble();
            string titular = leitor.ReadString();

            Console.WriteLine($"{agencia}/{conta} {titular} {saldo}");
        }
    }
}
