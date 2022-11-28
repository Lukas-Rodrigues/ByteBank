using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.ByteBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.ByteBankAtendimento
{
    public class ByteBankAtendimento
    {
        // código anterior omitido

        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>(){
            new ContaCorrente(95, "123456-X"){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Henrique"}},
            new ContaCorrente(95, "951258-X"){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Pedro"}},
            new ContaCorrente(94, "987321-W"){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Marisa"}}
        };

        // código posterior omitido
        // código anterior omitido

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
                    catch (Exception excecao)
                    {
                        throw new ByteBankException(excecao.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarConta();
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
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opcao não implementada.");
                            break;
                    }
                }
            }
            catch (ByteBankException excecao)
            {
                Console.WriteLine($"{excecao.Message}");
            }
        }

        private void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando a aplicação ...");
            Console.ReadKey();
        }
        void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    PESQUISAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2)CPF TITULAR ou (3) Número da Agência ou (4) Número da conta: :  ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Informe o número da Conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o CPF do Titular: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Write("Informe o Número da Agência: ");
                        int numeroAgencia = int.Parse(Console.ReadLine());
                        var contasPorAgencia = ConsultaPorAgencia(numeroAgencia);
                        ExibirListaDeContas(contasPorAgencia);
                        Console.ReadKey();
                        break;
                    }
                case 4:
                    {
                        Console.Write("Informe o Número da conta: ");
                        string numeroConta = Console.ReadLine();
                        var consultaPorConta = ConsultaPorConta(numeroConta);
                        ExibirListaDeContas(consultaPorConta);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }

        }

        private List<ContaCorrente> ConsultaPorConta(string? numeroConta)
        {
            var consulta = (
                from conta in _listaDeContas
                where conta.Conta == numeroConta
                select conta).ToList();
            return consulta;


        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("A consulta não retornou dados");
            }
            else
            {
                foreach (var item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }


        List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            var consulta = (

                           from conta in _listaDeContas
                           where conta.Numero_agencia == numeroAgencia
                           select conta).ToList();

            return consulta;

        }

        private ContaCorrente ConsultaPorCPFTitular(string? cpf)
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

        private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
        {
            //ContaCorrente conta = null;
            //for (int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}

            //lampda expressions
            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }

        private void OrdenarContas()
        {
            void OrdenarContas()
            {
                _listaDeContas.Sort();
                Console.WriteLine("... Lista de Contas ordenadas ...");
                Console.ReadKey();
            }
        }

        private void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      REMOVER CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Informe o número da Conta: ");
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
                Console.WriteLine(" ... Conta para remoção não encontrada ...");
            }
            Console.ReadKey();
        }
        private void ListarConta()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("===      LISTA DE CONTAS      ===");
            Console.WriteLine("======================================");
            Console.WriteLine("\n");
            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("====     Não há contas cadastradas    =====");
            }
            else
            {
                foreach (ContaCorrente item in _listaDeContas)
                {
                    //Console.WriteLine($" === DADOS DA CONTA === \n"); 
                    //Console.WriteLine($"Número da Conta : {item.Conta} \n");
                    //Console.WriteLine($"Saldo da Conta : {item.Saldo} \n");
                    //Console.WriteLine($"Titular da Conta: {item.Titular.Nome} \n");  
                    //Console.WriteLine($"CPF do Titular  : {item.Titular.Cpf} \n"); 
                    //Console.WriteLine($"Profissão do Titular: {item.Titular.Profissao}");
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.ReadKey();
                }
            }
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("===      CADASTRO DE CONTAS      ===");
            Console.WriteLine("======================================");
            Console.WriteLine("\n");
            Console.WriteLine("===    Informe dados da Conta     ==="); 
      
            Console.Write("Número da agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());
            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"Número da conta [NOVA]: {conta.Conta}");
            Console.Write("Informe o Saldo Inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());
            
            Console.Write("Informe o Titular da conta: ");
            conta.Titular.Nome = Console.ReadLine();
            
            Console.Write("Informe o cpf do titular: ");
            conta.Titular.Cpf = Console.ReadLine();
          
            Console.Write("Informe a profissao do titular: ");
            conta.Titular.Profissao = Console.ReadLine();
            _listaDeContas.Add(conta);
            
            Console.WriteLine("Conta cadastrada com sucesso! ... ");
            Console.ReadKey();
        }
        



    }
}
