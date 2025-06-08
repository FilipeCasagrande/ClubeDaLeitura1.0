using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura1._0.Amigo;
using ClubeDaLeitura1._0.Caixas;
using ClubeDaLeitura1._0.Compartilhado;
using ClubeDaLeitura1._0.Revistas;

namespace ClubeDaLeitura1._0.Emprestimo
{
    public class TelaEmprestimo : TelaBase
    {
        private RepositorioEmprestimo repositorioEmprestimo;
        private RepositorioAmigo repositorioAmigo;
        private RepositorioRevistas repositorioRevistas;

        public TelaEmprestimo(
            RepositorioEmprestimo repositorio, 
            RepositorioAmigo repositorioAmigo, 
            RepositorioRevistas repositorioRevistas) 
            : base("Emprestimos", repositorio)
        {
            repositorioEmprestimo = repositorio;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevistas= repositorioRevistas;
        }

        public override char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
            Console.WriteLine($"2 - Devolução de {nomeEntidade}");
            Console.WriteLine($"3 - Visualizar {nomeEntidade}");
            Console.WriteLine($"S - Sair");

            Console.WriteLine();

            Console.Write("Digite uma opção válida: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

            return opcaoEscolhida;
        }

        public override void CadastrarRegistro()
        {
            {
                ExibirCabecalho();

                Console.WriteLine($"Cadastro de {nomeEntidade}");

                Console.WriteLine();

                Emprestimo novoRegistro = (Emprestimo)ObterDados();

                string erros = novoRegistro.Validar();

                if (erros.Length > 0)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(erros);
                    Console.ResetColor();

                    Console.Write("\nDigite ENTER para continuar...");
                    Console.ReadLine();

                    CadastrarRegistro();

                    return;
                }
                
                Emprestimo[] emprestimosAtivos = repositorioEmprestimo.SelecionarEmprestimosAtivos();

                for (int i = 0; i < emprestimosAtivos.Length; i++)
                {
                    Emprestimo emprestimoAtivo = emprestimosAtivos[i];

                    if (novoRegistro.Amigo.Id == emprestimoAtivo.Amigo.Id)
                    {
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Um amigo selecionado já tem um emprestimo ativo!");
                        Console.ResetColor();

                        Console.Write("\nDigite ENTER para continuar...");
                        Console.ReadLine();

                        return;
                    }
                }

                repositorio.CadastrarRegistro(novoRegistro);

                Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
                Console.ReadLine();
            }
        }

        protected override Emprestimo ObterDados()
        {
            VisualizarAmigos();

            Console.Write("Digite o ID do amigo que irá receber a revista: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigos amigoSelecionado = (Amigos)repositorioAmigo.SelecionarRegistroPorId(idAmigo);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nAmigo selecionado com sucesso!");
            Console.ResetColor();

            VisualizarRevistasDisponiveis();

            Console.Write("Digite o ID da revista que irá ser emprestada: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revistas.Revistas revistaSelecionada = (Revistas.Revistas)repositorioRevistas.SelecionarRegistroPorId(idRevista);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nRevista selecionada com sucesso!");
            Console.ResetColor();

            Emprestimo emprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);

            return emprestimo;
        }
        public override void VisualizarRegistros(bool exibirCabecalho)
        {
            {
                if (exibirCabecalho == true)
                    ExibirCabecalho();

                Console.WriteLine("Visualização de Empréstimos");

                Console.WriteLine();

                Console.WriteLine(
                    "{0, -10} | {1, -30} | {2, -20} | {3, -40} | {4, -40} | {5, -20}",
                    "Id", "Amigo", "Revistas", "Data do Empréstimo", "Data prev. Devolução", "Status"
                );

                EntidadeBase[] emprestimo = repositorio.SelecionarRegistros();

                for (int i = 0; i < emprestimo.Length; i++)
                {
                    Emprestimo e = (Emprestimo)emprestimo[i];

                    if (e == null)
                        continue;

                    if (e.Status == "Atrasado")
                        Console.ForegroundColor= ConsoleColor.DarkYellow;

                    Console.WriteLine(
                     "{0, -10} | {1, -30} | {2, -20} | {3, -40} | {4, -40} | {5, -20}",
                        e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo.ToShortDateString, e.DataDevolucao.ToShortDateString, e.Status
                    );

                    Console.ResetColor();
                }
                Console.ReadLine();
            }
        }


        private void VisualizarAmigos()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Amigos");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -30} | {3, -20}",
                "Id", "Nome", "Responsável", "Telefone"
            );

            EntidadeBase[] amigos = repositorioAmigo.SelecionarRegistros();

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigos a = (Amigos)amigos[i];

                if (a == null)
                    continue;

                Console.WriteLine(
                  "{0, -10} | {1, -30} | {2, -30} | {3, -20}",
                    a.Id, a.Nome, a.NomeResponsavel, a.Telefone
                );
            }
            Console.ReadLine();
        }
        private  void VisualizarRevistasDisponiveis()
        {
            Console.WriteLine();

            Console.WriteLine("Visualização de Revistas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                "Id", "Título", "Edição", "Ano de Publicação", "Caixa", "Status"
            );

            EntidadeBase[] revistasDisponiveis = repositorioRevistas.SelecionarRevistasDisponiveis();

            for (int i = 0; i < revistasDisponiveis.Length; i++)
            {
                Revistas.Revistas r = (Revistas.Revistas)revistasDisponiveis[i];

                if (r == null)
                    continue;

                Console.WriteLine(
                 "{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                    r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status
                );
            }

            Console.ReadLine();
        }
    }
}
