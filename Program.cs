using System;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();

        static void Main(string[] args)
        {
            CriarLista();
            //ExemplosListasColecoes();
            ObterPorNome();
            ObterFuncionariosRecentes();
            ObterEstatisticas();
            ValidarSalarioAdmissao();
            ValidarNome();
            ObterPorTipo();
        }

        public static void ExemplosListasColecoes()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
            Console.WriteLine("=================================================="); CriarLista();
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("---Digite o número referente a opção desejada: ---");
                Console.WriteLine("1 - Obter Por Id");
                Console.WriteLine("2 - Adicionar Funcionário");
                Console.WriteLine("3 - Obter por Id digitado");
                Console.WriteLine("4 - Obter por Salário digitado");
                Console.WriteLine("5 - Ordenar Funcionários");
                Console.WriteLine("6 - Contar Funcionários");
                Console.WriteLine("7 - Somar Salários");
                Console.WriteLine("8 - Exibir Aprendizes");
                Console.WriteLine("9 - Buscar por nome aproximado");
                Console.WriteLine("10 - Buscar por CPF e remover");
                Console.WriteLine("11 - Remover Id menor que 4");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");

                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                    case 1:
                        ObterPorId();
                        break;
                    case 2:
                        AdicionarFuncionario();
                        break;
                    case 3:
                        Console.WriteLine("Digite o Id do funcionário que você deseja buscar:");
                        int id = int.Parse(Console.ReadLine());
                        ObterPorIdDigitado(id);
                        break;
                    case 4:
                        Console.WriteLine("Digite o salário para obter todos acima do valor indicado:");
                        decimal salario = decimal.Parse(Console.ReadLine());
                        ObterPorSalario(salario);
                        break;
                    case 5:
                        Ordenar();
                        break;
                    case 6:
                        ContarFuncionarios();
                        break;
                    case 7:
                        SomarSalarios();
                        break;
                    case 8:
                        ExibirAprendizes();
                        break;
                    case 9:
                        BuscarPorNomeAproximado();
                        break;
                    case 10:
                        BuscarPorCpfRemover();
                        break;
                    case 11:
                        RemoverIdMenor4();
                        break;
                    default:
                        Console.WriteLine("Saindo do sistema....");
                        break;
                }
            } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);
            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
        }



        public static void RemoverIdMenor4()
        {
            lista.RemoveAll(x => x.Id < 4);
            ExibirLista();
        }



        public static void BuscarPorCpfRemover()
        {
            Funcionario fBusca = lista.Find(x => x.Cpf == "01987654321");
            lista.Remove(fBusca);
            Console.WriteLine($"Personagem removido: {fBusca.Nome} \nLista Atualizada: \n ");

            ExibirLista();
        }



        public static void BuscarPorNomeAproximado()
        {

            lista = lista.FindAll(x => x.Nome.ToLower().Contains("ronaldo"));
            ExibirLista();
        }


        public static void ExibirAprendizes()
        {
            lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            ExibirLista();
        }


        public static void SomarSalarios()
        {
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format("A soma dos salários é  {0:c2}.", somatorio));
        }


        public static void ContarFuncionarios()
        {
            int qtd = lista.Count();
            Console.WriteLine($"Existem {qtd} funcionários.");
        }



        public static void Ordenar()
        {
            lista = lista.OrderBy(x => x.Nome).ToList();
            ExibirLista();
        }


        public static void ObterPorSalario(decimal valor)
        {
            lista = lista.FindAll(x => x.Salario >= valor);
            ExibirLista();
        }


        public static void ObterPorIdDigitado(int id)
        {
            Funcionario fBusca = lista.Find(x => x.Id == id);

            Console.WriteLine($"Personagem encontrado: {fBusca.Nome}");
        }


        public static void AdicionarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            f.Nome = Console.ReadLine();

            Console.WriteLine("Digite o salário: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(f.Nome))
            {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            }
            else if (f.Salario == 0)
            {
                Console.WriteLine("Valor do salário não pode ser 0");
                return;
            }
            else
            {
                lista.Add(f);
                ExibirLista();
            }
        }


        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "===============================\n";
            }
            Console.WriteLine(dados);
        }


        public static void ObterPorId()
        {
            //lista = lista.FindAll(x => x.Id == 1);
            Console.WriteLine("Digite o ID:");
            lista = lista.FindAll(x => x.Id > 4);
            ExibirLista();
        }


        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 150.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Rodrigo Garro";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }



        /*A - Método com nome ObterPorNome que selecione um funcionário de acordo com o nome 
        digitado e que caso não encontre retorne uma mensagem para o usuário.*/
        public static void ObterPorNome()
        {
            Console.WriteLine("==================================================");
            
            Console.WriteLine("Digite um Nome: ");
            String Nome = Console.ReadLine();


            var funcionario = lista.FirstOrDefault(f =>f.Nome.Equals(Nome, StringComparison.OrdinalIgnoreCase));

            if (funcionario != null)
            {
                
                Console.WriteLine($"Funcionário encontrado: {funcionario.Nome}, Salário: {funcionario.Salario}");
                Console.WriteLine("==================================================");
            }
            else
            {
                Console.WriteLine("Funcionário não existe.");
            }  

            Console.WriteLine("==================================================");
        }

        

        /*B - Método com nome ObterFuncionariosRecentes que remova os funcionários com Id menor que 4 e depois
        faça um filtro na lista para exibi-la em ordem decrescente de Salário.*/

        public static void ObterFuncionariosRecentes()
        {
            Console.WriteLine("==================================================");
            
            Console.WriteLine("Digite 1 para exibir os funcionários recentes:");
            string comando = Console.ReadLine();
            lista.RemoveAll(f => f.Id < 1);
            var funcionariosOrdenados = lista.OrderByDescending(f => f.Salario).ToList();

            Console.WriteLine("Funcionários recentes em ordem decrescente de salário:");
            foreach (var f in funcionariosOrdenados)
            {
                Console.WriteLine($"{f.Nome} - {f.Salario}");
            }

            Console.WriteLine("==================================================");
        }


        /*C - Método com nome ObterEstatisticas que exiba a quantidade de funcionários 
        da lista e qual o somatório de salário dos funcionários. */

        public static void ObterEstatisticas()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Estátisticas: ");

            int quantidade = lista.Count;
            decimal somatorioSalario = lista.Sum(f => f.Salario);

            Console.WriteLine($"Quantidade de funcionários: {quantidade}");
            Console.WriteLine($"Somatório dos salários: {somatorioSalario}");

            Console.WriteLine("==================================================");
        }


        /*D - Método com nome ValidarSalarioAdmissao que não permita que um funcionário seja adicionado com
        salário 0 ou data de admissão anterior a data atual. Deve ser exibida uma mensagem ao usuário caso isso aconteça.*/
        public static void ValidarSalarioAdmissao()
        {
            Console.WriteLine("==================================================");
            
            Console.WriteLine("Digite o salário do funcionário: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal Salario) || Salario <= 0)
            {
                Console.WriteLine("Erro: O salário não pode ser 0 ou negativo.");
            }
            else
            {
        
                Console.WriteLine("Digite a data de admissão do funcionário (formato: dd/MM/yyyy): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime DataAdmissao))
                {
                    Console.WriteLine("Erro: Data de admissão inválida. Por favor, use o formato dd/MM/yyyy.");
                }
                else if (DataAdmissao > DateTime.Now)
                {
                    Console.WriteLine("Erro: A data de admissão não pode ser no futuro.");
                }
                else
                {
                    Console.WriteLine("Funcionário válido para admissão.");
                }
            }
        }

            /*decimal Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de adimissão do funcionário: ");
            DateTime DataAdmissao = DateTime.Parse(Console.ReadLine());
            
             if (Salario <= 0)
            {
                Console.WriteLine("Erro: O salário não pode ser 0 ou negativo.");
            }
            else if (DataAdmissao < DateTime.Now.Date)
            {
                Console.WriteLine("Erro: A data de admissão não pode ser anterior à data atual.");
            }
            else
            {
                Console.WriteLine("Funcionário válido para admissão.");
            }

            Console.WriteLine("==================================================");*/
        


        /*E - Método com nome ValidarNome que não permita que um funcionário tenha nome menor que 2 caracteres.
        Deve ser exibida uma mensagem ao usuário caso isso aconteça.*/
        public static void ValidarNome()
        {
            Console.WriteLine("=================================================="); 

            Console.WriteLine("Digite o nome do funcionário: ");
             string nome = Console.ReadLine();

             if (string.IsNullOrEmpty(nome) || nome.Length < 2)
            {
                Console.WriteLine("Erro: O nome do funcionário deve ter no mínimo 2 caracteres.");
            }
            else
            {
                Console.WriteLine("Nome do funcionário válido.");
            }

            Console.WriteLine("==================================================");
        }


        /*F - Método com nome ObterPorTipo que selecione a lista de funcionários de acordo com numeração digitada no console.*/
        public static void ObterPorTipo()
        {
            Console.WriteLine("==================================================");

            Console.WriteLine("Digite o tipo de funcionário: ");
            Console.WriteLine("1 - CLT");
            Console.WriteLine("2 - Aprendiz");

            int tipoDigitado;
            if (!int.TryParse(Console.ReadLine(), out tipoDigitado))
            {
                Console.WriteLine("Tipo Inválido! Digite um número. ");
                return;
            }

            // "Enum.IsDefined" valida se o número digitado realmente corresponde a algum valor do "TipoFuncionarioEnum".
            if (!Enum.IsDefined(typeof(TipoFuncionarioEnum), tipoDigitado))
            {
                Console.WriteLine("Tipo de funcionário não encontrado!");
                return;
            }

            //A conversão "(TipoFuncionarioEnum)tipoDigitado" evita misturar int e enum na comparação.
            TipoFuncionarioEnum tipoFuncionario = (TipoFuncionarioEnum)tipoDigitado;

            var funcionariosPorTipo = lista.Where(f => f.TipoFuncionario == tipoFuncionario).ToList();

            if (funcionariosPorTipo.Any())
            {
                Console.WriteLine($"Funcionários encontrados do tipo: {tipoFuncionario}");
                foreach (var f in funcionariosPorTipo)
                {
                    Console.WriteLine($"Nome: {f.Nome} - Salário: {f.Salario:c2} - Tipo: {f.TipoFuncionario}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum funcionário encontrado para o tipo informado.");
            }

            Console.WriteLine("==================================================");

        }

     }
}