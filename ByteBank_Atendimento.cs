using bytebank.Modelos.Conta;
using ByteBankArray.bytebank_ATENDIMENTO.byteBank.Exceptions;

namespace ByteBankArray
{
    public class ByteBank_Atendimento
    {
        List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
            {
                new ContaCorrente(95) {Saldo=100, Titular = new Cliente{Cpf="11111", Nome="Henrique" } },
                new ContaCorrente(95) {Saldo=200, Titular = new Cliente{Cpf="22222", Nome="Pedro" }},
                new ContaCorrente(94) {Saldo=60, Titular = new Cliente{Cpf="33333", Nome="Marisa" }}
            };

        public ByteBank_Atendimento()
        {
        }

        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("===1 - Cadastrar Conta      ===");
                    Console.WriteLine("===2 - Listar Contas        ===");
                    Console.WriteLine("===3 - Remover Conta        ===");
                    Console.WriteLine("===4 - Ordenar Contas       ===");
                    Console.WriteLine("===5 - Pesquisar Conta      ===");
                    Console.WriteLine("===6 - Sair do Sistema      ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");

                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception ex)
                    {

                        throw new ByteBankException(ex.Message);
                    }


                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            Console.WriteLine("Saindo do sistema, tchau!");
                            break;
                        default:
                            Console.WriteLine("Opcao não implementada.");
                            break;
                    }
                }
            }
            catch (ByteBankException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("====== Pesquisar contas ========");
            Console.WriteLine("=============================");
            Console.WriteLine("\n");
            Console.WriteLine("Deseja pesquisar por (1) NUMERO DA CONTA ou (2) CPF TITULAR? ou (3) N° DA AGÊNCIA");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.WriteLine("Informe o número da conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        if (consultaConta != null)
                        {
                            Console.WriteLine(consultaConta.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Consulta não encontrada");
                        }

                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Informe o CPF do titular: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCpfTitulat(_cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Informe o n° da agência:");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        List<ContaCorrente> contasPorAgencia = ConsultaPorAgencia(_numeroAgencia, _listaDeContas
);
                        ExibirListaDeContas(contasPorAgencia);

                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }
        }

        void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia != null)
            {
                foreach (ContaCorrente item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("... A consulta não retornou dados ...");
            }

        }

        List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia, List<ContaCorrente> _listaDeContas)
        {
            List<ContaCorrente> consulta = (
                from conta in _listaDeContas
                where conta.Numero_agencia == numeroAgencia
                select conta
            ).ToList();

            if (consulta.Count() == 0)
            {
                consulta = null;
            }

            return consulta;
        }

        ContaCorrente ConsultaPorCpfTitulat(string? cpf)
        {
            //ContaCorrente conta = null;

            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;

            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
        }

        ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
        {
            //ContaCorrente conta = null;

            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //return conta;

            ContaCorrente consulta = (
                from conta in _listaDeContas
                where conta.Conta == numeroConta
                select conta).FirstOrDefault();

            return consulta;
        }

        void OrdenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de Contas ordenadas ...");
            Console.ReadKey();
        }

        void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("====== Remover contas ========");
            Console.WriteLine("=============================");
            Console.WriteLine("\n");
            Console.WriteLine("Informe o número da Conta: ");
            string numeroConta = Console.ReadLine();

            ContaCorrente conta = null;
            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }

            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("... Conta removida da lista! ...");
            }
            else
            {
                Console.WriteLine("... Conta para remoção não encontrada...");
            }
            Console.ReadKey();
        }

        void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     LISTA DE CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }

            foreach (ContaCorrente item in _listaDeContas)
            {
                //Console.WriteLine("===  Dados da Conta  ===");
                //Console.WriteLine("Número da Conta : " + item.Conta);
                //Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
                //Console.WriteLine("CPF do Titular  : " + item.Titular.Cpf);
                //Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                //Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                Console.WriteLine(item.ToString());
                Console.ReadKey();
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            }
        }

        void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");

            Console.Write("Número da conta: ");
            string numeroConta = Console.ReadLine();

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");

            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Infome nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Infome CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Infome Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }

    }
}
