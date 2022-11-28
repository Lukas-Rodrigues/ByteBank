using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using bytebank_ATENDIMENTO.ByteBank.Exceptions;
using bytebank_ATENDIMENTO.ByteBankAtendimento;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http.Headers;
#region Exemplos de arrays
int[] idade = new int[5];

//esse array é basicamente um vetor de 5 posições, entretando possui alguns metodos como Ordenar
//existe essas duas formas de fazer:
//Array array = Array.CreateInstance(typeof(int),5);
//Array aa = new double[5];
//AtribuindoValores(idade);
//Getvalores(idade);
//Console.WriteLine("A media é: "+MediaIdade(idade));
//TestaBuscarPalavra();
//TestaArrayDeContasCorrents();












void AtribuindoValores(int[] idade)
{
    for (int i = 0; i < 5; i++)
    {
        idade[i] = i + 1;
    }
}
void Getvalores(int[] idade)
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Idade no indice {i}: {idade[i]}");
    }
    AtribuindoValores(idade);

    Console.ReadKey();




}
double MediaIdade(int[] idade)
{
    double acumulador = 0;
    for (int i = 0; i < 5; i++)
    {
        acumulador += idade[i];
    }
    return acumulador / 5;
}
void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite a {i + 1}º palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }
    Console.WriteLine("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();
    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine("A palavra é: " + busca);
            break;
        }

    }



}
void TestaArrayDeContasCorrents()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    {
        listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
        listaDeContas.Adicionar(new ContaCorrente(884, "4456668-B"));
        listaDeContas.Adicionar(new ContaCorrente(147, "174785-C"));
        listaDeContas.Adicionar(new ContaCorrente(874, "5679787-D"));
        listaDeContas.Adicionar(new ContaCorrente(884, "4456668-E"));
        listaDeContas.Adicionar(new ContaCorrente(147, "174785-F"));
        var contaLucas = new ContaCorrente(2571, "174785-ZAZ");
        var contaJoao = new ContaCorrente(1247, "174785-635");
        listaDeContas.Adicionar(contaLucas);
        for (int i = 0; i < listaDeContas.Tamanho; i++)
        {
            ContaCorrente conta = listaDeContas[i];
            Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
        }

    };
}
#endregion 
#region
List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
{
    new ContaCorrente (95,"5871774-D"){Saldo=1000},
    new ContaCorrente(63, "36858414-E") { Saldo = 1000 },
    new ContaCorrente(95, "2155982-F") { Saldo = 1000 }
};
List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
{
    new ContaCorrente (95,"5871774-G"){Saldo=1000},
    new ContaCorrente(63, "36858414-H") { Saldo = 1000 },
    new ContaCorrente(95, "2155982-I") { Saldo = 1000 }
};

//metodo range - ele pega uma lista e coloca no final de outra  
_listaDeContas2.AddRange(_listaDeContas3);

//for(int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice [{i}] = conta [{_listaDeContas2[i].Conta}]");
//}
// 
//metodo GetRange vai passar apenas do indice 0 a 2. Que passaria o 0 e 1 para a variavel var   
var range = _listaDeContas2.GetRange(0, 2);
for (int i = 0; i < range.Count; i++)
{
    Console.WriteLine($"Indice [{i}] = conta [{range[i].Conta}]");
}


#endregion
#region 
//ArrayList é uma tipo de coleção de objetos. Dentro dele eu coloco objetos. 
//ArrayList _listaDeContas = new ArrayList()
//{
//    new ContaCorrente (95,"5871774-X"){Saldo=1000},
//    new ContaCorrente(63, "36858414-Y") { Saldo = 1000 },
//    new ContaCorrente(95, "2155982-Z") { Saldo = 1000 }
//};
//bool VerificaNomes(List<string> nomesDosEscolhidos, string escolhido)
//{
//    //verifica o que o ususario digitou e verifica se tem na coleção
//    return nomesDosEscolhidos.Contains(escolhido);
//}
#endregion

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

new ByteBankAtendimento().AtendimentoCliente();


