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
        private RepositorioAmigo repositorioAmigo;
        private RepositorioRevistas repositorioRevistas;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo) : base("Emprestimo", repositorioEmprestimo)
        {
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

            Revista revistaSelecionada = (Revista)repositorioRevistas.SelecionarRegistroPorId(idRevista);

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
                    "{0, -10} | {1, -30} | {2, -20} | {3, -25} | {4, -25} | {5, -20}",
                    "Id", "Amigo", "Revista", "Data do Empréstimo", "Data prev. Devolução", "Status"
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
                     "{0, -10} | {1, -30} | {2, -20} | {3, -25} | {4, -25} | {5, -20}",
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

            Console.WriteLine("Visualização de Revista");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                "Id", "Título", "Edição", "Ano de Publicação", "Caixa", "Status"
            );

            EntidadeBase[] revistasDisponiveis = repositorioRevistas.SelecionarRevistasDisponiveis();



            for (int i = 0; i < revistasDisponiveis.Length; i++)
            {
                Revista r = (Revista)revistasDisponiveis[i];

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
