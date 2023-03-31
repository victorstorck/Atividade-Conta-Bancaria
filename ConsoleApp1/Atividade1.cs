namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carteira> carteiras = new List<Carteira>();
            string entrada;
            do
            {
                Console.WriteLine("Digite 1 para criar conta:");
                Console.WriteLine("Digite 2 para Acessar conta:");
                Console.WriteLine("Digite 3 para Listar Todas as contas:");
                Console.WriteLine("Digite 4 para sair:");

                entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":
                        Carteira novaCarteira = CriarConta();
                        carteiras.Add(novaCarteira);
                        break;

                    case "2":
                        Console.WriteLine("Entre com Nome de acesso:");
                        string dono = Console.ReadLine();
                        Carteira catual = carteiras.FirstOrDefault(o => o.Dono == dono);
                        if (catual != null)
                            AcessarCarteira(catual, carteiras);
                        else
                            Console.WriteLine("Acesso negado!");
                        break;
                    case "3":
                        foreach (var c in carteiras)
                            Console.WriteLine($"{c.Dono} Saldo:R${c.Saldo}");
                        break;
                    
                }
            } while (entrada != "4");

        }

        public static Carteira CriarConta()
        {
            string Nome; double Valor;
            Console.WriteLine("Entre com nome do Titular:");
            Nome = Console.ReadLine();
            Console.WriteLine("Entre com valor do 1° deposito:");
            Valor = Convert.ToDouble(Console.ReadLine());
            Carteira carteira = new Carteira();
            carteira.Dono = Nome;
            carteira.Depositar(Valor);
            return carteira;
        }

        public static void AcessarCarteira(Carteira carteira, List<Carteira> dados)
        {
            Console.WriteLine("Digite 1 para transferir");
            Console.WriteLine("Digite 2 para sacar");
            Console.WriteLine("Digite 3 para depositar");
            Console.WriteLine("Digite 4 para consultar o saldo");

            string entrada = Console.ReadLine();
            switch (entrada)
            {
                case "1": Transferir(carteira, dados);
                    break;

                case "2": Sacar(carteira); 

                    break;

                case "3":Depositar(carteira);

                    break;

                case "4": Console.WriteLine("O saldo da conta é: " + carteira.Saldo);

                    break;
            }

         
        }

        public static void Depositar(Carteira carteira)
        {
            Console.WriteLine("Entre com o valor do depósito:");
            double valor = Convert.ToDouble(Console.ReadLine());

            bool DepositarOK = carteira.Depositar (valor);

            if (DepositarOK)
            {
                Console.WriteLine("Depósito realizado com sucesso!");
            }

            else
            {
                Console.WriteLine("Falha no depósito");
            }
        }

        public static void Sacar(Carteira carteira)
        {
            Console.WriteLine("Entre com o valor de saque:");
            double valor = Convert.ToDouble(Console.ReadLine());

            bool SacarOK = carteira.Sacar(valor);

            if (SacarOK)
            {
                Console.WriteLine("Saque realizado com sucesso!");
            }

            else
            {
                Console.WriteLine("Falha ao sacar");
            }

        }

        private static void Transferir(Carteira carteira, List<Carteira> dados)
        {
            Console.WriteLine("Entre com a carteira de destino");
            string dono = Console.ReadLine();

            Carteira destino = dados.FirstOrDefault(o => o.Dono == dono);
            if (destino == null)//se o destino não for encontrado
            {
                Console.WriteLine("Destinatario invalido");
                return;
            }

            Console.WriteLine("Entre com valor:");
            double valor = Convert.ToDouble(Console.ReadLine());
            //realiza a trasferencia e retrona um bool se ocorreu com sucesso ou nao
            bool tOk = carteira.Transferir(destino, valor);

            if (tOk)
                Console.WriteLine("Transferencia realizada com sucesso!");
            else
                Console.WriteLine("ERRO- transacao abortada!");
        }
    }
}