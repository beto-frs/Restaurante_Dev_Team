using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ConsoleApp2
{
    class Program
    {

        public static dynamic Pessoas = new List<dynamic>();
        public static List<int> MesaDisponivel = new List<int>();
        public static List<string> Sorteio = new List<string>();
        public static List<string> Playground = new List<string>();
        public static List<string> Eventos = new List<string>();
        public static int QuantidadeMesa;

        static void Main(string[] args)
        {
            OrganizacaoEvento();
        }

        static void ListaMesa(int quant)
        {
            for (int i = 0; i < quant; i++)
            {
                MesaDisponivel.Add(i + 1);
            }
        }

        static void OrganizacaoEvento()
        {
            Console.Clear();
            Console.WriteLine("============================== {{ SISTEMA DE ORGANIZAÇÃO }} ==============================\n\n");
            Console.Write("Digite o nome do evento: ");
            string NomeEvento = Console.ReadLine();
            Eventos.Add(NomeEvento);
            Console.Write("\nQuantas mesas serão reservadas? :");
            QuantidadeMesa = Int32.Parse(Console.ReadLine());
            ListaMesa(QuantidadeMesa);
            for (int i = 0; i < QuantidadeMesa; i++)
            {
                Pessoas.Add(DadosPessoasEvento(NomeEvento, i));
            }
            
        }

        static void QuantidadeEventos()
        {
            foreach (var item in Eventos)
            {
                Console.WriteLine(item);
            }
        }

        static bool VerificaMesa(int numeroMesa)
        {
            if (numeroMesa > 0 && numeroMesa <= QuantidadeMesa)
            {
                foreach (var item in MesaDisponivel)
                {

                    if (numeroMesa == item)
                    {
                        MesaDisponivel.Remove(numeroMesa);
                        return false;
                    }
                   
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mesa ocupada, favor escolha outra mesa");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Mesas Disponíveis: ");

                foreach (var listar in MesaDisponivel)
                {
                    Console.Write($" - {listar}");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mesa indisponível para esse evento, favor escolha outra mesa");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Mesas Disponíveis: ");
                foreach (var listar in MesaDisponivel)
                {
                    Console.Write($" - {listar}");
                }
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
        }

        static object DadosPessoasEvento(string evento, int pos)
        {
            Console.Clear();
            if (pos > 0)
            {
                Console.WriteLine($"{pos} Mesa(s) ocupada(s).");
            }
            Console.Write("Digite o nome do convidado: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());
            int mesa;
            do
            {
                Console.Write("Digite o número da mesa: ");
                mesa = Convert.ToInt32(Console.ReadLine());

            } while (VerificaMesa(mesa));

            dynamic Convidado = new
            {
                Evento = evento,
                Nome = nome,
                Idade = idade,
                Mesa = mesa,
                Despesa = 0.0,
                Time = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now)
            };

            if (idade < 18)
            {
                Playground.Add(nome);
            }
            else
            {
                Sorteio.Add(nome);
            }
            return Convidado;
        }


        static void DataString()
        {
            var date = String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            Console.WriteLine(date);

            var date2 = String.Format($"{DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine(date2);
            Console.ReadKey();
        }

        static void Original()
        {
            /*
            "Jogo do chute", o usuário tem que acertar o número
            aleatório escolhido pelo computador, ao acertar o computador 
            imprime na tela o número de chutes que foram necessários.
            */

            int qtd_chutes = 1;

            while (true)
            {
                Console.Write("Digite um numero (entre 0-100): ");
                int chute = int.Parse(Console.ReadLine());

                if (chute > 45)
                {
                    Console.WriteLine("Seu chute foi muito alto...");
                }
                else if (chute < 45)
                {
                    Console.WriteLine("Seu chute foi muito baixo...");
                }
                else
                {
                    break;
                }
                qtd_chutes += 1;
            }
            Console.WriteLine($"Você acertou o numero em {qtd_chutes} tentativas!");
        }

        static void PrimeiroDesafio()
        {
            /*
            "Jogo do chute", o usuário tem que acertar o número
            aleatório escolhido pelo computador, ao acertar o computador 
            imprime na tela o número de chutes que foram necessários.
            */
            Random aleatorio = new Random();
            int chances = 0, chutes = 0;
            int tentativa = aleatorio.Next(1, 20);
            string resultado = string.Empty;

            do
            {
                Console.WriteLine("Digite um numero (entre 1-20):");
                for (int num = 0; num < 10; num++)
                {
                    chances = int.Parse(Console.ReadLine());

                    if (chances > tentativa)
                    {
                        Console.WriteLine("Seu chute foi muito alto...");
                        chutes++;
                    }
                    else if (chances < tentativa)
                    {
                        Console.WriteLine("Seu chute foi muito baixo...");
                        chutes++;
                    }
                    else
                    {
                        chutes++;
                        Console.WriteLine($"Parabéns, vc acertou! Com {chutes} chutes");
                        break;
                    }

                }
                break;
            } while (chances != tentativa);
            Console.WriteLine($"O valor sorteado é: {tentativa}");
        }

        static void SegundoDesafio()
        {
            double media = 0;
            string[] ListaAlunos = new string[5];
            Console.WriteLine("vamos calcular a idade de 5 alunos");

            for (int i = 0; i < ListaAlunos.Length; i++)
            {
                Console.Write("\nDigite o nome do aluno:");
                string nome = Console.ReadLine();

                Console.Write("Digite a idade:");
                int idade = int.Parse(Console.ReadLine());
                media += idade;

                ListaAlunos[i] = $"O aluno {nome} tem {idade} anos de idade";

            }
            Console.WriteLine("\n");

            for (int i = 0; i < ListaAlunos.Length; i++)
            {
                Console.WriteLine(ListaAlunos[i]);
            }
            Console.WriteLine($"\n\nA média de idade dos alunos é {Math.Round(media / ListaAlunos.Length, 2)}");
        }

        static void TerceiroDesafio()
        {

            int numero = 0, valorSolicitado = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Verifique se o número informado é par ou ímpar");
                Console.Write("Informe o valor: ");
                numero = Convert.ToInt32(Console.ReadLine());
                if (numero % 2 == 0)
                {
                    Console.WriteLine("Número informado é PAR...");
                }
                else
                {
                    Console.WriteLine("Número informado é ÍMPAR...");
                }
                Console.WriteLine("Deseja verificar outro número?\n S -> Sim | N -> Não:");
                string escolha = Console.ReadLine().ToUpper();

                if (escolha == "N")
                {
                    break;
                }
            }
        }

    }

}
