using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura1._0.Amigo;
using ClubeDaLeitura1._0.Caixas;
using ClubeDaLeitura1._0.Emprestimo;
using ClubeDaLeitura1._0.Revistas;

namespace ClubeDaLeitura1._0.Compartilhado
{
    public class TelaPrincipal
    {
    private char opcaoEscolhida;

        private RepositorioCaixa repositorioCaixa;
        private TelaCaixa telaCaixa;

        private RepositorioAmigo repositorioAmigo;
        private TelaAmigo telaAmigo;

        private RepositorioRevistas repositorioRevistas;
        private TelaRevistas telaRevistas;

        private RepositorioEmprestimo repositorioEmprestimo;
        private TelaEmprestimo telaEmprestimo;

        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            telaAmigo = new TelaAmigo(repositorioAmigo, repositorioEmprestimo);

            repositorioCaixa = new RepositorioCaixa();
            telaCaixa = new TelaCaixa(repositorioCaixa);

            repositorioRevistas = new RepositorioRevistas();
            telaRevistas = new TelaRevistas(repositorioRevistas, repositorioCaixa);

            repositorioEmprestimo = new RepositorioEmprestimo();
            telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevistas);
        }
        public void ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube da Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Controle de Amigos");
            Console.WriteLine("2 - Controle de Caixas");
            Console.WriteLine("3 - Controle de Revistas");
            Console.WriteLine("4 - Controle de Empréstimos");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            opcaoEscolhida = Console.ReadLine()[0]; 
        }
        public TelaBase ObterTela()
        {
            if (opcaoEscolhida == '1')
                return telaAmigo;

            else if (opcaoEscolhida == '2')
                return telaCaixa;

            else if (opcaoEscolhida == '3')
                return telaRevistas;

            else if (opcaoEscolhida == '4')
                return telaEmprestimo;

            return null;
        }
    }
}
